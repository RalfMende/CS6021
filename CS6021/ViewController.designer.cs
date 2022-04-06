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
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		UIKit.UIButton btn_direction { get; set; }

		[Outlet]
		UIKit.UIButton btn_direction2 { get; set; }

		[Outlet]
		UIKit.UIButton btn_protocol { get; set; }

		[Outlet]
		UIKit.UIImageView knob_Img { get; set; }

		[Outlet]
		UIKit.UILabel lbl_address { get; set; }

		[Outlet]
		UIKit.UIImageView led_f1_img { get; set; }

		[Outlet]
		UIKit.UIImageView led_f2_img { get; set; }

		[Outlet]
		UIKit.UIImageView led_f3_img { get; set; }

		[Outlet]
		UIKit.UIImageView led_f4_img { get; set; }

		[Outlet]
		UIKit.UIImageView led_function_img { get; set; }

		[Outlet]
		UIKit.UIImageView led_Img { get; set; }

		[Outlet]
		UIKit.UISlider sld_speed { get; set; }

		[Outlet]
		UIKit.UITableView tablVw_locomotives { get; set; }

		[Outlet]
		UIKit.UITextField txt_ipAddress { get; set; }

		[Action ("btn_0_pressed:")]
		partial void btn_0_pressed (UIKit.UIButton sender);

		[Action ("btn_1_pressed:")]
		partial void btn_1_pressed (UIKit.UIButton sender);

		[Action ("btn_2_pressed:")]
		partial void btn_2_pressed (UIKit.UIButton sender);

		[Action ("btn_3_pressed:")]
		partial void btn_3_pressed (UIKit.UIButton sender);

		[Action ("btn_4_pressed:")]
		partial void btn_4_pressed (UIKit.UIButton sender);

		[Action ("btn_5_pressed:")]
		partial void btn_5_pressed (UIKit.UIButton sender);

		[Action ("btn_6_pressed:")]
		partial void btn_6_pressed (UIKit.UIButton sender);

		[Action ("btn_7_pressed:")]
		partial void btn_7_pressed (UIKit.UIButton sender);

		[Action ("btn_8_pressed:")]
		partial void btn_8_pressed (UIKit.UIButton sender);

		[Action ("btn_9_pressed:")]
		partial void btn_9_pressed (UIKit.UIButton sender);

		[Action ("btn_connect_pressed:")]
		partial void btn_connect_pressed (UIKit.UIButton sender);

		[Action ("btn_direction_pressed:")]
		partial void btn_direction_pressed (UIKit.UIButton sender);

		[Action ("btn_F_pressed:")]
		partial void btn_F_pressed (UIKit.UIButton sender);

		[Action ("btn_f1_pressed:")]
		partial void btn_f1_pressed (UIKit.UIButton sender);

		[Action ("btn_f2_pressed:")]
		partial void btn_f2_pressed (UIKit.UIButton sender);

		[Action ("btn_f3_pressed:")]
		partial void btn_f3_pressed (UIKit.UIButton sender);

		[Action ("btn_f4_pressed:")]
		partial void btn_f4_pressed (UIKit.UIButton sender);

		[Action ("btn_function_pressed:")]
		partial void btn_function_pressed (UIKit.UIButton sender);

		[Action ("btn_go_pressed:")]
		partial void btn_go_pressed (UIKit.UIButton sender);

		[Action ("btn_L_pressed:")]
		partial void btn_L_pressed (UIKit.UIButton sender);

		[Action ("btn_off_pressed:")]
		partial void btn_off_pressed (UIKit.UIButton sender);

		[Action ("btn_protocol_pressed:")]
		partial void btn_protocol_pressed (UIKit.UIButton sender);

		[Action ("btn_stop_pressed:")]
		partial void btn_stop_pressed (UIKit.UIButton sender);

		[Action ("sld_speed_value_changed:")]
		partial void sld_speed_value_changed (UIKit.UISlider sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (btn_direction != null) {
				btn_direction.Dispose ();
				btn_direction = null;
			}

			if (btn_direction2 != null) {
				btn_direction2.Dispose ();
				btn_direction2 = null;
			}

			if (btn_protocol != null) {
				btn_protocol.Dispose ();
				btn_protocol = null;
			}

			if (knob_Img != null) {
				knob_Img.Dispose ();
				knob_Img = null;
			}

			if (lbl_address != null) {
				lbl_address.Dispose ();
				lbl_address = null;
			}

			if (led_Img != null) {
				led_Img.Dispose ();
				led_Img = null;
			}

			if (sld_speed != null) {
				sld_speed.Dispose ();
				sld_speed = null;
			}

			if (tablVw_locomotives != null) {
				tablVw_locomotives.Dispose ();
				tablVw_locomotives = null;
			}

			if (txt_ipAddress != null) {
				txt_ipAddress.Dispose ();
				txt_ipAddress = null;
			}

			if (led_function_img != null) {
				led_function_img.Dispose ();
				led_function_img = null;
			}

			if (led_f1_img != null) {
				led_f1_img.Dispose ();
				led_f1_img = null;
			}

			if (led_f2_img != null) {
				led_f2_img.Dispose ();
				led_f2_img = null;
			}

			if (led_f3_img != null) {
				led_f3_img.Dispose ();
				led_f3_img = null;
			}

			if (led_f4_img != null) {
				led_f4_img.Dispose ();
				led_f4_img = null;
			}
		}
	}
}
