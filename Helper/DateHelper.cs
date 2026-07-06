// Helpers/DateHelper.cs
using System.Globalization;

namespace LandRegistrySystem.Helpers
{
    public static class DateHelper
    {
        private static readonly PersianCalendar PersianCalendar = new();

        public static string ToPersianDateString(this DateTime dateTime)
        {
            return $"{PersianCalendar.GetYear(dateTime)}/{PersianCalendar.GetMonth(dateTime):D2}/{PersianCalendar.GetDayOfMonth(dateTime):D2}";
        }

        public static string ToPersianDateString(this DateTime? dateTime)
        {
            return dateTime.HasValue ? ToPersianDateString(dateTime.Value) : "";
        }
    }
}