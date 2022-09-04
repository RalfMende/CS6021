// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace CS6021
{
	[Register ("ViewCtrl_Memory")]
	partial class ViewCtrl_Memory
	{
		[Outlet]
		UIKit.UIBarButtonItem btn_memory_add { get; set; }

		[Outlet]
		UIKit.UIImageView led_clear_img { get; set; }

		[Outlet]
		UIKit.UIImageView led_end_img { get; set; }

		[Outlet]
		UIKit.UIImageView led_extern_img { get; set; }

		[Outlet]
		UIKit.UIImageView led_input_img { get; set; }

		[Outlet]
		UIKit.UIImageView led_off_img { get; set; }

		[Outlet]
		UIKit.UITableView tblVw_Memory { get; set; }

		[Action ("btn_A1_pressed:")]
		partial void btn_A1_pressed (UIKit.UIButton sender);

		[Action ("btn_A2_pressed:")]
		partial void btn_A2_pressed (UIKit.UIButton sender);

		[Action ("btn_A3_pressed:")]
		partial void btn_A3_pressed (UIKit.UIButton sender);

		[Action ("btn_A4_pressed:")]
		partial void btn_A4_pressed (UIKit.UIButton sender);

		[Action ("btn_A5_pressed:")]
		partial void btn_A5_pressed (UIKit.UIButton sender);

		[Action ("btn_A6_pressed:")]
		partial void btn_A6_pressed (UIKit.UIButton sender);

		[Action ("btn_A7_pressed:")]
		partial void btn_A7_pressed (UIKit.UIButton sender);

		[Action ("btn_A8_pressed:")]
		partial void btn_A8_pressed (UIKit.UIButton sender);

		[Action ("btn_B1_pressed:")]
		partial void btn_B1_pressed (UIKit.UIButton sender);

		[Action ("btn_B2_pressed:")]
		partial void btn_B2_pressed (UIKit.UIButton sender);

		[Action ("btn_B3_pressed:")]
		partial void btn_B3_pressed (UIKit.UIButton sender);

		[Action ("btn_B4_pressed:")]
		partial void btn_B4_pressed (UIKit.UIButton sender);

		[Action ("btn_B5_pressed:")]
		partial void btn_B5_pressed (UIKit.UIButton sender);

		[Action ("btn_B6_pressed:")]
		partial void btn_B6_pressed (UIKit.UIButton sender);

		[Action ("btn_B7_pressed:")]
		partial void btn_B7_pressed (UIKit.UIButton sender);

		[Action ("btn_B8_pressed:")]
		partial void btn_B8_pressed (UIKit.UIButton sender);

		[Action ("btn_C1_pressed:")]
		partial void btn_C1_pressed (UIKit.UIButton sender);

		[Action ("btn_C2_pressed:")]
		partial void btn_C2_pressed (UIKit.UIButton sender);

		[Action ("btn_C3_pressed:")]
		partial void btn_C3_pressed (UIKit.UIButton sender);

		[Action ("btn_C4_pressed:")]
		partial void btn_C4_pressed (UIKit.UIButton sender);

		[Action ("btn_C5_pressed:")]
		partial void btn_C5_pressed (UIKit.UIButton sender);

		[Action ("btn_C6_pressed:")]
		partial void btn_C6_pressed (UIKit.UIButton sender);

		[Action ("btn_C7_pressed:")]
		partial void btn_C7_pressed (UIKit.UIButton sender);

		[Action ("btn_C8_pressed:")]
		partial void btn_C8_pressed (UIKit.UIButton sender);

		[Action ("btn_clear_pressed:")]
		partial void btn_clear_pressed (UIKit.UIButton sender);

		[Action ("btn_end_pressed:")]
		partial void btn_end_pressed (UIKit.UIButton sender);

		[Action ("btn_extern_pressed:")]
		partial void btn_extern_pressed (UIKit.UIButton sender);

		[Action ("btn_input_pressed:")]
		partial void btn_input_pressed (UIKit.UIButton sender);

		[Action ("btn_off_pressed:")]
		partial void btn_off_pressed (UIKit.UIButton sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (tblVw_Memory != null) {
				tblVw_Memory.Dispose ();
				tblVw_Memory = null;
			}

			if (btn_memory_add != null) {
				btn_memory_add.Dispose ();
				btn_memory_add = null;
			}

			if (led_clear_img != null) {
				led_clear_img.Dispose ();
				led_clear_img = null;
			}

			if (led_end_img != null) {
				led_end_img.Dispose ();
				led_end_img = null;
			}

			if (led_extern_img != null) {
				led_extern_img.Dispose ();
				led_extern_img = null;
			}

			if (led_input_img != null) {
				led_input_img.Dispose ();
				led_input_img = null;
			}

			if (led_off_img != null) {
				led_off_img.Dispose ();
				led_off_img = null;
			}
		}
	}
}
