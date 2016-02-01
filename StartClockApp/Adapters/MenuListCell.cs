using System;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Widget;
using System.Collections.Generic;
using Android.Views;

namespace StartClockApp
{
	sealed class MenuListCell : UITableCell
	{
		readonly UILabel label;
		public MenuListCell (Activity context) : base (context)
		{
			label = new UILabel (context);
			label.Gravity = GravityFlags.Center;
			AddView (label);
		}

		public override void LayoutSubviews ()
		{
			label.Frame = Frame.Bounds;
		}

		MenuItemInfo itemInfo;
		public MenuItemInfo ItemInfo {
			get { 
				return itemInfo;
			}
			set { 
				if (value != null) {
					itemInfo = value;
					label.Text = itemInfo.Text;
				}
			}
		}
	}


}