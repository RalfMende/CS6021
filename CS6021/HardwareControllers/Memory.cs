﻿/*
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
    public class Memory
    {
        public string NameOfInstance { get; set; }
        public Boolean LearningIsActive { get; set; }

        private Route[] routeArray;

        public Memory()
        {
            this.NameOfInstance = "newMemory";
            this.routeArray = new Route[24];
        }

        public Memory(string name)
        {
            this.NameOfInstance = name;
            this.routeArray = new Route[24];
        }

        ~Memory()
        {
        }

        /*--------------------------------------------------------------------*/

        public int SetRoute(int id)
        {
            int retVal = 0;
            if (CentralStation.IsConnected == true)
            {
                foreach (Accessory accessory in this.routeArray[id - 1].accessories)
                {
                    CentralStation.SetAccessoryState(accessory, accessory.Position);
                }
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
