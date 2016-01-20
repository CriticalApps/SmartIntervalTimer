using System;

namespace StartClockApp
{
    internal static class Sizes
    {
        private const float countDownViewSize = 200;
        public static int CountDownViewSize { get { return GetRealSize(countDownViewSize); } }

        private const float lockButtonSize = 60;
        public static int LockButtonSize { get { return GetRealSize(lockButtonSize); } }

        public static int GetRealSize(float size)
        {
            return (int)(DeviceInfo.Density * size);
        }
    }
}