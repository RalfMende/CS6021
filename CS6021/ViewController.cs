using System;
using System.Timers;
using UIKit;
using CoreGraphics;

namespace CS6021
{

    public partial class ViewController : UIViewController
    {
        CentralUnit centralUnitInstance;
        private int sevenSegDigitMax = 3;
        private string sevenSegString = "";
        private string sevenSegStringPrevious = "";
        Timer entryTimer = new Timer(5000);

        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Perform any additional setup after loading the view, typically from a nib.



            /*var longPress = new UILongPressGestureRecognizer(tapAndSlide);
            longPress.MinimumPressDuration = 0;
            //longPress.CancelsTouchesInView = false;
            sld_speed.AddGestureRecognizer(longPress);
            sld_speed.UserInteractionEnabled = true;*/






            centralUnitInstance = new CentralUnit();
            led_Img.Hidden = true;
            led_function_img.Hidden = true;
            led_f1_img.Hidden = true;
            led_f2_img.Hidden = true;
            led_f3_img.Hidden = true;
            led_f4_img.Hidden = true;


            //TODO: Only for testing purpose
            /*- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
            centralUnitInstance.locomotives.Add(new Locomotive
            {
                Protocol = Locomotive.e_Protocol.MFX,
                Address = 6,
                Speed = 0,
                Direction = Locomotive.e_Direction.Forwards,
                FunctionsState = new bool[] { false, false, false, false, false }
            });
            /*- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */

            tablVw_locomotives.Source = new TableSource(centralUnitInstance.locomotives);
            Add(tablVw_locomotives);
            ((TableSource)tablVw_locomotives.Source).LocomotiveSelected += ViewController_LocomotiveSelected;
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        /*--------------------------------------------------------------------*/

        void ViewController_LocomotiveSelected(object sender, int currentLocomotivesListIndex)
        {
            centralUnitInstance.SetActiveLocomotiveByListindex(currentLocomotivesListIndex);
            UpdateLocomotive(true);
        }

        /*--------------------------------------------------------------------*/

        partial void btn_connect_pressed(UIButton sender)
        {
            centralUnitInstance.ConnectToCentralStation(txt_ipAddress.Text);
        }

        partial void btn_1_pressed(UIButton sender)
        {
            EnterDigitForLocomotiveAddress(1);
        }

        partial void btn_2_pressed(UIButton sender)
        {
            EnterDigitForLocomotiveAddress(2);
        }

        partial void btn_3_pressed(UIButton sender)
        {
            EnterDigitForLocomotiveAddress(3);
        }

        partial void btn_4_pressed(UIButton sender)
        {
            EnterDigitForLocomotiveAddress(4);
        }

        partial void btn_5_pressed(UIButton sender)
        {
            EnterDigitForLocomotiveAddress(5);
        }

        partial void btn_6_pressed(UIButton sender)
        {
            EnterDigitForLocomotiveAddress(6);
        }

        partial void btn_7_pressed(UIButton sender)
        {
            EnterDigitForLocomotiveAddress(7);
        }

        partial void btn_8_pressed(UIButton sender)
        {
            EnterDigitForLocomotiveAddress(8);
        }

        partial void btn_9_pressed(UIButton sender)
        {
            EnterDigitForLocomotiveAddress(9);
        }

        partial void btn_0_pressed(UIButton sender)
        {
            EnterDigitForLocomotiveAddress(0);
        }

        partial void btn_L_pressed(UIButton sender)
        {
        }

        partial void btn_F_pressed(UIButton sender)
        {
        }

        partial void btn_f1_pressed(UIButton sender)
        {
            centralUnitInstance.SetActiveLocomotivesFunctionState(1, 2); // toggle state
            UpdateLocomotive(true);
        }

        partial void btn_f2_pressed(UIButton sender)
        {
            centralUnitInstance.SetActiveLocomotivesFunctionState(2, 2); // toggle state
            UpdateLocomotive(true);
        }

        partial void btn_f3_pressed(UIButton sender)
        {
            centralUnitInstance.SetActiveLocomotivesFunctionState(3, 2); // toggle state
            UpdateLocomotive(true);
        }

        partial void btn_f4_pressed(UIButton sender)
        {
            centralUnitInstance.SetActiveLocomotivesFunctionState(4, 2); // toggle state
            UpdateLocomotive(true);
        }

        partial void btn_function_pressed(UIButton sender)
        {
            centralUnitInstance.SetActiveLocomotivesFunctionState(0, 1);
            UpdateLocomotive(true);
        }

        partial void btn_off_pressed(UIButton sender)
        {
            centralUnitInstance.SetActiveLocomotivesFunctionState(0, 0);
            UpdateLocomotive(true);
        }

        partial void btn_go_pressed(UIButton sender)
        {
            centralUnitInstance.ActivateTrackPower();
        }

        partial void btn_stop_pressed(UIButton sender)
        {
            centralUnitInstance.DeactivateTrackPower();
        }

