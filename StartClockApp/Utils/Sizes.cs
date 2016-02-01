using System;

namespace StartClockApp
{
    internal static class Sizes
    {
		private const int countDownViewSize = 200;
        public static int CountDownViewSize { get { return GetRealSize(countDownViewSize); } }

        private const int lockButtonSize = 60;
        public static int LockButtonSize { get { return GetRealSize(lockButtonSize); } }

		private const int menuItemHeight = 70;
		public static int MenuItemHeight { get { return GetRealSize(menuItemHeight); } }

        public static int GetRealSize(float size)
        {
            return (int)(DeviceInfo.Density * size);
        }
    }
}