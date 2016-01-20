using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace StartClockApp
{
	[Activity(Label = "StartClockApp", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        IntervalStarterView contentView;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

			ActionBar.Hide();
			Window.AddFlags (WindowManagerFlags.Fullscreen);
			Window.DecorView.SystemUiVisibility = (StatusBarVisibility)(
				SystemUiFlags.Fullscreen |
				SystemUiFlags.HideNavigation |
				SystemUiFlags.ImmersiveSticky
			);

//			Window.AddFlags(WindowManagerFlags.Fullscreen);
//			this.Window.ClearFlags(WindowManagerFlags.Fullscreen);
            DeviceInfo.Measure(this);

            contentView = new IntervalStarterView(this);
            contentView.Init();
            SetContentView(contentView);
        }

        protected override void OnStart()
        {
            base.OnStart();
//            ActionBar.Hide();

			// needed just once
            CurrentTimeUtls.InitTime();
        }

        protected override void OnStop()
        {
            base.OnStop();
        }
    }
}