        partial void btn_protocol_pressed(UIButton sender)
        {
            centralUnitInstance.ToggleActiveLocomotivesProtocol();
            UpdateLocomotive(true);
        }

        partial void btn_direction_pressed(UIButton sender)
        {
            centralUnitInstance.ToggleActiveLocomotivesDirection();
            centralUnitInstance.SetActiveLocomotivesSpeed(0);
            UpdateLocomotive(true);
        }

        partial void sld_speed_value_changed(UISlider sender)
        {
            centralUnitInstance.SetActiveLocomotivesSpeed((int)sld_speed.Value);
            UpdateLocomotive(true);
        }

        /*--------------------------------------------------------------------*/

        void OnEntryTimerElapsed(object o, EventArgs e)
        {
            entryTimer.Stop();

            //only set lbl, for nothing else has changed
            sevenSegString = "";
            sevenSegString = sevenSegStringPrevious;
            lbl_address.Text = sevenSegString; //TODO: Why is this not working?
        }

        private void EnterDigitForLocomotiveAddress(int digit)
        {
            int tmpAddress;

            if (sevenSegString.Length < sevenSegDigitMax)
            {
                sevenSegString = sevenSegString + digit.ToString();
            }
            else
            {
                sevenSegString = digit.ToString();
                entryTimer.Elapsed += OnEntryTimerElapsed;
                entryTimer.Start();
            }
            lbl_address.Text = sevenSegString;

            if (sevenSegString.Length == sevenSegDigitMax)
            {
                entryTimer.Stop();

                tmpAddress = Convert.ToInt32(sevenSegString);
                if (tmpAddress > 0 && tmpAddress < 256) // as CentralStation allowes a maximum of 255 locomotives
                {
                    centralUnitInstance.SetActiveLocomotiveByAddress(tmpAddress);
                    tablVw_locomotives.ReloadData();
                    UpdateLocomotive(true);
                    sevenSegStringPrevious = sevenSegString;
                }
                else
                {
                    //sevenSegString = "";
                    sevenSegString = sevenSegStringPrevious;
                    lbl_address.Text = sevenSegString;
                }
            }
        }

        private void UpdateLocomotive(bool updateGuiAlso)
        {
            // update status indicators in GUI
            if (centralUnitInstance.locomotives.Count > 0)
            {
                // trigger to send all commands to locomotive / central station 
                centralUnitInstance.UpdateLocomotiveAtCentralStation();

                if(updateGuiAlso == true)
                {
                    // update address
                    if (centralUnitInstance.GetActiveLocomotive().Address < 10)
                    {
                        lbl_address.Text = "00" + centralUnitInstance.GetActiveLocomotive().Address.ToString();
                    }
                    else if (centralUnitInstance.GetActiveLocomotive().Address < 100)
                    {
                        lbl_address.Text = "0" + centralUnitInstance.GetActiveLocomotive().Address.ToString();
                    }
                    else
                    {
                        lbl_address.Text = centralUnitInstance.GetActiveLocomotive().Address.ToString();
                    }

                    // update protocol indicator
                    switch (centralUnitInstance.GetActiveLocomotive().Protocol)
                    {
                        case Locomotive.e_Protocol.MM:
                            btn_protocol.SetTitle("MM", UIControlState.Normal);
                            break;

                        case Locomotive.e_Protocol.DCC:
                            btn_protocol.SetTitle("DCC", UIControlState.Normal);
                            break;

                        case Locomotive.e_Protocol.MFX:
                            btn_protocol.SetTitle("mfx", UIControlState.Normal);
                            break;
                    }

                    // update direction indicator
                    if (centralUnitInstance.GetActiveLocomotive().Direction == Locomotive.e_Direction.Forwards)
                    {
                        btn_direction.SetTitle("   >", UIControlState.Normal);
                        btn_direction2.SetTitle("   >", UIControlState.Normal);
                    }
                    else
                    {
                        btn_direction.SetTitle("<", UIControlState.Normal);
                        btn_direction2.SetTitle("<", UIControlState.Normal);
                    }

                    // update speed indicator
                    int tmpSpeed = centralUnitInstance.GetActiveLocomotive().Speed;
                    sld_speed.Value = tmpSpeed;
                    knob_Img.Transform = CGAffineTransform.MakeRotation((float)tmpSpeed / 65);
                    View.AddSubview(knob_Img);

                    // set function state indicator
                    led_function_img.Hidden = !centralUnitInstance.GetActiveLocomotive().FunctionsState[0];
                    led_f1_img.Hidden = !centralUnitInstance.GetActiveLocomotive().FunctionsState[1];
                    led_f2_img.Hidden = !centralUnitInstance.GetActiveLocomotive().FunctionsState[2];
                    led_f3_img.Hidden = !centralUnitInstance.GetActiveLocomotive().FunctionsState[3];
                    led_f4_img.Hidden = !centralUnitInstance.GetActiveLocomotive().FunctionsState[4];

                    // set track state
                    led_Img.Hidden = !centralUnitInstance.GetTrackPowerState();
                }
            }
        }



    }
}