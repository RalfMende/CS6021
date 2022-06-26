using System;
namespace CS6021
{
    public class Keyboard
    {
        //public string nameOfInstance = "newKeyboard";
        //public Accessory[] acessoryArray = new Accessory[16];
        public string nameOfInstance;
        public Accessory[] acessoryArray;

        public Keyboard()
        {
            this.nameOfInstance = "newKeyboard";
            this.acessoryArray = new Accessory[16];
        }

        ~Keyboard()
        {
        }

        /*--------------------------------------------------------------------*/

        public int SetAccessoryState(int id, Accessory.e_Position position)
        {
            int retVal = 0;
            if (CentralStation.IsConnected == true)
            {
                this.acessoryArray[id - 1].Position = position;
                CentralStation.SetAccessoryState(this.acessoryArray[id - 1], this.acessoryArray[id - 1].Position);
                retVal = 1;
            }
            else
            {
                retVal = -1;
            }
            return retVal;
        }
    }
}
