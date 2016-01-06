using System;
using Android.Content;
using Android.Views;
using Android.Widget;
using Android.Graphics;

namespace StartClockApp
{
    internal class StarterView : LinearLayout
    {
        LinearLayout listViewContainer;
        ListView listView;
        LinearLayout bottomContainer;

        public StarterView(Context context) : base(context)
        {
        }

        internal void Init()
        {
            // parent
            LayoutParameters = new LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
            WeightSum = 100;
            Orientation = Orientation.Vertical;
            SetBackgroundColor(Color.Green);

            // listView container
            listViewContainer = new LinearLayout(Context);
            listViewContainer.LayoutParameters = new LayoutParams(ViewGroup.LayoutParams.MatchParent, 0, 50);
            listViewContainer.SetBackgroundColor(Color.Blue);
            AddView(listViewContainer);

            // listView
            listView = new ListView(Context);
            listView.LayoutParameters = LayoutUtils.GetLayoutParamsMatchParent();
            listViewContainer.AddView(listView);

            // bottom container
            bottomContainer = new LinearLayout(Context);
            bottomContainer.LayoutParameters = new LayoutParams(ViewGroup.LayoutParams.MatchParent, 0, 50);
            bottomContainer.SetBackgroundColor(Color.Red);
            AddView(bottomContainer);
        }
    }
}