using System;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Widget;
using System.Collections.Generic;

namespace StartClockApp
{
    internal class IntervalStarterView : UIView
    {
        CountdownView countDownView;
        ClockView clockView;

        UIImageButton lockButton;
        UIImageButton menuButton;
        UIView btnContainer;

        UIView container;

        UIView menuContainer;
		UIListView menuListView;

		MenuListAdapter menuListAdapter;

		bool isMenuOpen;


        public IntervalStarterView(Activity context) : base (context)
        {
        }

        internal void Init()
        {
            BackgroundColor = Color.AliceBlue;

            countDownView = new CountdownView(context);
            countDownView.Init();

            clockView = new ClockView(context);
            clockView.Init();

            lockButton = new UIImageButton(context);
            lockButton.SetImageResource(Resource.Drawable.@lock);
            lockButton.FitImageToFrame();

            menuButton = new UIImageButton(context);
            menuButton.SetImageResource(Resource.Drawable.menu);
            menuButton.FitImageToFrame();
			menuButton.Click += OnMenuButtonClick;

            btnContainer = new UIView(context);
            btnContainer.AddViews(lockButton, menuButton);

            container = new UIView(context);
            container.AddViews(countDownView, clockView, btnContainer);

            menuContainer = new UIView(context);
			menuContainer.Click += OnMenuButtonClick;
			menuListView = new UIListView (context);
			menuListView.SetBackgroundColor (Color.DarkGray);

			List<MenuItemInfo> menuItemsList = new List<MenuItemInfo>  {
				new MenuItemInfo {
					Text = "Set start time", 
					ClickAction = delegate {
						Console.WriteLine ("# ClickAction");
					}
				}
			};

			menuListAdapter = new MenuListAdapter (context, menuItemsList);
			menuListView.Adapter = menuListAdapter;

			menuContainer.AddView (menuListView);

            AddViews(container, menuContainer);

			Frame = new Frame(DeviceInfo.ScreenWidth, DeviceInfo.RealSize.Y);
        }

        public override void LayoutSubviews()
        {
            int padding = Frame.H / 30;

            container.Frame = new Frame(padding, padding, Frame.W - 2 * padding, Frame.H - 2 * padding);

            countDownView.Frame = new Frame(container.Frame.W, (int)(container.Frame.H * 0.4));

            clockView.Frame = new Frame(0, countDownView.Frame.Bottom + padding, container.Frame.W, container.Frame.H / 5);

            btnContainer.Frame = new Frame(0, clockView.Frame.Bottom + padding, container.Frame.W, container.Frame.H - (clockView.Frame.Bottom + padding));

            lockButton.Frame = new Frame(
                (btnContainer.Frame.W / 2 - Sizes.LockButtonSize) / 2, 
                (btnContainer.Frame.H - Sizes.LockButtonSize) / 2,
                Sizes.LockButtonSize,
                Sizes.LockButtonSize);

            menuButton.Frame = new Frame(
                btnContainer.Frame.W / 2 + (btnContainer.Frame.W / 2 - Sizes.LockButtonSize) / 2,
                (btnContainer.Frame.H - Sizes.LockButtonSize) / 2,
                Sizes.LockButtonSize,
                Sizes.LockButtonSize);


			menuContainer.Frame = new Frame (0, Frame.H, Frame.W, Frame.H);
			int menuListHeight = (int)(menuContainer.Frame.H * 0.25f);
			menuListView.Frame = new Frame (0, menuContainer.Frame.H - menuListHeight, menuContainer.Frame.W, menuListHeight);
        }

		void OnMenuButtonClick (object sender, EventArgs e)
		{
			if (isMenuOpen) {
//				menuContainer.Animate ().TranslationY (Frame.H);
				menuContainer.Frame = new Frame (0, Frame.H, Frame.W, Frame.H);
			} else {
//				menuContainer.Animate ().TranslationY (0);
				menuContainer.Frame = new Frame (0, 0, Frame.W, Frame.H);
			}
			isMenuOpen = !isMenuOpen;
		}
    }
}