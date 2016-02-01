using System;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Widget;
using System.Collections.Generic;
using Android.Views;

namespace StartClockApp
{
	class MenuListAdapter : BaseAdapter<MenuItemInfo>
	{
		readonly List<MenuItemInfo> menuItems;

		Activity context;

		public MenuListAdapter (Activity context, List<MenuItemInfo> itemViewList)
		{
			this.context = context;
			menuItems = itemViewList;
		}

		#region implemented abstract members of BaseAdapter
		public override long GetItemId (int position)
		{
			return position;
		}
		public override Android.Views.View GetView (int position, Android.Views.View convertView, Android.Views.ViewGroup parent)
		{
			MenuItemInfo itemInfo = menuItems [position];
			MenuListCell listCell = convertView as MenuListCell;

			if (listCell == null) {
				listCell = new MenuListCell (context);
				listCell.Frame = new Frame (DeviceInfo.ScreenWidth, Sizes.MenuItemHeight);
				listCell.Click += (sender, e) => {
					if (listCell.ItemInfo != null && listCell.ItemInfo.ClickAction != null) {
						listCell.ItemInfo.ClickAction ();
					}
				};
			}

			listCell.ItemInfo = itemInfo;

			return listCell;
		}
		public override int Count {
			get {
				return menuItems.Count;
			}
		}
		public override MenuItemInfo this [int index] {
			get {
				return menuItems [index];
			}
		}
		#endregion
	}

}