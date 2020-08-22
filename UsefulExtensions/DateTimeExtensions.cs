using System;
using System.Collections.Generic;
using System.Text;

namespace UsefulExtensions
{
    /// <summary>
    /// Useful DateTime Extensions
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Contains periods of time in seconds
        /// </summary>
        public struct SecondsTimeStruct
        {
            public const double Minute = 60;
            public const double Hour = Minute * 60;
            public const double Day = Hour * 24;
            public const double Week = Day * 7;
            public const double Month = Day * 30;
            public const double Year = Month * 12;
        }

        /// <summary>
        /// Indicates when this datetime instance is between a specified dtStart and dtEnd.
        /// </summary>
        /// <param name="dt">This datetime instance.</param>
        /// <param name="dtStart">The start date to compare.</param>
        /// <param name="dtEnd">The end date to compare.</param>
        /// <returns>True if is between the specified dates, and false if is not.</returns>
        public static bool IsBetween(this DateTime dt, DateTime dtStart, DateTime dtEnd)
        {
            return dt.Ticks >= dtStart.Ticks && dt.Ticks <= dtEnd.Ticks;
        }

        /// <summary>
        /// Indicates when this datetime instance is between a specified dtStart and dtEnd.
        /// </summary>
        /// <param name="dt">This datetime instance.</param>
        /// <param name="dtStart">The start date to compare.</param>
        /// <param name="dtEnd">The end date to compare.</param>
        /// <returns>True if is between the specified dates, and false if is not.</returns>
        public static bool IsBetween(this DateTime? dt, DateTime? dtStart, DateTime? dtEnd)
        {
            return dt.Value.Ticks >= dtStart.Value.Ticks && dt.Value.Ticks <= dtEnd.Value.Ticks;
        }

        /// <summary>
        /// Returns a string that describes this datetime instance in a readable way.
        /// </summary>
        /// <param name="dt">This datetime instance.</param>
        /// <returns></returns>
        public static string ToReadableTime(this DateTime dt)
        {
            var ts = new TimeSpan(DateTime.UtcNow.Ticks - dt.Ticks);
            double delta = ts.TotalSeconds;

            if (delta < SecondsTimeStruct.Minute)
            {
                return ts.Seconds <= 1 ? "one second ago" : ts.Seconds + " seconds ago";
            }
            if (delta < SecondsTimeStruct.Hour)
            {
                return ts.Minutes <= 1 ? "a minute ago" : ts.Minutes + " minutes ago";
            }
            if (delta < SecondsTimeStruct.Day)
            {
                return ts.Hours <= 1 ? "an hour ago" : ts.Hours + " hours ago";
            }
            if (delta < SecondsTimeStruct.Week)
            {
                return ts.Days <= 1 ? "yesterday" : ts.Days + " days ago";
            }
            if (delta < SecondsTimeStruct.Month)
            {
                var weeks = Math.Truncate((double)ts.Days / 7);
                return weeks <= 1 ? "a week ago" : weeks + " week ago";
            }
            if (delta < SecondsTimeStruct.Year)
            {
                var months = Math.Truncate((double)ts.Days / 30);
                return months <= 1 ? "a month ago" : months + " months ago";
            }

            var years = Math.Truncate((double)ts.Days / 365);
            return years <= 1 ? "a year ago" : years + " years ago";
        }

        /// <summary>
        /// Returns a string that describes this datetime instance in a readable way.
        /// </summary>
        /// <param name="dt">This datetime instance.</param>
        /// <returns></returns>
        public static string ToReadableTime(this DateTime? dt)
        {
            if (dt == null) return null;

            var ts = new TimeSpan(DateTime.UtcNow.Ticks - dt.ConvertTo<DateTime>().Ticks);
            double delta = ts.TotalSeconds;

            if (delta < SecondsTimeStruct.Minute)
            {
                return ts.Seconds <= 1 ? "one second ago" : ts.Seconds + " seconds ago";
            }
            if (delta < SecondsTimeStruct.Hour)
            {
                return ts.Minutes <= 1 ? "a minute ago" : ts.Minutes + " minutes ago";
            }
            if (delta < SecondsTimeStruct.Day)
            {
                return ts.Hours <= 1 ? "an hour ago" : ts.Hours + " hours ago";
            }
            if (delta < SecondsTimeStruct.Week)
            {
                return ts.Days <= 1 ? "yesterday" : ts.Days + " days ago";
            }
            if (delta < SecondsTimeStruct.Month)
            {
                var weeks = Math.Truncate((double)ts.Days / 7);
                return weeks <= 1 ? "a week ago" : weeks + " week ago";
            }
            if (delta < SecondsTimeStruct.Year)
            {
                var months = Math.Truncate((double)ts.Days / 30);
                return months <= 1 ? "a month ago" : months + " months ago";
            }

            var years = Math.Truncate((double)ts.Days / 365);
            return years <= 1 ? "a year ago" : years + " years ago";
        }

