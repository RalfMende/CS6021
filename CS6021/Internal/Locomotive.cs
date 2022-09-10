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

namespace Internal
{
    public class Locomotive
    {
        public Locomotive()
        {
            functionsState = new bool[5];
        }

        ~Locomotive()
        {
        }

        public enum e_DecoderType { MM = 0x00, MFX = 0x40, DCC = 0xC0 };

        public enum e_Direction { Backwards = 0, Forwards = 1 };

        //public int uid { get; set; }
        public string name { get; set; }
        public byte address { get; set; } // maximum of 255 addresses
        public e_DecoderType protocol { get; set; }
        public int speed { get; set; } // 0 (= not mooving) to 125 (= maximum speed)
        public e_Direction direction { get; set; }
        public bool[] functionsState { get; set; }
    }
}
