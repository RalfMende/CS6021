using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace CS6021
{
    public class CentralUnit
    {
        public List<Locomotive> locomotives = new List<Locomotive>();

        private int selectedLocomotiveIndex = -1;

        private CS2_UDP centralStationInstance;
        private bool centralStationConnected = false;
        private bool tracksActivated = false;
        
        public CentralUnit()
        {
        }

        /*--------------------------------------------------------------------*/

        public void SetActiveLocomotiveByAddress(int address)
        {
            if (!(locomotives.Exists(Locomotive => Locomotive.Address == address)))
            {
                this.locomotives.Add(new Locomotive
                {
                    Protocol = (byte)Locomotive.e_Protocol.MM,
                    Address = Convert.ToByte(address),
                    Speed = 0,
                    Direction = Locomotive.e_Direction.Forwards,
                    FunctionsState = new bool[] { false, false, false, false, false }
                });
                this.locomotives.Sort((x, y) => x.Address.CompareTo(y.Address));
            }
            selectedLocomotiveIndex = this.locomotives.FindIndex(Locomotive => Locomotive.Address == address);
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
                if (locomotives[selectedLocomotiveIndex].Protocol == Locomotive.e_Protocol.MM)
                {
                    locomotives[selectedLocomotiveIndex].Protocol = Locomotive.e_Protocol.DCC;
                }
                else if (locomotives[selectedLocomotiveIndex].Protocol == Locomotive.e_Protocol.DCC)
                {
                    locomotives[selectedLocomotiveIndex].Protocol = Locomotive.e_Protocol.MM;
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
                if (locomotives[selectedLocomotiveIndex].Direction == Locomotive.e_Direction.Forwards)
                {
                    locomotives[selectedLocomotiveIndex].Direction = Locomotive.e_Direction.Backwards;
                }
                else
                {
                    locomotives[selectedLocomotiveIndex].Direction = Locomotive.e_Direction.Forwards;
                }
            }
        }

        public void SetActiveLocomotivesSpeed(int speed)
        {
            if (selectedLocomotiveIndex > -1)
            {
                if (speed > -1 && speed < 126 )
                {
                    locomotives[selectedLocomotiveIndex].Speed = speed;
                }
            }
        }

        public void SetActiveLocomotivesFunctionState(int functionNumber, int functionState)
        {
            if (selectedLocomotiveIndex > -1)
            {
                if (functionState == 0)
                {
                    locomotives[selectedLocomotiveIndex].FunctionsState[functionNumber] = false;
                }
                else if(functionState == 1)
                {
                    locomotives[selectedLocomotiveIndex].FunctionsState[functionNumber] = true;
                }
                else  // toggle state
                {
                    locomotives[selectedLocomotiveIndex].FunctionsState[functionNumber] = !locomotives[selectedLocomotiveIndex].FunctionsState[functionNumber];
                }

            }
        }

        /*--------------------------------------------------------------------*/

        public void ConnectToCentralStation(string hostname)
        {

            int returnValue = -1;
            string ipAddressByUser = hostname;// "maerklin-cs3"; //TODO: Change to stored value
            Stopwatch sw = new Stopwatch();

            centralStationInstance = new CS2_UDP();
            sw.Start();
            while (true)
            {
                returnValue = centralStationInstance.SetupConnection(ipAddressByUser);
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
            centralStationConnected = true;

        }

        public void ActivateTrackPower()
        {
            if (centralStationConnected == true)
            {
                centralStationInstance.ActivateTracks();
            }
        }

        public void DeactivateTrackPower()
        {
            if (centralStationConnected == true)
            {
                centralStationInstance.DeactivateTracks();
            }
        }

        public bool GetTrackPowerState()
        {
            return tracksActivated;
        }

        public void UpdateLocomotiveAtCentralStation()
        {
            //if (centralStationConnected == true && locomotives.Count != 0)
            if (centralStationConnected == true && selectedLocomotiveIndex > -1)
            {
                // update direction
                centralStationInstance.SetLocomotiveDirection(locomotives[selectedLocomotiveIndex]);

                // update speed
                centralStationInstance.SetLocomotiveSpeed(locomotives[selectedLocomotiveIndex]);

                //update function
                centralStationInstance.SetLocomotiveFunction(locomotives[selectedLocomotiveIndex], 0);
                centralStationInstance.SetLocomotiveFunction(locomotives[selectedLocomotiveIndex], 1);
                centralStationInstance.SetLocomotiveFunction(locomotives[selectedLocomotiveIndex], 2);
                centralStationInstance.SetLocomotiveFunction(locomotives[selectedLocomotiveIndex], 3);
                centralStationInstance.SetLocomotiveFunction(locomotives[selectedLocomotiveIndex], 4);
            }
        }

    }
}
