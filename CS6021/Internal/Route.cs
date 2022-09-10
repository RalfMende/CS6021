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
using System.Collections.Generic;

namespace Internal
{
    public class Route
    {
        public Route()
        {
        }

        ~Route()
        {
        }

        public enum e_operation { manual = 0, mixed_autmatic = 1 };

        public byte id { get; set; } // maximum of 255 addresses
        public string name { get; set; }
        //public int s88 { get; set; } // S88-contact, that triggers this route when closing ( 0 = no S88 control)
        //public int s88_on { get; set; } // S88-contact, that triggers this route when opening ( 0 = no S88 control)
        public e_operation external_control { get; set; }
        public List<Accessory> accessories = new List<Accessory>();
    }
}
