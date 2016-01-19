using System;
using Android.Widget;
using Android.App;
using Android.Graphics;
using Android.Views;

namespace StartClockApp
{
	public class UIImageButton : ImageButton
	{
		Frame frame;
		Color backgroundColor;
		int imageResource;

		public virtual Frame Frame {
			get {
				if (frame == null) {
					return new Frame ();
				}
				return frame;
			} set {
				frame = value;

				RelativeLayout.LayoutParams parameters = new RelativeLayout.LayoutParams(value.W, value.H);
				parameters.LeftMargin = value.X;
				parameters.TopMargin = value.Y;

				LayoutParameters = parameters;

				LayoutSubviews ();
			}
		}

		public int ImageResource {
			get {
				return imageResource;		
			}
		}

		public virtual Color BackgroundColor {
			get {
				return backgroundColor;
			} set {
				backgroundColor = value;
				SetBackgroundColor (backgroundColor);
			}
		}

		public UIImageButton (Activity context) : base (context)
		{
			BackgroundColor = Color.Transparent;
			SetPadding (0, 0, 0, 0);
		}
			
		public virtual void LayoutSubviews ()
		{

		}

		public override bool OnTouchEvent (MotionEvent e)
		{
			if (e.Action == MotionEventActions.Down) {
				SetColorFilter (Color.Argb (200, 155, 155, 155), PorterDuff.Mode.SrcAtop);
			} else if (e.Action == MotionEventActions.Up || e.Action == MotionEventActions.Cancel) {
				ClearColorFilter ();
			}

			return base.OnTouchEvent (e);
		}

		public override void SetImageResource (int resId)
		{
			base.SetImageResource (resId);
			imageResource = resId;
		}

		public void FitImageToFrame ()
		{
			SetScaleType (ImageView.ScaleType.CenterInside);	
		}
	}
}