using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace CS6021
{
    public class CentralUnit
    {
        public CentralUnit()
        {
        }

        ~CentralUnit()
        {
        }

        public List<Locomotive> locomotives = new List<Locomotive>();
        private int selectedLocomotiveIndex = -1;

        //private bool centralStationConnected = false;
        //private bool tracksActivated = false;

        /*--------------------------------------------------------------------*/

        public void SetActiveLocomotiveByAddress(int address)
        {
            if (!(locomotives.Exists(Locomotive => Locomotive.address == address)))
            {
                this.locomotives.Add(new Locomotive
                {
                    protocol = (byte)Locomotive.e_DecoderType.MM,
                    address = Convert.ToByte(address),
                    name = "",
                    speed = 0,
                    direction = Locomotive.e_Direction.Forwards,
                    functionsState = new bool[] { false, false, false, false, false }
                }); ;
                this.locomotives.Sort((x, y) => x.address.CompareTo(y.address));
            }
            selectedLocomotiveIndex = this.locomotives.FindIndex(Locomotive => Locomotive.address == address);
        }

        public void SetActiveLocomotiveByListindex(int index)
        {
            this.selectedLocomotiveIndex = index;
        }

        public Locomotive GetActiveLocomotive()
        {
            return locomotives[selectedLocomotiveIndex];
        }

        public void ToggleActiveLocomotivesProtocol()
        {
            if (selectedLocomotiveIndex > -1)
            {
                if (locomotives[selectedLocomotiveIndex].protocol == Locomotive.e_DecoderType.MM)
                {
                    locomotives[selectedLocomotiveIndex].protocol = Locomotive.e_DecoderType.DCC;
                }
                else if (locomotives[selectedLocomotiveIndex].protocol == Locomotive.e_DecoderType.DCC)
                {
                    locomotives[selectedLocomotiveIndex].protocol = Locomotive.e_DecoderType.MM;
                }
                else // mfx shoould not be set by GUI
                {
                }
            }
        }

        public void ToggleActiveLocomotivesDirection()
        {
            if (selectedLocomotiveIndex > -1)
            {
                if (locomotives[selectedLocomotiveIndex].direction == Locomotive.e_Direction.Forwards)
                {
                    locomotives[selectedLocomotiveIndex].direction = Locomotive.e_Direction.Backwards;
                }
                else
                {
                    locomotives[selectedLocomotiveIndex].direction = Locomotive.e_Direction.Forwards;
                }
                //TODO: send command to CentralStation
            }
        }

        public void SetActiveLocomotivesSpeed(int speed)
        {
            if (selectedLocomotiveIndex > -1)
            {
                if (speed > -1 && speed < 126 )
                {
                    locomotives[selectedLocomotiveIndex].speed = speed;
                }
                //TODO: send command to CentralStation
            }
        }

        public void SetActiveLocomotivesFunctionState(int functionNumber, int functionState)
        {
            if (selectedLocomotiveIndex > -1)
            {
                if (functionState == 0)
                {
                    locomotives[selectedLocomotiveIndex].functionsState[functionNumber] = false;
                }
                else if(functionState == 1)
                {
                    locomotives[selectedLocomotiveIndex].functionsState[functionNumber] = true;
                }
                else  // toggle state
                {
                    locomotives[selectedLocomotiveIndex].functionsState[functionNumber] = !locomotives[selectedLocomotiveIndex].functionsState[functionNumber];
                }
                //TODO: send command to CentralStation
            }
        }

        /*--------------------------------------------------------------------*/

        public void ConnectToCentralStation(string hostname)
        {

            int returnValue = -1;
            string ipAddressByUser = hostname;// "maerklin-cs3"; //TODO: Change to stored value
            Stopwatch sw = new Stopwatch();

            sw.Start();
            while (true)
            {
                returnValue = CentralStation.SetupConnection(ipAddressByUser);
                if (returnValue != 0)
                {
                    //ipAddressByUser = await DisplayPromptAsync("CentralStation Connection", "Please enter hostname or IP address", initialValue: "maerklin-cs3");
                }
                else
                {
                    if (ipAddressByUser != null)
                    {
                        //Properties.Settings.Default.ipAddress = ipAddressByUser; //TODO: store value permanently
                    }
                    break;
                }
            }
        }

        public void ActivateTrackPower()
        {
            if (CentralStation.IsConnected == true)
            {
                CentralStation.ActivateTracks();
            }
        }

        public void DeactivateTrackPower()
        {
            if (CentralStation.IsConnected == true)
            {
                CentralStation.DeactivateTracks();
            }
        }

        public bool GetTrackPowerState()
        {
            return CentralStation.IsConnected;
        }

        public void UpdateLocomotiveAtCentralStation()
        {
            if (CentralStation.IsConnected == true && selectedLocomotiveIndex > -1)
            {
                // update direction
                CentralStation.SetLocomotiveDirection(locomotives[selectedLocomotiveIndex]);

                // update speed
                CentralStation.SetLocomotiveSpeed(locomotives[selectedLocomotiveIndex]);

                //update function
                CentralStation.SetLocomotiveFunction(locomotives[selectedLocomotiveIndex], 0);
                CentralStation.SetLocomotiveFunction(locomotives[selectedLocomotiveIndex], 1);
                CentralStation.SetLocomotiveFunction(locomotives[selectedLocomotiveIndex], 2);
                CentralStation.SetLocomotiveFunction(locomotives[selectedLocomotiveIndex], 3);
                CentralStation.SetLocomotiveFunction(locomotives[selectedLocomotiveIndex], 4);
            }
        }

    }
}
