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
