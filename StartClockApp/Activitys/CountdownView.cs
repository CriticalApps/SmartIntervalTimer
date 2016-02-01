using Android.App;
using Android.Graphics;
using System;

namespace StartClockApp
{
    internal sealed class CountdownView : UIView
    {
        const int countDownSec = 5;
        const int startIntervalSec = 15;
        DateTime firstStartTime;
        DateTime targetStartTime;

        UILabel countDownLabel;

		string labelText;

        public CountdownView(Activity context) : base(context)
        {
			countDownLabel = new UILabel(context);
			countDownLabel.TextColor = Color.Black;
			countDownLabel.Gravity = Android.Views.GravityFlags.Center;
			AddView(countDownLabel);
			firstStartTime = DateTime.MinValue;
			targetStartTime = DateTime.MinValue;
        }

		public void Init(int hour, int minute)
        {
			var now = DateTime.Now.ToLocalTime ();
			firstStartTime = new DateTime (now.Year, now.Month, now.Day, hour, minute, 0);
			targetStartTime = DateTime.MinValue;

			labelText = hour + ":" + minute;
			BackgroundColor = Color.LightYellow;

			// FIXME
            CurrentTimeUtls.OnTimeUpdated += HandleOnTimeUpdated;
        }

        public override void LayoutSubviews()
        {
            countDownLabel.Frame = Frame.Bounds;
            countDownLabel.TextSize = (int)(Frame.H / DeviceInfo.Density / 2);
        }

        private void HandleOnTimeUpdated(object sender, EventArgs e)
        {
            if (CurrentTimeUtls.LastUpdatedTime.AddSeconds(countDownSec) >= firstStartTime) {
				if (targetStartTime == DateTime.MinValue) {
                    targetStartTime = firstStartTime;
                }
                Console.WriteLine("time: " + CurrentTimeUtls.LastUpdatedTime.ToString("H:mm:ss") + " - " + targetStartTime.ToString("H:mm:ss"));

				if (CurrentTimeUtls.LastUpdatedTime < targetStartTime.AddSeconds (1)) {
					var timeInterval = targetStartTime.AddSeconds (1) - CurrentTimeUtls.LastUpdatedTime;
					var seconds = timeInterval.Seconds;
					if (seconds <= countDownSec) {
						if (CurrentTimeUtls.LastUpdatedTime >= targetStartTime) {
							seconds = 0;
							BackgroundColor = Color.LightGreen;
						} else {
							BackgroundColor = Color.Orange;
						}
						labelText = seconds.ToString();
                    } else {
                        labelText = "";
                    }
                } else {
					labelText = "";
					targetStartTime = targetStartTime.AddSeconds (startIntervalSec);
					BackgroundColor = Color.Transparent;
                }
            }
            countDownLabel.Text = labelText;
        }
    }
}