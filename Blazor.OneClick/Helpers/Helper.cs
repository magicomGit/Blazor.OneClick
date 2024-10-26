using Blazor.OneClick.Constants;
using Microsoft.AspNetCore.Components.Authorization;
using Newtonsoft.Json;

namespace Blazor.OneClick.Helpers
{
    public static class Helper
    {
        public static T GetDeepClone<T>(this T obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            return JsonConvert.DeserializeObject<T>(json);
        }

        public static DateTime UtcToLocalTime(DateTime utcTime)
        {
            TimeZoneInfo localZone = TimeZoneInfo.Local;
            DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, localZone);
            return localTime;
        }

        public static string GetLanguageCode(string name)
        {
            switch (name)
            {
                case "ru-RU":
                    return "ru";
                case "en-US":
                    return "en";
                case "ru":
                    return "ru";
                case "en":
                    return "en";
                default:
                    return "ru";
            }

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

        public static bool CheckIsAdmin(AuthenticationState authState)
        {
            if (authState == null)
            {
                return false;
            }

            if (authState.User.IsInRole(Settings.AdminRole))
            {
                return true;
            }
            return false;
        }

        public static byte[] GetBytes(Stream stream)
        {
            var bytes = new byte[stream.Length];
            stream.Seek(0, SeekOrigin.Begin);
            stream.ReadAsync(bytes, 0, bytes.Length);
            stream.Dispose();
            return bytes;
        }

    }
}
