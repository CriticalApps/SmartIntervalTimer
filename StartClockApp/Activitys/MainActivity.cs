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
        StarterView contentView;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);


            //contentView = new StarterView(this);
            //contentView.Init();

            // Creating a new RelativeLayout
            RelativeLayout relativeLayout = new RelativeLayout(this);

            // Defining the RelativeLayout layout parameters.
            // In this case I want to fill its parent
            RelativeLayout.LayoutParams rlp = new RelativeLayout.LayoutParams(
                    ViewGroup.LayoutParams.MatchParent,
                    ViewGroup.LayoutParams.MatchParent);

            // Creating a new TextView
            TextView tv = new TextView(this);
            tv.Text ="Test";

            // Defining the layout parameters of the TextView
            RelativeLayout.LayoutParams lp = new RelativeLayout.LayoutParams(
                    ViewGroup.LayoutParams.WrapContent,
                    ViewGroup.LayoutParams.WrapContent);
            lp.AddRule(LayoutRules.CenterInParent);

            // Setting the parameters on the TextView
            tv.LayoutParameters =lp;

            // Adding the TextView to the RelativeLayout as a child
            relativeLayout.AddView(tv);

            // Setting the RelativeLayout as our content view
            SetContentView(relativeLayout, rlp);
        }
    }
}

