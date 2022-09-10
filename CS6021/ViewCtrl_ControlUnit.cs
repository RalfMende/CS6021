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
using System.Timers;
using UIKit;
using CoreGraphics;
using System.Collections.Generic;
using CentralStations;
using HardwareControllers;
using Internal;

namespace CS6021
{
    public partial class ViewCtrl_ControlUnit : UIViewController
    {
        public List<ControlUnit> controlUnits = new List<ControlUnit>();
        private int currentControlUnitInstanceListIndex = 0;

        private int sevenSegDigitMax = 3;
        private string sevenSegString = "";
        private string sevenSegStringPrevious = "";
        Timer entryTimer = new Timer(5000);

        public ViewCtrl_ControlUnit(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            led_Img.Hidden = true;
            led_function_img.Hidden = true;
            led_f1_img.Hidden = true;
            led_f2_img.Hidden = true;
            led_f3_img.Hidden = true;
            led_f4_img.Hidden = true;



            //TODO: Initially put one instance if apps runs for the first time

            ControlUnit controlUnitInstance = new ControlUnit();
            controlUnitInstance.nameOfInstance = "V60";
            controlUnitInstance.SetLocomotiveProtocol(Locomotive.e_DecoderType.MFX);
            controlUnitInstance.SetLocomotiveAddress(6);
            controlUnits.Add(controlUnitInstance);

            //controlUnits.Add(new ControlUnit());





            tablVw_ControlUnit.Source = new TableSourceControlUnit(controlUnits);
            Add(tablVw_ControlUnit);
            ((TableSourceControlUnit)tablVw_ControlUnit.Source).ControlUnitSelected += ViewController_ControlUnitSelected;

            btn_controlUnit_add.Clicked += btn_controlUnit_add_EventHandler;





            /*var longPress = new UILongPressGestureRecognizer(tapAndSlide);
            longPress.MinimumPressDuration = 0;
            //longPress.CancelsTouchesInView = false;
            sld_speed.AddGestureRecognizer(longPress);
            sld_speed.UserInteractionEnabled = true;*/
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        /*--------------------------------------------------------------------*/

        void ViewController_ControlUnitSelected(object sender, int currentControlUnitListIndex)
        {
            currentControlUnitInstanceListIndex = currentControlUnitListIndex;
            UpdateLocomotiveInfos();
        }

        private void btn_controlUnit_add_EventHandler(object sender, EventArgs args)
        {
            controlUnits.Add(new ControlUnit());
            this.controlUnits.Sort((x, y) => x.nameOfInstance.CompareTo(y.nameOfInstance));
            tablVw_ControlUnit.ReloadData();
            
            //var userLookupValueIndex = controlUnits.IndexOf("NewLocomotive");
            //tablVw_ControlUnit.SelectRow(NSIndexPath.FromRowSection(userLookupIndex, 0), false, UITableViewScrollPosition.None);
            //UpdateLocomotive(true);
        }

        /*--------------------------------------------------------------------*/

        partial void btn_connect_pressed(UIButton sender)
        {
            CentralStation.ConnectToCentralStation(txt_ipAddress.Text); //TODO:
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
            controlUnits[currentControlUnitInstanceListIndex].SetLocomotiveFunctionState(1, 2); // toggle state
            UpdateLocomotiveInfos();
        }

        partial void btn_f2_pressed(UIButton sender)
        {
            controlUnits[currentControlUnitInstanceListIndex].SetLocomotiveFunctionState(2, 2); // toggle state
            UpdateLocomotiveInfos();
        }

        partial void btn_f3_pressed(UIButton sender)
        {
            controlUnits[currentControlUnitInstanceListIndex].SetLocomotiveFunctionState(3, 2); // toggle state
            UpdateLocomotiveInfos();
        }

        partial void btn_f4_pressed(UIButton sender)
        {
            controlUnits[currentControlUnitInstanceListIndex].SetLocomotiveFunctionState(4, 2); // toggle state
            UpdateLocomotiveInfos();
        }

        partial void btn_function_pressed(UIButton sender)
        {
            controlUnits[currentControlUnitInstanceListIndex].SetLocomotiveFunctionState(0, 1);
            UpdateLocomotiveInfos();
        }

        partial void btn_off_pressed(UIButton sender)
        {
            controlUnits[currentControlUnitInstanceListIndex].SetLocomotiveFunctionState(0, 0);
            UpdateLocomotiveInfos();
        }

        partial void btn_go_pressed(UIButton sender)
        {
            CentralStation.ActivateTrackPower();
        }

        partial void btn_stop_pressed(UIButton sender)
        {
            CentralStation.DeactivateTrackPower();
        }

        partial void btn_protocol_pressed(UIButton sender)
        {
            controlUnits[currentControlUnitInstanceListIndex].ToggleLocomotiveProtocol();
            UpdateLocomotiveInfos();
        }

        partial void btn_direction_pressed(UIButton sender)
        {
            controlUnits[currentControlUnitInstanceListIndex].ToggleLocomotiveDirection();
            controlUnits[currentControlUnitInstanceListIndex].SetLocomotiveSpeed(0);
            UpdateLocomotiveInfos();
        }

        partial void sld_speed_value_changed(UISlider sender)
        {
            controlUnits[currentControlUnitInstanceListIndex].SetLocomotiveSpeed((int)sld_speed.Value);
            UpdateLocomotiveInfos();
        }

        /*--------------------------------------------------------------------*/

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
                if (controlUnits[currentControlUnitInstanceListIndex].GetLocomotiveProtocol() != Locomotive.e_DecoderType.MFX
                    && tmpAddress > 0 && tmpAddress < 256) // as CentralStation allowes a maximum of 255 locomotives
                {
                    //ControlUnit controlUnitInstance = new ControlUnit();
                    //controlUnitInstance.SetLocomotiveAddress(tmpAddress);
                    //controlUnits.Add(controlUnitInstance);
                    controlUnits[currentControlUnitInstanceListIndex].SetLocomotiveAddress(tmpAddress);
                    controlUnits[currentControlUnitInstanceListIndex].nameOfInstance = tmpAddress.ToString();

                    tablVw_ControlUnit.ReloadData();
                    UpdateLocomotiveInfos();

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

        void OnEntryTimerElapsed(object o, EventArgs e)
        {
            entryTimer.Stop();

            //only set lbl, for nothing else has changed
            sevenSegString = "";
            sevenSegString = sevenSegStringPrevious;
            lbl_address.Text = sevenSegString; //TODO: Why is this not working?
        }

        private void UpdateLocomotiveInfos()
        {
            // update address
            if (controlUnits[currentControlUnitInstanceListIndex].GetLocomotiveAddress() < 10)
            {
                lbl_address.Text = "00" + controlUnits[currentControlUnitInstanceListIndex].GetLocomotiveAddress().ToString();
            }
            else if (controlUnits[currentControlUnitInstanceListIndex].GetLocomotiveAddress() < 100)
            {
                lbl_address.Text = "0" + controlUnits[currentControlUnitInstanceListIndex].GetLocomotiveAddress().ToString();
            }
            else
            {
                lbl_address.Text = controlUnits[currentControlUnitInstanceListIndex].GetLocomotiveAddress().ToString();
            }

            // update protocol indicator
            switch (controlUnits[currentControlUnitInstanceListIndex].GetLocomotiveProtocol())
            {
                case Locomotive.e_DecoderType.MM:
                    btn_protocol.SetTitle("MM", UIControlState.Normal);
                    break;

                case Locomotive.e_DecoderType.DCC:
                    btn_protocol.SetTitle("DCC", UIControlState.Normal);
                    break;

                case Locomotive.e_DecoderType.MFX:
                    btn_protocol.SetTitle("mfx", UIControlState.Normal);
                    break;
            }

            // update direction indicator
            if (controlUnits[currentControlUnitInstanceListIndex].GetLocomotiveDirection() == Locomotive.e_Direction.Forwards)
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
            int tmpSpeed = controlUnits[currentControlUnitInstanceListIndex].GetLocomotiveSpeed();
            sld_speed.Value = tmpSpeed;
            knob_Img.Transform = CGAffineTransform.MakeRotation((float)tmpSpeed / 65);
            View.AddSubview(knob_Img);

            // set function state indicator
            led_function_img.Hidden = !controlUnits[currentControlUnitInstanceListIndex].GetLocomotiveFunctionState(0);
            led_f1_img.Hidden = !controlUnits[currentControlUnitInstanceListIndex].GetLocomotiveFunctionState(1);
            led_f2_img.Hidden = !controlUnits[currentControlUnitInstanceListIndex].GetLocomotiveFunctionState(2);
            led_f3_img.Hidden = !controlUnits[currentControlUnitInstanceListIndex].GetLocomotiveFunctionState(3);
            led_f4_img.Hidden = !controlUnits[currentControlUnitInstanceListIndex].GetLocomotiveFunctionState(4);

            // set track state
            //led_Img.Hidden = !CentralStation.GetTrackPowerState(); //TODO: Implement function by read back from Central Station
        }



    }
}