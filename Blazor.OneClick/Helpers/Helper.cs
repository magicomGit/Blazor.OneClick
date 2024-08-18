namespace Blazor.OneClick.Helpers
{
    public static class Helper
    {
        public static DateTime UtcToLocalTime(DateTime utcTime)
        {
            TimeZoneInfo localZone = TimeZoneInfo.Local;
            DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, localZone);
            return localTime;
        }


        public static string TimeToCountdown(DateTime utcTime)
        {
            var secs = (DateTime.UtcNow - utcTime).TotalSeconds;
            TimeSpan t = TimeSpan.FromSeconds(secs);

            if (secs > 3600)
            {
                return string.Format("{0:D2}h {1:D2}m {2:D2}s ", t.Hours, t.Minutes, t.Seconds);
            }
            else if (secs > 60)
            {
                return string.Format("{1:D2}m {2:D2}s ", t.Hours, t.Minutes, t.Seconds);
            }
            else
            {
                return string.Format("{2:D2}sec ", t.Hours, t.Minutes, t.Seconds);
            }
        }

    }
}
