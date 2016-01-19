using Android.Content;
using Android.Views;
using Android.Widget;

namespace StartClockApp
{
    internal class StartEntryRow : LinearLayout
    {
        TextView startNrTextView;
        LinearLayout entryInfoView;


        public StartEntryRow(Context context) : base(context)
        {
        }

        public void Init()
        {
            Orientation = Orientation.Horizontal;
            LayoutParameters = LayoutUtils.GetLayoutParamsMatchParent();
            WeightSum = 100;

            entryInfoView = new LinearLayout(Context);
            entryInfoView.Orientation = Orientation.Vertical;
            entryInfoView.LayoutParameters = new LayoutParams(0, ViewGroup.LayoutParams.MatchParent, 40);

            startNrTextView = new TextView(Context);
        }
    }
}