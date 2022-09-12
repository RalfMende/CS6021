/*
 * CS6021 - iPad Remote Controller for Märklin Central Station in ControlUnit-Design
 * 
 * Copyright (c) 2022 Ralf Mende
 * 
 * 
 * This file is part of CS6021.
 * 
 * CS6021 is free software: you can redistribute it and/or modify it 
 * under the terms of the GNU General Public License as published by the 
 * Free Software Foundation, either version 3 of the License, or (at your 
 * option) any later version.
 * 
 * CS6021 is distributed in the hope that it will be useful, but 
 * WITHOUT ANY WARRANTY; without even the implied warranty of 
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. 
 * See the GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License 
 * along with Foobar. If not, see 
 * <https://www.gnu.org/licenses/>.
*/

using System;
using CentralStations;
using Internal;

namespace HardwareControllers
{
    public class Keyboard
    {
        public string NameOfInstance { get; set; }
        public int AccessoryStartAddress { get; set; }

        private Accessory[] acessoryArray;

        public Keyboard()
        {
            this.NameOfInstance = "newKeyboard";
            this.acessoryArray = new Accessory[16];
            this.AccessoryStartAddress = 1; // TODO: Automatically check for the next numbers
            for (int index = AccessoryStartAddress; index < AccessoryStartAddress + 16; index++)
            {
                this.acessoryArray[index] = new Accessory();
                this.acessoryArray[index].id = Convert.ToByte(index);
                this.acessoryArray[index].name = Convert.ToString(index);
                this.acessoryArray[index].Protocol = Accessory.e_DecoderType.MM;
                this.acessoryArray[index].Position = Accessory.e_Position.on_green_stright_hp1;
            }
        }

        public Keyboard(string name, int acessoryStartId)
        {
            this.NameOfInstance = name;
            this.AccessoryStartAddress = acessoryStartId;
            this.acessoryArray = new Accessory[16];
            for (int index = 0; index < 16; index++)
            {
                this.acessoryArray[index] = new Accessory();
                this.acessoryArray[index].id = Convert.ToByte(this.AccessoryStartAddress + index);
                this.acessoryArray[index].name = Convert.ToString(this.AccessoryStartAddress + index);
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
