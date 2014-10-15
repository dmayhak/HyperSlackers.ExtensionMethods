using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperSlackers.Extensions
{
    public static partial class ExtensionMethods
    {
        /// <summary>
        /// Determines whether the specified value is a weekday.
        /// (from: http://extensionmethod.net/csharp/datetime/addworkdays)
        /// </summary>
        /// <param name="value">The date value.</param>
        /// <returns>
        /// 	<c>true</c> if the specified value is weekday; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsWeekday(this DateTime value)
        {
            return !IsWeekend(value);
        }

        /// <summary>
        /// Determines whether the specified value is a weekend.
        /// (from: http://extensionmethod.net/csharp/datetime/addworkdays)
        /// </summary>
        /// <param name="value">The date value.</param>
        /// <returns>
        /// 	<c>true</c> if the specified value is weekend; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsWeekend(this DateTime value)
        {
            return (value.DayOfWeek == DayOfWeek.Sunday || value.DayOfWeek == DayOfWeek.Saturday);
        }

        /// <summary>
        /// Adds the specified number of work days to the given date.
        /// (from: http://extensionmethod.net/csharp/datetime/addworkdays)
        /// </summary>
        /// <param name="value">The date value.</param>
        /// <param name="days">The number of workdays to add.</param>
        /// <returns></returns>
        public static DateTime AddWorkdays(this DateTime value, int days)
        {
            // start from a weekday
            while (value.IsWeekend())
            {
                value = value.AddDays(1);
            }

            for (int i = 0; i < days; ++i)
            {
                value = value.AddDays(1);

                // skip weekend days
                while (value.IsWeekend())
                {
                    value = value.AddDays(1);
                }
            }

            return value;
        }

        /// <summary>
        /// Returns a DateTime with the time portion set to 0:00:00.0000
        /// </summary>
        /// <param name="value">The date value</param>
        public static DateTime DateOnly(this DateTime value)
        {
            return new DateTime(value.Year, value.Month, value.Day, 0, 0, 0, 0);
        }

        /// <summary>
        /// Returns time elapsed between specified DateTime and now.
        /// </summary>
        /// <param name="value">The date value.</param>
        /// <returns></returns>
        public static TimeSpan ElapsedTime(this DateTime value)
        {
            return DateTime.Now - value;
        }

        /// <summary>
        /// Gets a DateTime representing the first specified day of week in the specified month
        /// </summary>
        /// <param name="value">The date value</param>
        /// <param name="dayOfWeek">The requested day of week</param>
        /// <returns></returns>
        public static DateTime First(this DateTime value, DayOfWeek dayOfWeek)
        {
            DateTime first = value.FirstDayOfMonth();

            if (first.DayOfWeek != dayOfWeek)
            {
                first = first.Next(dayOfWeek);
            }

            return first;
        }

        /// <summary>
        /// Returns the first DateTime of the given week.
        /// </summary>
        /// <param name="value">The DateTime to start from.</param>
        /// <returns></returns>
        public static DateTime FirstDateTimeOfWeek(this DateTime value)
        {
            System.Globalization.DateTimeFormatInfo dateInfo = new System.Globalization.DateTimeFormatInfo();
            DayOfWeek firstDayOfWeek = dateInfo.FirstDayOfWeek;

            return FirstDateTimeOfWeek(value, firstDayOfWeek);
        }

        /// <summary>
        /// Returns the first DateTime of the given week.
        /// </summary>
        /// <param name="value">The DateTime to start from.</param>
        /// <param name="firstDayOfWeek">The first day of week.</param>
        /// <returns></returns>
        public static DateTime FirstDateTimeOfWeek(this DateTime value, DayOfWeek firstDayOfWeek)
        {
            return value.AddDays(-DaysFromFirstDayOfWeek(value.DayOfWeek, firstDayOfWeek)).Truncate(TimeUnit.Day);
        }

        /// <summary>
        /// Gets a DateTime representing the first day in the month of the specified date.
        /// </summary>
        /// <param name="value">The date value</param>
        /// <returns></returns>
        public static DateTime FirstDayOfMonth(this DateTime value)
        {
            return new DateTime(value.Year, value.Month, 1, 0, 0, 0);
        }

        /// <summary>
        /// Gets a DateTime representing the first day in the month following the specified date.
        /// </summary>
        /// <param name="value">The date value</param>
        /// <returns></returns>
        public static DateTime FirstDayOfNextMonth(this DateTime value)
        {
            return new DateTime(value.Year, value.Month, 1, 0, 0, 0).AddMonths(1);
        }

        /// <summary>
        /// Determines whether the specified value is in the future.
        /// </summary>
        /// <param name="value">The date value.</param>
        /// <returns>
        /// 	<c>true</c> if the specified value is in the future; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsFuture(this DateTime value)
        {
            return value > DateTime.Now;
        }

        /// <summary>
        /// Determines whether the specified falls within a leap year.
        /// </summary>
        /// <param name="value">The date value.</param>
        /// <returns>
        /// 	<c>true</c> if the year is a leap year; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsLeapYear(this DateTime value)
        {
            return (System.DateTime.DaysInMonth(value.Year, 2) == 29);
        }

        /// <summary>
        /// Determines whether the specified DateTime is either Null, MinValue, or MaxValue.
        /// </summary>
        /// <param name="value">The DateTime to check</param>
        /// <returns>
        /// 	<c>true</c> if Null, Min, or Max; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNullOrMinMax(this DateTime? value)
        {
            return ((value == null) || (value == DateTime.MinValue) || (value == DateTime.MaxValue));
        }

        /// <summary>
        /// Determines whether the specified DateTime is either Null, MinValue, or MaxValue.
        /// </summary>
        /// <param name="value">The DateTime to check</param>
        /// <returns>
        /// 	<c>true</c> if Null, Min, or Max; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNullOrMinMax(this DateTime value)
        {
            return ((value == null) || (value == DateTime.MinValue) || (value == DateTime.MaxValue));
        }

        /// <summary>
        /// Determines whether the specified value is in the past.
        /// </summary>
        /// <param name="value">The date value.</param>
        /// <returns>
        /// 	<c>true</c> if the specified value is in the past; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsPast(this DateTime value)
        {
            return value < DateTime.Now;
        }

        /// <summary>
        /// Gets a DateTime representing the last specified day of week in the specified month
        /// </summary>
        /// <param name="value">The date value object</param>
        /// <param name="dayOfWeek">The requested day of week</param>
        /// <returns></returns>
        public static DateTime Last(this DateTime value, DayOfWeek dayOfWeek)
        {
            DateTime last = value.LastDayOfMonth();

            return last.AddDays(Math.Abs(dayOfWeek - last.DayOfWeek) * -1);
        }

        /// <summary>
        /// Gets a DateTime representing the last day in the month of the specified date.
        /// </summary>
        /// <param name="value">The date value</param>  
        /// <returns></returns>
        public static DateTime LastDayOfMonth(this DateTime value)
        {
            return new DateTime(value.Year, value.Month, DateTime.DaysInMonth(value.Year, value.Month), 0, 0, 0);
        }

        /// <summary>
        /// Gets a DateTime representing the first specified day of the week 
        /// following the specified date
        /// </summary>
        /// <param name="value">The date value</param>
        /// <param name="dayOfWeek">The requested day of week</param>
        public static DateTime Next(this DateTime value, DayOfWeek dayOfWeek)
        {
            int offsetDays = dayOfWeek - value.DayOfWeek;

            if (offsetDays <= 0)
            {
                offsetDays += 7;
            }

            return value.AddDays(offsetDays);
        }

        /// <summary>
        /// Gets a DateTime representing the first specified day of the week 
        /// preceding the specified date
        /// </summary>
        /// <param name="value">The date value</param>
        /// <param name="dayOfWeek">The requested day of week</param>
        public static DateTime Prior(this DateTime value, DayOfWeek dayOfWeek)
        {
            int offsetDays = dayOfWeek - value.DayOfWeek;

            if (offsetDays >= 0)
            {
                offsetDays -= 7;
            }

            return value.AddDays(offsetDays);
        }

        /// <summary>
        /// Returns an integer specifying which quarter a date belongs to.
        /// </summary>
        /// <param name="value">The date to check</param>
        /// <returns></returns>
        public static int Quarter(this DateTime value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            int month = value.Month;

            if (month < 4)
            {
                return 1;
            }
            else if (month < 7)
            {
                return 2;
            }
            else if (month < 10)
            {
                return 3;
            }
            else // if (month < 13)
            {
                return 4;
            }
        }

        /// <summary>
        /// Truncates the specified date time to the unit specified.
        /// </summary>
        /// <param name="value">The date value</param>
        /// <param name="truncateTo">The time unit to truncate to</param>
        /// <returns></returns>
        public static DateTime Truncate(this DateTime value, TimeUnit truncateTo)
        {
            switch (truncateTo)
            {
                case TimeUnit.Second:
                    return new DateTime(value.Year, value.Month, value.Day, value.Hour, value.Minute, value.Second);
                case TimeUnit.Minute:
                    return new DateTime(value.Year, value.Month, value.Day, value.Hour, value.Minute, 0);
                case TimeUnit.Hour:
                    return new DateTime(value.Year, value.Month, value.Day, value.Hour, 0, 0);
                case TimeUnit.Day:
                    return new DateTime(value.Year, value.Month, value.Day, 0, 0, 0);
                case TimeUnit.Month:
                    return new DateTime(value.Year, value.Month, 1, 0, 0, 0);
                case TimeUnit.Year:
                    return new DateTime(value.Year, 1, 1, 0, 0, 0);
                default:
                    throw new ArgumentException("Invalid parameter specified.", "truncateTo");
            }
        }

        /// <summary>
        /// Returns the week of the year for the specified DateTime.
        /// </summary>
        /// <param name="value">The DateTime to check</param>
        /// <param name="weekRule">The week rule</param>
        /// <param name="firstDayOfWeek">The first day of week</param>
        /// <returns></returns>
        public static int WeekOfYear(this DateTime value, System.Globalization.CalendarWeekRule weekRule, DayOfWeek firstDayOfWeek)
        {
            System.Globalization.CultureInfo ci = System.Globalization.CultureInfo.CurrentCulture;

            return ci.Calendar.GetWeekOfYear(value, weekRule, firstDayOfWeek);
        }

        /// <summary>
        /// Returns the week of the year for the specified DateTime.
        /// </summary>
        /// <param name="value">The DateTime to check</param>
        /// <param name="firstDayOfWeek">The first day of week</param>
        /// <returns></returns>
        public static int WeekOfYear(this DateTime value, DayOfWeek firstDayOfWeek)
        {
            System.Globalization.DateTimeFormatInfo dateInfo = new System.Globalization.DateTimeFormatInfo();
            System.Globalization.CalendarWeekRule weekRule = dateInfo.CalendarWeekRule;

            return WeekOfYear(value, weekRule, firstDayOfWeek);
        }

        /// <summary>
        /// Returns the week of the year for the specified DateTime.
        /// </summary>
        /// <param name="value">The DateTime to check</param>
        /// <param name="weekRule">The week rule</param>
        /// <returns></returns>
        public static int WeekOfYear(this DateTime value, System.Globalization.CalendarWeekRule weekRule)
        {
            System.Globalization.DateTimeFormatInfo dateInfo = new System.Globalization.DateTimeFormatInfo();
            DayOfWeek firstDayOfWeek = dateInfo.FirstDayOfWeek;

            return WeekOfYear(value, weekRule, firstDayOfWeek);
        }

        /// <summary>
        /// Returns the week of the year for the specified DateTime.
        /// </summary>
        /// <param name="value">The DateTime to check</param>
        /// <returns></returns>
        public static int WeekOfYear(this DateTime value)
        {
            System.Globalization.DateTimeFormatInfo dateInfo = new System.Globalization.DateTimeFormatInfo();
            System.Globalization.CalendarWeekRule weekRule = dateInfo.CalendarWeekRule;
            DayOfWeek firstDayOfWeek = dateInfo.FirstDayOfWeek;

            return WeekOfYear(value, weekRule, firstDayOfWeek);
        }

        /// <summary>
        /// Sets the time on the specified date.
        /// </summary>
        /// <param name="value">The date value</param>
        /// <param name="hour">Hours</param>
        /// <param name="minute">Minutes</param>
        public static DateTime WithTime(this DateTime value, int hour, int minute)
        {
            Contract.Requires<ArgumentOutOfRangeException>(hour >= 0 && hour <= 24);
            Contract.Requires<ArgumentOutOfRangeException>(minute >= 0 && minute <= 60);

            return WithTime(value, hour, minute, 0, 0);
        }

        /// <summary>
        /// Sets the time of the specified date.
        /// </summary>
        /// <param name="value">The date value</param>
        /// <param name="hour">Hours</param>
        /// <param name="minute">Minutes</param>
        /// <param name="second">Seconds</param>
        /// <returns></returns>
        public static DateTime WithTime(this DateTime value, int hour, int minute, int second)
        {
            Contract.Requires<ArgumentOutOfRangeException>(hour >= 0 && hour <= 24);
            Contract.Requires<ArgumentOutOfRangeException>(minute >= 0 && minute <= 60);
            Contract.Requires<ArgumentOutOfRangeException>(second >= 0 && second <= 60);

            return WithTime(value, hour, minute, second, 0);
        }

        /// <summary>
        /// Sets the time of the specified date.
        /// </summary>
        /// <param name="value">The date value</param>
        /// <param name="hour">Hours</param>
        /// <param name="minute">Minutes</param>
        /// <param name="second">Seconds</param>
        /// <param name="millisecond">Milliseconds</param>
        /// <returns></returns>
        public static DateTime WithTime(this DateTime value, int hour, int minute, int second, int millisecond)
        {
            Contract.Requires<ArgumentOutOfRangeException>(hour >= 0 && hour <= 24);
            Contract.Requires<ArgumentOutOfRangeException>(minute >= 0 && minute <= 60);
            Contract.Requires<ArgumentOutOfRangeException>(second >= 0 && second <= 60);
            Contract.Requires<ArgumentOutOfRangeException>(millisecond >= 0 && millisecond < 1000);

            return new DateTime(value.Year, value.Month, value.Day, hour, minute, second, millisecond);
        }

        /// <summary>
        /// Returns number of days from the first day of the week.
        /// </summary>
        /// <param name="value">The current.</param>
        /// <param name="firstDayOfWeek">The first day of week.</param>
        /// <returns></returns>
        private static int DaysFromFirstDayOfWeek(DayOfWeek value, DayOfWeek firstDayOfWeek = DayOfWeek.Sunday)
        {
            //Sunday = 0,Monday = 1,...,Saturday = 6
            int days = value - firstDayOfWeek;

            if (days < 0)
            {
                days = 7 + days;
            }

            return days;
        }

        /// <summary>
        /// Converts a System.DateTime object to Unix timestamp
        /// from http://stackoverflow.com/questions/271398/what-are-your-favorite-extension-methods-for-c-codeplex-com-extensionoverflow?page=3&tab=votes#tab-top
        /// </summary>
        /// <returns>The Unix timestamp</returns>
        public static long ToUnixTimestamp(this DateTime date)
        {
            DateTime unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0);
            TimeSpan unixTimeSpan = date - unixEpoch;

            return (long)unixTimeSpan.TotalSeconds;
        }

        /// <summary>
        /// Converts a unix timestamp to a DateTime.
        /// from http://stackoverflow.com/questions/271398/what-are-your-favorite-extension-methods-for-c-codeplex-com-extensionoverflow?page=3&tab=votes#tab-top
        /// </summary>
        /// <param name="timestamp">The timestamp.</param>
        /// <returns></returns>
        public static DateTime ToDateTimeFromUnixTimestamp(this long timestamp)
        {
            return new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds(timestamp);
        }

        /// <summary>
        /// Converts iso8601 formatted date time to DateTime.
        /// from http://stackoverflow.com/questions/271398/what-are-your-favorite-extension-methods-for-c-codeplex-com-extensionoverflow?page=3&tab=votes#tab-top
        /// </summary>
        /// <param name="iso8601DateTime">The iso8601 date time.</param>
        /// <returns></returns>
        public static DateTime ToDateTimeFromIso8601FormattedDateTime(this string iso8601DateTime)
        {
            return DateTime.ParseExact(iso8601DateTime, "o", System.Globalization.CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Converts DateTime to an iso8601 formatted date time.
        /// from http://stackoverflow.com/questions/271398/what-are-your-favorite-extension-methods-for-c-codeplex-com-extensionoverflow?page=3&tab=votes#tab-top
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <returns></returns>
        public static string ToIso8601FormattedDateTime(this DateTime dateTime)
        {
            return dateTime.ToString("o");
        }
    }
}
