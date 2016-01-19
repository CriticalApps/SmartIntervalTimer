using System;
using Android.Widget;
using Android.Graphics;
using Android.App;
using Android.Views;
using Android.Util;
using Android.Views.InputMethods;

namespace StartClockApp
{
	public class UITextField : EditText
	{
		public const string InputMethod = "input_method";

		const int NONE = 0;

		Frame frame;
		Color color;
		Color backgroundColor;
		Font font;

		public EventHandler<EventArgs> HardCancel;

		public EventHandler<EventArgs> WillShowKeyboard;

		public bool HasPaddingBeenModified {
			get {
				return PaddingLeft == 0;		
			}
		}

		public Frame Frame {
			get {
				return frame;
			}
			set {
				frame = value;
				LayoutParameters = LayoutUtils.GetRelative (frame.X, frame.Y, frame.W, frame.H);

				if (!HasPaddingBeenModified) {
					SetPadding (frame.H / 5, NONE, NONE, NONE);
				}

				LayoutSubviews ();
			}
		}

		public Color TextColor {
			get {
				return color;
			}
			set {
				color = value;
				SetTextColor (color);
			}
		}

		public Color BackgroundColor {
			get {
				return backgroundColor;
			}
			set {
				backgroundColor = value;
				SetBackgroundColor (backgroundColor);
			}
		}

		public Font Font {
			get {
				return font;
			}
			set {
				font = value;
				if (font.Bold) {
					SetTypeface (Typeface.Create (font.Name, TypefaceStyle.Bold), TypefaceStyle.Bold);
				} else {
					SetTypeface (Typeface.Create (font.Name, TypefaceStyle.Normal), TypefaceStyle.Normal);
				}

				SetTextSize (ComplexUnitType.Px, font.Size);
			}
		}

		Activity context;

		public UITextField (Activity context) : base (context)
		{
			this.context = context;

			BackgroundColor = Color.Transparent;

			Gravity = GravityFlags.CenterVertical;
		}

		public virtual void LayoutSubviews ()
		{
			
		}

		public virtual void Hide ()
		{
			Visibility = ViewStates.Gone;
		}

		public override bool OnKeyPreIme (Keycode keyCode, KeyEvent e)
		{
			var handler = HardCancel;

			if (handler != null) {
				handler (this, new EventArgs ());
				return true;
			}

			return base.OnKeyPreIme (keyCode, e);
		}

		public virtual void Show ()
		{
			Visibility = ViewStates.Visible;
		}

		public void ShowKeyboard ()
		{
			InputMethodManager manager = (InputMethodManager)context.GetSystemService (InputMethod);
			manager.ShowSoftInput (this, ShowFlags.Implicit);
		}

		public void HideKeyboard ()
		{
			InputMethodManager manager = (InputMethodManager)context.GetSystemService (InputMethod);
			manager.HideSoftInputFromWindow (this.WindowToken, 0);
		}

		protected override void OnTextChanged (Java.Lang.ICharSequence text, int start, int lengthBefore, int lengthAfter)
		{
			base.OnTextChanged (text, start, lengthBefore, lengthAfter);
		}

	}
}
