// Helpers/PersianDateHelper.cs (کلاس نهایی و کامل)
using System.Globalization;

namespace LandRegistrySystem.Helpers
{
    public static class PersianDateHelper
    {
        private static readonly PersianCalendar PersianCalendar = new();

        // ===== تبدیل میلادی به شمسی =====
        public static string ToPersianDateString(this DateTime dateTime)
        {
            return $"{PersianCalendar.GetYear(dateTime):0000}/" +
                   $"{PersianCalendar.GetMonth(dateTime):00}/" +
                   $"{PersianCalendar.GetDayOfMonth(dateTime):00}";
        }

        public static string ToPersianDateString(this DateTime? dateTime)
        {
            if (dateTime.HasValue)
                return ToPersianDateString(dateTime.Value);
            return "";
        }

        // ===== تبدیل شمسی به میلادی =====
        public static DateTime? ToMiladiDate(string persianDate)
        {
            if (string.IsNullOrWhiteSpace(persianDate))
                return null;

            try
            {
                var parts = persianDate.Split('/');
                if (parts.Length != 3)
                    return null;

                var year = int.Parse(parts[0]);
                var month = int.Parse(parts[1]);
                var day = int.Parse(parts[2]);

                return PersianCalendar.ToDateTime(year, month, day, 0, 0, 0, 0);
            }
            catch
            {
                return null;
            }
        }

        // ===== اعتبارسنجی تاریخ شمسی =====
        public static bool IsValidPersianDate(string persianDate)
        {
            if (string.IsNullOrWhiteSpace(persianDate))
                return false;

            try
            {
                var parts = persianDate.Split('/');
                if (parts.Length != 3)
                    return false;

                var year = int.Parse(parts[0]);
                var month = int.Parse(parts[1]);
                var day = int.Parse(parts[2]);

                if (year < 1300 || year > 1500)
                    return false;
                if (month < 1 || month > 12)
                    return false;
                if (day < 1 || day > 31)
                    return false;

                PersianCalendar.ToDateTime(year, month, day, 0, 0, 0, 0);
                return true;
            }
            catch
            {
                return false;
            }
        }

        // ===== تاریخ امروز به شمسی =====
        public static string TodayPersianDate()
        {
            return DateTime.Now.ToPersianDateString();
        }

        // ===== parse تاریخ شمسی =====
        public static (int Year, int Month, int Day)? ParsePersianDate(string persianDate)
        {
            if (string.IsNullOrWhiteSpace(persianDate))
                return null;

            try
            {
                var parts = persianDate.Split('/');
                if (parts.Length != 3)
                    return null;

                var year = int.Parse(parts[0]);
                var month = int.Parse(parts[1]);
                var day = int.Parse(parts[2]);

                return (year, month, day);
            }
            catch
            {
                return null;
            }
        }
    }
}