        /// <summary>
        /// Indicates if this datetime instance is a work day.
        /// </summary>
        /// <param name="dt">This datetime instance.</param>
        /// <returns></returns>
        public static bool IsWorkDay(this DateTime dt)
        {
            return dt.DayOfWeek != DayOfWeek.Saturday && dt.DayOfWeek != DayOfWeek.Sunday;
        }

        /// <summary>
        /// Indicates if this datetime instance is a work day.
        /// </summary>
        /// <param name="dt">This datetime instance.</param>
        /// <returns></returns>
        public static bool IsWorkDay(this DateTime? dt)
        {
            return dt != null && dt.ConvertTo<DateTime>().DayOfWeek != DayOfWeek.Saturday && dt.ConvertTo<DateTime>().DayOfWeek != DayOfWeek.Sunday;
        }

        /// <summary>
        /// Indicates if this datetime instance is a weekend day.
        /// </summary>
        /// <param name="dt">This datetime instance.</param>
        /// <returns></returns>
        public static bool IsWeekend(this DateTime dt)
        {
            return dt.DayOfWeek == DayOfWeek.Saturday || dt.DayOfWeek == DayOfWeek.Sunday;
        }

        /// <summary>
        /// Indicates if this datetime instance is a weekend day.
        /// </summary>
        /// <param name="dt">This datetime instance.</param>
        /// <returns></returns>
        public static bool IsWeekend(this DateTime? dt)
        {
            return dt != null && (dt.ConvertTo<DateTime>().DayOfWeek == DayOfWeek.Saturday || dt.ConvertTo<DateTime>().DayOfWeek == DayOfWeek.Sunday);
        }

        /// <summary>
        /// Returns next work day based on this datetime instance.
        /// </summary>
        /// <param name="dt">This datetime instance</param>
        /// <returns></returns>
        public static DateTime NextWorkday(this DateTime dt)
        {
            var nextDay = dt.AddDays(1);
            while (!nextDay.IsWorkDay())
            {
                nextDay = nextDay.AddDays(1);
            }
            return nextDay;
        }

        /// <summary>
        /// Returns next work day based on this datetime instance. Returns null if this datetime instance is null.
        /// </summary>
        /// <param name="dt">This datetime instance</param>
        /// <returns></returns>
        public static DateTime? NextWorkday(this DateTime? dt)
        {
            if (dt == null) return null;

            var nextDay = dt.ConvertTo<DateTime>().AddDays(1);
            while (!nextDay.IsWorkDay())
            {
                nextDay = nextDay.AddDays(1);
            }
            return nextDay;
        }

        /// <summary>
        /// Returns next weekend day based on this datetime instance.
        /// </summary>
        /// <param name="dt">This datetime instance</param>
        /// <returns></returns>
        public static DateTime NextWeekend(this DateTime dt)
        {
            if (dt.DayOfWeek == DayOfWeek.Saturday) return dt.AddDays(7);

            var nextDay = dt.AddDays(1);
            while (!nextDay.IsWorkDay())
            {
                nextDay = nextDay.AddDays(1);
            }
            return nextDay;
        }

        /// <summary>
        /// Returns next weekend day based on this datetime instance. Returns null if this datetime instance is null.
        /// </summary>
        /// <param name="dt">This datetime instance</param>
        /// <returns></returns>
        public static DateTime? NextWeekend(this DateTime? dt)
        {
            if (dt == null) return null;
            if (dt.ConvertTo<DateTime>().DayOfWeek == DayOfWeek.Saturday) return dt.ConvertTo<DateTime>().AddDays(7);

            var nextDay = dt.ConvertTo<DateTime>().AddDays(1);
            while (!nextDay.IsWorkDay())
            {
                nextDay = nextDay.AddDays(1);
            }
            return nextDay;
        }

