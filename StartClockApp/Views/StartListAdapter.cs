using System;
using Android.Views;
using Android.Widget;
using Android.Content;
using System.Collections.Generic;

namespace StartClockApp
{
    internal class StartListAdapter : BaseAdapter<StartEntry>
    {
        private List<StartEntry> mItems;
        private Context mContext;

        public StartListAdapter(Context context, List<StartEntry> items)
        {
            mItems = items;
            mContext = context;
        }

        public override StartEntry this[int position]
        {
            get
            {
                return mItems[position];
            }
        }

        public override int Count
        {
            get
            {
                return mItems.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            StartEntryRow row = convertView as StartEntryRow;

            //if (row == null)
            //{
            //    row = 
            //}



            //TextView txtFirstName = row.FindViewById<TextView>(Resource.Id.txtFirstName);
            //txtFirstName.Text = mItems[position].FirstName;

            //TextView txtLastName = row.FindViewById<TextView>(Resource.Id.txtLastName);
            //txtLastName.Text = mItems[position].LastName;

            //TextView txtAge = row.FindViewById<TextView>(Resource.Id.txtAge);
            //txtAge.Text = mItems[position].Age;

            //TextView txtGender = row.FindViewById<TextView>(Resource.Id.txtGender);
            //txtGender.Text = mItems[position].Gender;

            return row;
        }
    }
}