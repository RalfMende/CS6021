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
	public partial class ViewCtrl_Memory : UIViewController
	{
		public List<Memory> memories = new List<Memory>();
		private int currentMemoryInstanceListIndex = 0;

		public ViewCtrl_Memory (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			led_extern_img.Hidden = true;
			led_off_img.Hidden = true;
			led_input_img.Hidden = true;
			led_end_img.Hidden = true;
			led_clear_img.Hidden = true;

			//TODO: Initially put one instance if apps runs for the first time
			memories.Add(new Memory("Hbf"));

			tblVw_Memory.Source = new TableSourceMemory(memories);
			Add(tblVw_Memory);
			((TableSourceMemory)tblVw_Memory.Source).MemorySelected += ViewController_MemorySelected;

			btn_memory_add.Clicked += btn_memory_add_EventHandler;
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}

		/*--------------------------------------------------------------------*/

		void ViewController_MemorySelected(object sender, int currentMemoryListIndex)
		{
			currentMemoryInstanceListIndex = currentMemoryListIndex;
		}

		private void btn_memory_add_EventHandler(object sender, EventArgs args)
		{
			memories.Add(new Memory());
			tblVw_Memory.ReloadData();
		}

		/*--------------------------------------------------------------------*/

		partial void btn_A1_pressed(UIButton sender)
		{
			memories[currentMemoryInstanceListIndex].SetRoute(1);
		}

		partial void btn_A2_pressed(UIButton sender)
		{
			memories[currentMemoryInstanceListIndex].SetRoute(2);
		}

		partial void btn_A3_pressed(UIButton sender)
		{
			memories[currentMemoryInstanceListIndex].SetRoute(3);
		}

		partial void btn_A4_pressed(UIButton sender)
		{
			memories[currentMemoryInstanceListIndex].SetRoute(4);
		}

		partial void btn_A5_pressed(UIButton sender)
		{
			memories[currentMemoryInstanceListIndex].SetRoute(5);
		}

		partial void btn_A6_pressed(UIButton sender)
		{
			memories[currentMemoryInstanceListIndex].SetRoute(6);
		}

		partial void btn_A7_pressed(UIButton sender)
		{
			memories[currentMemoryInstanceListIndex].SetRoute(7);
		}

		partial void btn_A8_pressed(UIButton sender)
		{
			memories[currentMemoryInstanceListIndex].SetRoute(8);
		}

		partial void btn_B1_pressed(UIButton sender)
		{
			memories[currentMemoryInstanceListIndex].SetRoute(9);
		}

		partial void btn_B2_pressed(UIButton sender)
		{
			memories[currentMemoryInstanceListIndex].SetRoute(10);
		}

		partial void btn_B3_pressed(UIButton sender)
		{
			memories[currentMemoryInstanceListIndex].SetRoute(11);
		}

		partial void btn_B4_pressed(UIButton sender)
		{
			memories[currentMemoryInstanceListIndex].SetRoute(12);
		}

		partial void btn_B5_pressed(UIButton sender)
		{
			memories[currentMemoryInstanceListIndex].SetRoute(13);
		}

		partial void btn_B6_pressed(UIButton sender)
		{
			memories[currentMemoryInstanceListIndex].SetRoute(14);
		}

		partial void btn_B7_pressed(UIButton sender)
		{
			memories[currentMemoryInstanceListIndex].SetRoute(15);
		}

		partial void btn_B8_pressed(UIButton sender)
		{
			memories[currentMemoryInstanceListIndex].SetRoute(16);
		}

		partial void btn_C1_pressed(UIButton sender)
		{
			memories[currentMemoryInstanceListIndex].SetRoute(17);
		}

		partial void btn_C2_pressed(UIButton sender)
		{
			memories[currentMemoryInstanceListIndex].SetRoute(18);
		}

		partial void btn_C3_pressed(UIButton sender)
		{
			memories[currentMemoryInstanceListIndex].SetRoute(19);
		}

		partial void btn_C4_pressed(UIButton sender)
		{
			memories[currentMemoryInstanceListIndex].SetRoute(20);
		}

		partial void btn_C5_pressed(UIButton sender)
		{
			memories[currentMemoryInstanceListIndex].SetRoute(21);
		}

		partial void btn_C6_pressed(UIButton sender)
		{
			memories[currentMemoryInstanceListIndex].SetRoute(22);
		}

		partial void btn_C7_pressed(UIButton sender)
		{
			memories[currentMemoryInstanceListIndex].SetRoute(23);
		}

		partial void btn_C8_pressed(UIButton sender)
		{
			memories[currentMemoryInstanceListIndex].SetRoute(24);
		}

		/*--------------------------------------------------------------------*/

		partial void btn_extern_pressed(UIButton sender)
		{
		}

		partial void btn_off_pressed(UIButton sender)
		{
		}

		partial void btn_input_pressed(UIButton sender)
		{
		}

		partial void btn_end_pressed(UIButton sender)
		{
		}

		//partial void btn_edit_pressed(UIButton sender)
		//{
		//}

		partial void btn_clear_pressed(UIButton sender)
		{
		}
	}
}
