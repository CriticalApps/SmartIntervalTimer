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
    }
}