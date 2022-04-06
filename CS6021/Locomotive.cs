using System;

namespace CS6021
{
    public class Locomotive
    {
        public Locomotive()
        {
        }

        public enum e_Direction { Backwards = 0, Forwards = 1 };
        public enum e_Protocol { MM = 0x00, MFX = 0x40, DCC = 0xC0 };

        public e_Protocol Protocol { get; set; }
        public byte Address { get; set; } // maximum of 255 addresses
        public int Speed { get; set; } // 0 (= not mooving) to 125 (= maximum speed)
        public e_Direction Direction { get; set; }
        public bool[] FunctionsState { get; set; }
    }
}
