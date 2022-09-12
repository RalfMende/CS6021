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
using Foundation;
using UIKit;
using HardwareControllers;
using Internal;

namespace CS6021
{
	public partial class ViewCtrl_Keyboard : UIViewController
	{
		public List<Keyboard> keyboards = new List<Keyboard>();
		private int currentKeyboardInstanceListIndex = 0;

		public ViewCtrl_Keyboard(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

            //TODO: Initially put one instance only, if you run the app for the first time, then get it stored data
            keyboards.Add(new Keyboard("1-16", 1));
			UpdateGui();
            keyboards.Add(new Keyboard("17-32", 17));
			UpdateGui();

            tblVw_Keyboard.Source = new TableSourceKeyboard(keyboards);
			Add(tblVw_Keyboard);
			((TableSourceKeyboard)tblVw_Keyboard.Source).KeyboardSelected += ViewController_KeyboardSelected;

			btn_keyboard_add.Clicked += btn_keyboard_add_EventHandler;
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}

		/*--------------------------------------------------------------------*/

		void ViewController_KeyboardSelected(object sender, int currentKeyboardListIndex)
		{
			currentKeyboardInstanceListIndex = currentKeyboardListIndex;
            UpdateGui();
        }

        private void btn_keyboard_add_EventHandler(object sender, EventArgs args)
		{
			keyboards.Add(new Keyboard());
			UpdateGui();
            tblVw_Keyboard.ReloadData();
		}

		/*--------------------------------------------------------------------*/

		partial void btn_1_green_pressed(UIButton sender)
		{
			keyboards[currentKeyboardInstanceListIndex].SetAccessoryState(1, Accessory.e_Position.on_green_stright_hp1);
		}

		partial void btn_1_red_pressed(UIButton sender)
		{
			keyboards[currentKeyboardInstanceListIndex].SetAccessoryState(1, Accessory.e_Position.off_round_red_right_hp0);
		}

		partial void btn_2_green_pressed(UIButton sender)
		{
			keyboards[currentKeyboardInstanceListIndex].SetAccessoryState(2, Accessory.e_Position.on_green_stright_hp1);
		}

		partial void btn_2_red_pressed(UIButton sender)
		{
			keyboards[currentKeyboardInstanceListIndex].SetAccessoryState(2, Accessory.e_Position.off_round_red_right_hp0);
		}

		partial void btn_3_green_pressed(UIButton sender)
		{
			keyboards[currentKeyboardInstanceListIndex].SetAccessoryState(3, Accessory.e_Position.on_green_stright_hp1);
		}

		partial void btn_3_red_pressed(UIButton sender)
		{
			keyboards[currentKeyboardInstanceListIndex].SetAccessoryState(3, Accessory.e_Position.off_round_red_right_hp0);
		}

		partial void btn_4_green_pressed(UIButton sender)
		{
			keyboards[currentKeyboardInstanceListIndex].SetAccessoryState(4, Accessory.e_Position.on_green_stright_hp1);
		}

		partial void btn_4_red_pressed(UIButton sender)
		{
			keyboards[currentKeyboardInstanceListIndex].SetAccessoryState(4, Accessory.e_Position.off_round_red_right_hp0);
		}

		partial void btn_5_green_pressed(UIButton sender)
		{
			keyboards[currentKeyboardInstanceListIndex].SetAccessoryState(5, Accessory.e_Position.on_green_stright_hp1);
		}

		partial void btn_5_red_pressed(UIButton sender)
		{
			keyboards[currentKeyboardInstanceListIndex].SetAccessoryState(5, Accessory.e_Position.off_round_red_right_hp0);
		}

		partial void btn_6_green_pressed(UIButton sender)
		{
			keyboards[currentKeyboardInstanceListIndex].SetAccessoryState(6, Accessory.e_Position.on_green_stright_hp1);
		}

		partial void btn_6_red_pressed(UIButton sender)
		{
			keyboards[currentKeyboardInstanceListIndex].SetAccessoryState(6, Accessory.e_Position.off_round_red_right_hp0);
		}

		partial void btn_7_green_pressed(UIButton sender)
		{
			keyboards[currentKeyboardInstanceListIndex].SetAccessoryState(7, Accessory.e_Position.on_green_stright_hp1);
		}

		partial void btn_7_red_pressed(UIButton sender)
		{
			keyboards[currentKeyboardInstanceListIndex].SetAccessoryState(7, Accessory.e_Position.off_round_red_right_hp0);
		}

		partial void btn_8_green_pressed(UIButton sender)
		{
			keyboards[currentKeyboardInstanceListIndex].SetAccessoryState(8, Accessory.e_Position.on_green_stright_hp1);
		}

		partial void btn_8_red_pressed(UIButton sender)
		{
			keyboards[currentKeyboardInstanceListIndex].SetAccessoryState(8, Accessory.e_Position.off_round_red_right_hp0);
		}

		partial void btn_9_green_pressed(UIButton sender)
		{
			keyboards[currentKeyboardInstanceListIndex].SetAccessoryState(9, Accessory.e_Position.on_green_stright_hp1);
		}

		partial void btn_9_red_pressed(UIButton sender)
		{
			keyboards[currentKeyboardInstanceListIndex].SetAccessoryState(9, Accessory.e_Position.off_round_red_right_hp0);
		}

