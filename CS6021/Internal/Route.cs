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
