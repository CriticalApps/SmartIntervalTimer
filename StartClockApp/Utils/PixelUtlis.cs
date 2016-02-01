using System;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Widget;

namespace StartClockApp
{
	public static class PixelUtlis
	{
		public static int PxToDp (int px, Activity context)
		{
			return (int)(px / context.Resources.DisplayMetrics.Density);
		}

		public static int DpToPx (int dp, Activity context)
		{
			return (int)(dp * context.Resources.DisplayMetrics.Density);
		}
	}


}