		partial void btn_10_green_pressed(UIButton sender)
		{
			keyboards[currentKeyboardInstanceListIndex].SetAccessoryState(10, Accessory.e_Position.on_green_stright_hp1);
		}

		partial void btn_10_red_pressed(UIButton sender)
		{
			keyboards[currentKeyboardInstanceListIndex].SetAccessoryState(10, Accessory.e_Position.off_round_red_right_hp0);
		}

		partial void btn_11_green_pressed(UIButton sender)
		{
			keyboards[currentKeyboardInstanceListIndex].SetAccessoryState(11, Accessory.e_Position.on_green_stright_hp1);
		}

		partial void btn_11_red_pressed(UIButton sender)
		{
			keyboards[currentKeyboardInstanceListIndex].SetAccessoryState(11, Accessory.e_Position.off_round_red_right_hp0);
		}

		partial void btn_12_green_pressed(UIButton sender)
		{
			keyboards[currentKeyboardInstanceListIndex].SetAccessoryState(12, Accessory.e_Position.on_green_stright_hp1);
		}

		partial void btn_12_red_pressed(UIButton sender)
		{
			keyboards[currentKeyboardInstanceListIndex].SetAccessoryState(12, Accessory.e_Position.off_round_red_right_hp0);
		}

		partial void btn_13_green_pressed(UIButton sender)
		{
			keyboards[currentKeyboardInstanceListIndex].SetAccessoryState(13, Accessory.e_Position.on_green_stright_hp1);
		}

		partial void btn_13_red_pressed(UIButton sender)
		{
			keyboards[currentKeyboardInstanceListIndex].SetAccessoryState(13, Accessory.e_Position.off_round_red_right_hp0);
		}

		partial void btn_14_green_pressed(UIButton sender)
		{
			keyboards[currentKeyboardInstanceListIndex].SetAccessoryState(14, Accessory.e_Position.on_green_stright_hp1);
		}

		partial void btn_14_red_pressed(UIButton sender)
		{
			keyboards[currentKeyboardInstanceListIndex].SetAccessoryState(14, Accessory.e_Position.off_round_red_right_hp0);
		}

		partial void btn_15_green_pressed(UIButton sender)
		{
			keyboards[currentKeyboardInstanceListIndex].SetAccessoryState(15, Accessory.e_Position.on_green_stright_hp1);
		}

		partial void btn_15_red_pressed(UIButton sender)
		{
			keyboards[currentKeyboardInstanceListIndex].SetAccessoryState(15, Accessory.e_Position.off_round_red_right_hp0);
		}

		partial void btn_16_green_pressed(UIButton sender)
		{
			keyboards[currentKeyboardInstanceListIndex].SetAccessoryState(16, Accessory.e_Position.on_green_stright_hp1);
		}

		partial void btn_16_red_pressed(UIButton sender)
		{
			keyboards[currentKeyboardInstanceListIndex].SetAccessoryState(16, Accessory.e_Position.off_round_red_right_hp0);
		}

        /*--------------------------------------------------------------------*/

        private void UpdateGui()
		{
			lbl_key_1.Text =  keyboards[currentKeyboardInstanceListIndex].AccessoryStartAddress.ToString();
            lbl_key_2.Text =  (keyboards[currentKeyboardInstanceListIndex].AccessoryStartAddress+1).ToString();
            lbl_key_3.Text =  (keyboards[currentKeyboardInstanceListIndex].AccessoryStartAddress+2).ToString();
            lbl_key_4.Text =  (keyboards[currentKeyboardInstanceListIndex].AccessoryStartAddress+3).ToString();
            lbl_key_5.Text =  (keyboards[currentKeyboardInstanceListIndex].AccessoryStartAddress+4).ToString();
            lbl_key_6.Text =  (keyboards[currentKeyboardInstanceListIndex].AccessoryStartAddress+5).ToString();
            lbl_key_7.Text =  (keyboards[currentKeyboardInstanceListIndex].AccessoryStartAddress+6).ToString();
            lbl_key_8.Text =  (keyboards[currentKeyboardInstanceListIndex].AccessoryStartAddress+7).ToString();
            lbl_key_9.Text =  (keyboards[currentKeyboardInstanceListIndex].AccessoryStartAddress+8).ToString();
            lbl_key_10.Text = (keyboards[currentKeyboardInstanceListIndex].AccessoryStartAddress+9).ToString();
            lbl_key_11.Text = (keyboards[currentKeyboardInstanceListIndex].AccessoryStartAddress+10).ToString();
            lbl_key_12.Text = (keyboards[currentKeyboardInstanceListIndex].AccessoryStartAddress+11).ToString();
            lbl_key_13.Text = (keyboards[currentKeyboardInstanceListIndex].AccessoryStartAddress+12).ToString();
            lbl_key_14.Text = (keyboards[currentKeyboardInstanceListIndex].AccessoryStartAddress+13).ToString();
            lbl_key_15.Text = (keyboards[currentKeyboardInstanceListIndex].AccessoryStartAddress+14).ToString();
            lbl_key_16.Text = (keyboards[currentKeyboardInstanceListIndex].AccessoryStartAddress+15).ToString();
        }
    }
}
