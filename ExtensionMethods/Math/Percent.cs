using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperSlackers.Extensions
{
    public static partial class ExtensionMethods
    {
        /// <summary>
        /// Returns a percentage of the number
        /// </summary>
        /// <param name="value">The number</param>
        /// <param name="percent">The percent requested</param>
        /// <returns></returns>
        public static decimal Percent(this decimal value, int percent)
        {
            return value * (decimal)percent / 100M;
        }

        /// <summary>
        /// Returns a percentage of the number
        /// </summary>
        /// <param name="value">The number</param>
        /// <param name="percent">The percent requested</param>
        /// <returns></returns>
        public static decimal Percent(this decimal value, decimal percent)
        {
            return value * percent / 100M;
        }

        /// <summary>
        /// Returns a percentage of the number
        /// </summary>
        /// <param name="value">The number</param>
        /// <param name="percent">The percent requested</param>
        /// <returns></returns>
        public static decimal Percent(this decimal value, long percent)
        {
            return value * (decimal)percent / 100M;
        }

        /// <summary>
        /// Returns a percentage of the number
        /// </summary>
        /// <param name="value">The number</param>
        /// <param name="percent">The percent requested</param>
        /// <returns></returns>
        public static decimal Percent(this decimal value, float percent)
        {
            return value * (decimal)percent / 100M;
        }

        /// <summary>
        /// Returns a percentage of the number
        /// </summary>
        /// <param name="value">The number</param>
        /// <param name="percent">The percent requested</param>
        /// <returns></returns>
        public static decimal Percent(this decimal value, double percent)
        {
            return value * (decimal)percent / 100M;
        }

        /// <summary>
        /// Returns a percentage of the number
        /// </summary>
        /// <param name="value">The number</param>
        /// <param name="percent">The percent requested</param>
        /// <returns>The percentage of the specified value</returns>
        public static decimal Percent(this double value, int percent)
        {
            return (decimal)(value * (double)percent / 100D);
        }

        /// <summary>
        /// Returns a percentage of the number
        /// </summary>
        /// <param name="value">The number</param>
        /// <param name="percent">The percent requested</param>
        /// <returns>The percentage of the specified value</returns>
        public static decimal Percent(this double value, decimal percent)
        {
            return (decimal)(value * (double)percent / 100D);
        }

        /// <summary>
        /// Returns a percentage of the number
        /// </summary>
        /// <param name="value">The number</param>
        /// <param name="percent">The percent requested</param>
        /// <returns>The percentage of the specified value</returns>
        public static decimal Percent(this double value, long percent)
        {
            return (decimal)(value * (double)percent / 100D);
        }

        /// <summary>
        /// Returns a percentage of the number
        /// </summary>
        /// <param name="value">The number</param>
        /// <param name="percent">The percent requested</param>
        /// <returns>The percentage of the specified value</returns>
        public static decimal Percent(this double value, float percent)
        {
            return (decimal)(value * (double)percent / 100D);
        }

        /// <summary>
        /// Returns a percentage of the number
        /// </summary>
        /// <param name="value">The number</param>
        /// <param name="percent">The percent requested</param>
        /// <returns>The percentage of the specified value</returns>
        public static decimal Percent(this double value, double percent)
        {
            return (decimal)(value * percent / 100D);
        }

        /// <summary>
        /// Returns a percentage of the number
        /// </summary>
        /// <param name="value">The number</param>
        /// <param name="percent">The percent requested</param>
        /// <returns>
        /// The percent of value
        /// </returns>
        public static decimal Percent(this float value, int percent)
        {
            return (decimal)(value * (float)percent / 100F);
        }

        /// <summary>
        /// Returns a percentage of the number
        /// </summary>
        /// <param name="value">The number</param>
        /// <param name="percent">The percent requested</param>
        /// <returns>
        /// The percent of value
        /// </returns>
        public static decimal Percent(this float value, decimal percent)
        {
            return (decimal)(value * (float)percent / 100F);
        }

        /// <summary>
        /// Returns a percentage of the number
        /// </summary>
        /// <param name="value">The number</param>
        /// <param name="percent">The percent requested</param>
        /// <returns>
        /// The percent of value
        /// </returns>
        public static decimal Percent(this float value, long percent)
        {
            return (decimal)(value * (float)percent / 100F);
        }

        /// <summary>
        /// Returns a percentage of the number
        /// </summary>
        /// <param name="value">The number</param>
        /// <param name="percent">The percent requested</param>
        /// <returns>
        /// The percent of value
        /// </returns>
        public static decimal Percent(this float value, float percent)
        {
            return (decimal)(value * percent / 100F);
        }

        /// <summary>
        /// Returns a percentage of the number
        /// </summary>
        /// <param name="value">The number</param>
        /// <param name="percent">The percent requested</param>
        /// <returns>
        /// The percent of value
        /// </returns>
        public static decimal Percent(this float value, double percent)
        {
            return (decimal)((double)value * percent / 100D);
        }

        /// <summary>
        /// Returns a percentage of the number
        /// </summary>
        /// <param name="value">The number</param>
        /// <param name="percent">The percent requested</param>
        /// <returns>the percent of value</returns>
        public static decimal Percent(this int value, int percent)
        {
            return (decimal)value * (decimal)percent / 100M;
        }

        /// <summary>
        /// Returns a percentage of the number
        /// </summary>
        /// <param name="value">The number</param>
        /// <param name="percent">The percent requested</param>
        /// <returns>the percent of value</returns>
        public static decimal Percent(this int value, decimal percent)
        {
            return (decimal)value * percent / 100M;
        }

        /// <summary>
        /// Returns a percentage of the number
        /// </summary>
        /// <param name="value">The number</param>
        /// <param name="percent">The percent requested</param>
        /// <returns>the percent of value</returns>
        public static decimal Percent(this int value, long percent)
        {
            return (decimal)value * (decimal)percent / 100M;
        }

        /// <summary>
        /// Returns a percentage of the number
        /// </summary>
        /// <param name="value">The number</param>
        /// <param name="percent">The percent requested</param>
        /// <returns>the percent of value</returns>
        public static decimal Percent(this int value, float percent)
        {
            return (decimal)value * (decimal)percent / 100M;
        }

        /// <summary>
        /// Returns a percentage of the number
        /// </summary>
        /// <param name="value">The number</param>
        /// <param name="percent">The percent requested</param>
        /// <returns>the percent of value</returns>
        public static decimal Percent(this int value, double percent)
        {
            return (decimal)value * (decimal)percent / 100M;
        }

        /// <summary>
        /// Returns a percentage of the number
        /// </summary>
        /// <param name="value">The number</param>
        /// <param name="percent">The percent requested</param>
        /// <returns>the percent of value</returns>
        public static decimal Percent(this long value, int percent)
        {
            return (decimal)value * (decimal)percent / 100M;
        }

        /// <summary>
        /// Returns a percentage of the number
        /// </summary>
        /// <param name="value">The number</param>
        /// <param name="percent">The percent requested</param>
        /// <returns>the percent of value</returns>
        public static decimal Percent(this long value, decimal percent)
        {
            return (decimal)value * percent / 100M;
        }

        /// <summary>
        /// Returns a percentage of the number
        /// </summary>
        /// <param name="value">The number</param>
        /// <param name="percent">The percent requested</param>
        /// <returns>the percent of value</returns>
        public static decimal Percent(this long value, long percent)
        {
            return (decimal)value * (decimal)percent / 100M;
        }

        /// <summary>
        /// Returns a percentage of the number
        /// </summary>
        /// <param name="value">The number</param>
        /// <param name="percent">The percent requested</param>
        /// <returns>the percent of value</returns>
        public static decimal Percent(this long value, float percent)
        {
            return (decimal)value * (decimal)percent / 100M;
        }

        /// <summary>
        /// Returns a percentage of the number
        /// </summary>
        /// <param name="value">The number</param>
        /// <param name="percent">The percent requested</param>
        /// <returns>the percent of value</returns>
        public static decimal Percent(this long value, double percent)
        {
            return (decimal)value * (decimal)percent / 100M;
        }
    }
}
