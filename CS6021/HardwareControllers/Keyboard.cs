using System;
using CentralStations;
using Internal;

namespace HardwareControllers
{
    public class Keyboard
    {
        public string nameOfInstance;

        private Accessory[] acessoryArray;

        public Keyboard()
        {
            this.nameOfInstance = "newKeyboard";
            this.acessoryArray = new Accessory[16];
            for (int index = 0; index < 16; index++)
            {
                this.acessoryArray[index] = new Accessory();
                this.acessoryArray[index].id = Convert.ToByte(index+1);
                this.acessoryArray[index].name = Convert.ToString(index+1);
                this.acessoryArray[index].Protocol = Accessory.e_DecoderType.MM;
                this.acessoryArray[index].Position = Accessory.e_Position.on_green_stright_hp1;
            }
        }

        public Keyboard(string name, int acessoryStartId)
        {
            this.nameOfInstance = name;
            this.acessoryArray = new Accessory[16];
            for (int index = 0; index < 16; index++)
            {
                this.acessoryArray[index] = new Accessory();
                this.acessoryArray[index].id = Convert.ToByte(acessoryStartId + index);
                this.acessoryArray[index].name = Convert.ToString(acessoryStartId + index);
                this.acessoryArray[index].Protocol = Accessory.e_DecoderType.MM;
                this.acessoryArray[index].Position = Accessory.e_Position.on_green_stright_hp1;
            }
        }

        ~Keyboard()
        {
        }

        /*--------------------------------------------------------------------*/

        public int SetAccessoryState(int id, Accessory.e_Position position)
        {
            int retVal = 0;
            if (CentralStation.isConnected == true)
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
