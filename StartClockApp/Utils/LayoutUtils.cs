using Android.Views;
using Android.Widget;
using System;

namespace StartClockApp
{
    internal static class LayoutUtils
    {
        internal static ViewGroup.LayoutParams GetLayoutParamsMatchParent()
        {
            return new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent,
                                                   ViewGroup.LayoutParams.MatchParent);
        }

        internal static RelativeLayout.LayoutParams GetRelative(int x, int y, int w, int h)
        {
            RelativeLayout.LayoutParams parameters = new RelativeLayout.LayoutParams(w, h);
            parameters.LeftMargin = x;
            parameters.TopMargin = y;

            return parameters;
        }
    }
}