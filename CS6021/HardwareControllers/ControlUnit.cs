using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace CS6021
{
    public class ControlUnit
    {
        public string nameOfInstance;

        private Locomotive locomotive;

        public ControlUnit()
        {
            this.nameOfInstance = "newLocomotive";
            this.locomotive = new Locomotive();
        }

        ~ControlUnit()
        {
        }

        /*--------------------------------------------------------------------*/

        public void SetLocomotiveAddress(int address)
        {
            if (address > 0 && address < 256) // as CentralStation allowes a maximum of 255 locomotives
            {
                this.locomotive.address = Convert.ToByte(address); //TODO: Change the way address is stored
            }
            this.nameOfInstance = address.ToString();
        }

        public int GetLocomotiveAddress()
        {
            return Convert.ToInt32(this.locomotive.address); //TODO: Change the way address is stored
        }

        public void SetLocomotiveProtocol(Locomotive.e_DecoderType protocol)
        {
            this.locomotive.protocol = protocol;
        }

        public Locomotive.e_DecoderType GetLocomotiveProtocol()
        {
            return this.locomotive.protocol;
        }

        public void ToggleLocomotiveProtocol()
        {
            if (this.locomotive.protocol == Locomotive.e_DecoderType.MM)
            {
                this.locomotive.protocol = Locomotive.e_DecoderType.DCC;
            }
            else if (this.locomotive.protocol == Locomotive.e_DecoderType.DCC)
            {
                this.locomotive.protocol = Locomotive.e_DecoderType.MM;
            }
            else // mfx shoould not be set by GUI
            {
            }
        }

        public void SetLocomotiveDirection(Locomotive.e_Direction direction)
        {
            this.locomotive.direction = direction;
        }

        public Locomotive.e_Direction GetLocomotiveDirection()
        {
            return this.locomotive.direction;
        }

        public void ToggleLocomotiveDirection()
        {
            if (this.locomotive.direction == Locomotive.e_Direction.Forwards)
            {
                this.locomotive.direction = Locomotive.e_Direction.Backwards;
            }
            else
            {
                this.locomotive.direction = Locomotive.e_Direction.Forwards;
            }
            CentralStation.SetLocomotiveDirection(this.locomotive);
        }

        public void SetLocomotiveSpeed(int speed)
        {
            if (speed > -1 && speed < 126)
            {
                this.locomotive.speed = speed;
            }
            CentralStation.SetLocomotiveSpeed(this.locomotive);
        }

        public int GetLocomotiveSpeed()
        {
            return this.locomotive.speed;
        }

        public void SetLocomotiveFunctionState(int functionNumber, int functionState)
        {
            if (functionState == 0)
            {
                this.locomotive.functionsState[functionNumber] = false;
            }
            else if (functionState == 1)
            {
            this.locomotive.functionsState[functionNumber] = true;
            }
            else  // toggle state
            {
            this.locomotive.functionsState[functionNumber] = !this.locomotive.functionsState[functionNumber];
            }
            CentralStation.SetLocomotiveFunction(this.locomotive, functionState);
        }

        public bool GetLocomotiveFunctionState(int functionNumber)
        {
            /*if (this.locomotive.functionsState[functionNumber] == false)
            {
                return 0;
            }
            else //(this.locomotive.functionsState[functionNumber] == true)
            {
                return 1;
            }*/
            return this.locomotive.functionsState[functionNumber];
        }
    }
}
