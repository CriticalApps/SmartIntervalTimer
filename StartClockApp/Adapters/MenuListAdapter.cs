using System;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Widget;
using System.Collections.Generic;

namespace StartClockApp
{
	class MenuListAdapter : BaseAdapter<MenuItemView>
	{
		readonly List<MenuItemView> menuItems;

		Activity context;

		public MenuListAdapter (Activity context, List<MenuItemView> itemViewList)
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
			MenuItemView menuItem = menuItems [position];
			return menuItem;
		}
		public override int Count {
			get {
				menuItems.Count;
			}
		}
		public override MenuItemView this [int index] {
			get {
				menuItems [index];
			}
		}
		#endregion
	}

}