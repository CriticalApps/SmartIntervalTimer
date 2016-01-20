using Android.App;
using Android.Graphics;
using System;

namespace StartClockApp
{
    internal class CountdownView : UIView
    {
        const int countDownSec = 5;
        const int startIntervalSec = 15;
        DateTime firstStartTime;
        DateTime targetStartTime;

        UILabel countDownLabel;

        string labelText = "test";

        public CountdownView(Activity context) : base(context)
        {

        }

        public void Init()
        {
            firstStartTime = DateTime.Now.ToLocalTime().AddSeconds(10);

            countDownLabel = new UILabel(context);
            countDownLabel.TextColor = Color.Black;
            countDownLabel.Gravity = Android.Views.GravityFlags.Center;
            AddView(countDownLabel);

            CurrentTimeUtls.OnTimeUpdated += HandleOnTimeUpdated;

        }

        public override void LayoutSubviews()
        {
            countDownLabel.Frame = Frame.Bounds;
            countDownLabel.TextSize = (int)(Frame.H / DeviceInfo.Density / 2);
        }

        private void HandleOnTimeUpdated(object sender, EventArgs e)
        {
            if (CurrentTimeUtls.LastUpdatedTime.AddSeconds(countDownSec) >= firstStartTime)
            {
                if (targetStartTime.Ticks == 0)
                {
                    targetStartTime = firstStartTime;
                }
                Console.WriteLine("time: " + CurrentTimeUtls.LastUpdatedTime.ToString("H:mm:ss") + " - " + targetStartTime.ToString("H:mm:ss"));

                if (CurrentTimeUtls.LastUpdatedTime < targetStartTime)
                {
                    var timeInterval = targetStartTime - CurrentTimeUtls.LastUpdatedTime;
                    if (timeInterval.Seconds <= countDownSec)
                    {
                        if (timeInterval.Seconds == 0)
                        {
                            labelText = "0";
                            BackgroundColor = Color.Green;
                        } else
                        {
                            labelText = timeInterval.Seconds.ToString();
                            BackgroundColor = Color.Orange;
                        }
                    } else
                    {
                        labelText = "";
                    }
                }
                else
                {
                    if (CurrentTimeUtls.LastUpdatedTime > targetStartTime.AddSeconds(1))
                    {
                        labelText = "";
                        targetStartTime = targetStartTime.AddSeconds(startIntervalSec);
                        BackgroundColor = Color.Transparent;

                    }
                }
            }
            countDownLabel.Text = labelText;
        }
    }
}