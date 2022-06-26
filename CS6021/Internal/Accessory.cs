using System;
namespace CS6021
{
    public class Accessory
    {
        public Accessory()
        {
        }

        public Accessory(byte adress)
        {
            this.id = adress;
            this.Protocol = e_DecoderType.MM; //default
        }

        ~Accessory()
        {
        }

        public enum e_type {
            std_red_green,
            std_red,
            std_green,
            coupler,
            coupler_1,
            turnout_right,
            turnout_left,
            turnout_Y,
            k84_Output,
            k84_doubleOutput,
            turnout_three_way,
            turnout_double_slip_2motors,
            turnout_double_slip_1motor,
            signal_light_HP01,
            signal_light_HP02,
            signal_light_HP012,
            signal_light_HP012_SH01,
            signal_light_SH01,
            signal_mechanical_HP01,
            signal_mechanical_HP02,
            signal_mechanical_HP012,
            signal_mechanical_HP012_SH01,
            signal_mechanical_SH01,
            signal_light_urc_HP01,
            signal_light_urc_HP012,
            signal_light_urc_HP012_SH01,
            signal_light_urc_SH01,
            travelling_plattform,
            turntable_old,
            turntable_digital
        };

        public enum e_Position
        {
            off_round_red_right_hp0 = 0,
            on_green_stright_hp1 = 1,
            yellow_left_hp2 = 2,
            white_sh0 = 3
        };

        public enum e_DecoderType { MM = 0x00, MFX = 0x40, DCC = 0xC0 };

        public byte id { get; set; } // maximum of 255 addresses
        public string name { get; set; } // to be shown above buttons
        //public e_type type { get; set; }
        public e_Position Position { get; set; } // current position
        //public int switching_time { get; set; } // time in milliseconds
        public e_DecoderType Protocol { get; set; }
    }
}