        /// <summary>
        /// Returns the diference in years between the current date and this datetime instance.
        /// </summary>
        /// <param name="dt">This datetime instance.</param>
        /// <returns></returns>
        public static int CalculateAge(this DateTime dt)
        {
            return DateTime.Now.Year - dt.Year;
        }

        /// <summary>
        /// Returns the diference in years between the current date and this datetime instance. Returns null if this datetime instance is null.
        /// </summary>
        /// <param name="dt">This datetime instance.</param>
        /// <returns></returns>
        public static int? CalculateAge(this DateTime? dt)
        {
            return dt != null ? DateTime.Now.Year - dt.ConvertTo<DateTime>().Year : (int?)null;
        }

        #region Default extensions that not exists in Nullable Datetime 

        /// <summary>
        /// Returns a new DateTime that adds the specified number of days to the value of this instance.
        /// </summary>
        /// <param name="dt">This DateTime instance.</param>
        /// <param name="value">Number of days. This value can be positive or negative.</param>
        /// <returns></returns>
        public static DateTime? AddDays(this DateTime? dt, double value)
        {
            if (dt == null) return null;
            return dt.ConvertTo<DateTime>().AddDays(value);
        }

        /// <summary>
        /// Returns a new DateTime that adds the specified number of hours to the value of this instance.
        /// </summary>
        /// <param name="dt">This DateTime instance.</param>
        /// <param name="value">Number of hours. This value can be positive or negative.</param>
        /// <returns></returns>
        public static DateTime? AddHours(this DateTime? dt, double value)
        {
            if (dt == null) return null;
            return dt.ConvertTo<DateTime>().AddHours(value);
        }

        /// <summary>
        /// Returns a new DateTime that adds the specified number of milliseconds to the value of this instance.
        /// </summary>
        /// <param name="dt">This DateTime instance.</param>
        /// <param name="value">Number of milliseconds. This value can be positive or negative.</param>
        /// <returns></returns>
        public static DateTime? AddMilliseconds(this DateTime? dt, double value)
        {
            if (dt == null) return null;
            return dt.ConvertTo<DateTime>().AddMilliseconds(value);
        }

        /// <summary>
        /// Returns a new DateTime that adds the specified number of minutes to the value of this instance.
        /// </summary>
        /// <param name="dt">This DateTime instance.</param>
        /// <param name="value">Number of minutes. This value can be positive or negative.</param>
        /// <returns></returns>
        public static DateTime? AddMinutes(this DateTime? dt, double value)
        {
            if (dt == null) return null;
            return dt.ConvertTo<DateTime>().AddMinutes(value);
        }

        /// <summary>
        /// Returns a new DateTime that adds the specified number of months to the value of this instance.
        /// </summary>
        /// <param name="dt">This DateTime instance.</param>
        /// <param name="value">Number of months. This value can be positive or negative.</param>
        /// <returns></returns>
        public static DateTime? AddMonths(this DateTime? dt, int value)
        {
            if (dt == null) return null;
            return dt.ConvertTo<DateTime>().AddMonths(value);
        }

        /// <summary>
        /// Returns a new DateTime that adds the specified number of secounds to the value of this instance.
        /// </summary>
        /// <param name="dt">This DateTime instance.</param>
        /// <param name="value">Number of secounds. This value can be positive or negative.</param>
        /// <returns></returns>
        public static DateTime? AddSeconds(this DateTime? dt, double value)
        {
            if (dt == null) return null;
            return dt.ConvertTo<DateTime>().AddSeconds(value);
        }

        /// <summary>
        /// Returns a new DateTime that adds the specified number of ticks to the value of this instance.
        /// </summary>
        /// <param name="dt">This DateTime instance.</param>
        /// <param name="value">Number of 100-nanoseconds milliseconds. This value can be positive or negative.</param>
        /// <returns></returns>
        public static DateTime? AddTicks(this DateTime? dt, long value)
        {
            if (dt == null) return null;
            return dt.ConvertTo<DateTime>().AddTicks(value);
        }

        /// <summary>
        /// Returns a new DateTime that adds the specified number of years to the value of this instance.
        /// </summary>
        /// <param name="dt">This DateTime instance.</param>
        /// <param name="value">Number of years. This value can be positive or negative.</param>
        /// <returns></returns>
        public static DateTime? AddYears(this DateTime? dt, int value)
        {
            if (dt == null) return null;
            return dt.ConvertTo<DateTime>().AddYears(value);
        }

        #endregion
    }
}
