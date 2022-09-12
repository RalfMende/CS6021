/*
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
using UIKit;

namespace CS6021
{
    //[Register(nameof(UISliderCustom))]
    //[DesignTimeVisible(true)]
    public class UISliderCustom : UISlider
    {

        public UISliderCustom(IntPtr handle) : base(handle)
        {
        }

        public UISliderCustom()
        {
            // Called when created from code.
            Initialize();
        }

        public override void AwakeFromNib()
        {
            // Called when loaded from xib or storyboard.
            Initialize();
        }

        void Initialize()
        {
            // Common initialization code here.

            var longPress = new UILongPressGestureRecognizer(tapAndSlide);
            longPress.MinimumPressDuration = 0;
            //longPress.CancelsTouchesInView = false;
            this.AddGestureRecognizer(longPress);
            this.UserInteractionEnabled = true;

        }

        private void tapAndSlide(UILongPressGestureRecognizer gesture)
        {
            System.Diagnostics.Debug.WriteLine($"{nameof(UISliderCustom)} RecognizerState {gesture.State}");

            // need to propagate events down the chain
            // I imagine iOS does something similar
            // for whatever recogniser on the thumb control
            // It's not enough to set CancelsTouchesInView because
            // if clicking on the track away from the thumb control
            // the thumb gesture recogniser won't pick it up anyway
            switch (gesture.State)
            {
                case UIGestureRecognizerState.Cancelled:
                    this.SendActionForControlEvents(UIControlEvent.TouchCancel);
                    break;

                case UIGestureRecognizerState.Began:
                    this.SendActionForControlEvents(UIControlEvent.TouchDown);
                    break;

                case UIGestureRecognizerState.Changed:
                    this.SendActionForControlEvents(UIControlEvent.ValueChanged);
                    break;

                case UIGestureRecognizerState.Ended:
                    this.SendActionForControlEvents(UIControlEvent.TouchUpInside);
                    break;

                case UIGestureRecognizerState.Failed:
                    //?
                    break;

                case UIGestureRecognizerState.Possible:
                    //?
                    break;

            }

            var pt = gesture.LocationInView(this);
            var thumbWidth = CurrentThumbImage.Size.Width;
            var value = 0f;

            if (pt.X <= thumbWidth / 2)
            {
                value = this.MinValue;
            }
            else if (pt.X >= this.Bounds.Size.Width - thumbWidth / 2)
            {
                value = this.MaxValue;
            }
            else
            {
                var percentage = ((pt.X - thumbWidth / 2) / (this.Bounds.Size.Width - thumbWidth));
                var delta = percentage * (this.MaxValue - this.MinValue);
                value = this.MinValue + (float)delta;
            }

            if (gesture.State == UIGestureRecognizerState.Began)
            {
                UIView.Animate(0.35, 0, UIViewAnimationOptions.CurveEaseInOut,
                    () =>
                    {
                        this.SetValue(value, true);
                    },
                    null);
            }
            else
            {
                this.SetValue(value, animated: false);
            }

        }

    }
}
