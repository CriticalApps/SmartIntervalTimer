using System;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Widget;

namespace StartClockApp
{
    internal class ClockView : UIView
    {
        UILabel clockLabel;

        public ClockView(Activity context) : base(context)
        {
        }

        internal void Init()
        {
            clockLabel = new UILabel(context);
            clockLabel.TextColor = Color.Black;
            clockLabel.Gravity = Android.Views.GravityFlags.Center;
            clockLabel.Text = DateTime.Now.ToLocalTime().ToString("H:mm:ss");
            AddView(clockLabel);
            CurrentTimeUtls.OnTimeUpdated += HandleOnTimeUpdated;
        }

        public override void LayoutSubviews()
        {
            clockLabel.Frame = Frame.Bounds;
            clockLabel.TextSize = (int)(Frame.H / DeviceInfo.Density / 2);
        }

        private void HandleOnTimeUpdated(object sender, EventArgs e)
        {
            clockLabel.Text = CurrentTimeUtls.LastUpdatedTime.ToString("H:mm:ss");
        }
    }


}