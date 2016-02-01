using System;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Widget;

namespace StartClockApp
{
	public class MenuItemView : UITableCell
	{
		public string Text { get; set; }
		public Action ClickAction { get; set; }

		public MenuItemView (Activity context) : base (context)
		{
			
		}

		public void OnClick ()
		{
			if (ClickAction != null) {
				ClickAction ();
			}
		}
	}


	
}