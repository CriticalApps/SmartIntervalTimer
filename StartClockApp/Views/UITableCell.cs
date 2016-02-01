using System;
using Android.App;
using Android.Widget;

namespace StartClockApp
{
	class UITableCell : UIView
	{
		Frame frame;
		public override Frame Frame {
			get {
				return frame ?? new Frame ();
			}
			set {
				frame = value;
				LayoutParameters = new AbsListView.LayoutParams (Frame.W, Frame.H);

				LayoutSubviews ();
			}
		}

		public UITableCell (Activity context) : base (context)
		{
		}
	}
}