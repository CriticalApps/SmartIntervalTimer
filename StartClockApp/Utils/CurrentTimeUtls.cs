using Android.App;
using System;
using System.Threading.Tasks;

namespace StartClockApp
{
    internal static class CurrentTimeUtls
    {
        private static bool isInitiated;

        public static DateTime LastUpdatedTime { get; set; }
        public static event EventHandler OnTimeUpdated;

        internal async static void UpdateCurrentTime()
        {
            LastUpdatedTime = DateTime.Now.ToLocalTime();
            if (OnTimeUpdated != null)
            {
                OnTimeUpdated(new object(), null);
            }

            await Task.Delay(50);

            UpdateCurrentTime();
        }

        internal static void InitTime()
        {
            if (!isInitiated)
            {
                UpdateCurrentTime();
                isInitiated = true;
            }
        }
    }
}