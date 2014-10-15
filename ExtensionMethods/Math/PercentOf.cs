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
        /// Returns what percentage of total the given number is.
        /// </summary>
        /// <param name="value">The number</param>
        /// <param name="total">The total</param>
        /// <returns>The result</returns>
        public static decimal PercentOf(this decimal value, int total)
        {
            decimal result = 0;

            if (value > 0 && total > 0)
            {
                result = value / (decimal)total * 100;
            }

            return result;
        }

        /// <summary>
        /// Returns what percentage of total the given number is.
        /// </summary>
        /// <param name="value">The number</param>
        /// <param name="total">The total</param>
        /// <returns>The result</returns>
        public static decimal PercentOf(this decimal value, decimal total)
        {
            decimal result = 0;

            if (value > 0 && total > 0)
            {
                result = value / total * 100;
            }

            return result;
        }

        /// <summary>
        /// Returns what percentage of total the given number is.
        /// </summary>
        /// <param name="value">The number</param>
        /// <param name="total">The total</param>
        /// <returns>The result</returns>
        public static decimal PercentOf(this decimal value, long total)
        {
            decimal result = 0;

            if (value > 0 && total > 0)
            {
                result = value / (decimal)total * 100;
            }

            return result;
        }

        /// <summary>
        /// Returns what percentage of total the given number is.
        /// </summary>
        /// <param name="value">The number</param>
        /// <param name="total">The total</param>
        /// <returns>The result</returns>
        public static decimal PercentOf(this decimal value, float total)
        {
            decimal result = 0;

            if (value > 0 && total > 0)
            {
                result = value / (decimal)total * 100;
            }

            return result;
        }

        /// <summary>
        /// Returns what percentage of total the given number is.
        /// </summary>
        /// <param name="value">The number</param>
        /// <param name="total">The total</param>
        /// <returns>The result</returns>
        public static decimal PercentOf(this decimal value, double total)
        {
            decimal result = 0;

            if (value > 0 && total > 0)
            {
                result = value / (decimal)total * 100;
            }

            return result;
        }

        /// <summary>
        /// Returns what percentage of total the given number is.
        /// </summary>
        /// <param name="value">The number</param>
        /// <param name="total">The total</param>
        /// <returns>What percent value is of total</returns>
        public static decimal PercentOf(this double value, int total)
        {
            double result = 0;

            if (value > 0 && total > 0)
            {
                result = value / (double)total * 100;
            }

            return (decimal)result;
        }

        /// <summary>
        /// Returns what percentage of total the given number is.
        /// </summary>
        /// <param name="value">The number</param>
        /// <param name="total">The total</param>
        /// <returns>What percent value is of total</returns>
        public static decimal PercentOf(this double value, decimal total)
        {
            double result = 0;

            if (value > 0 && total > 0)
            {
                result = value / (double)total * 100;
            }

            return (decimal)result;
        }

        /// <summary>
        /// Returns what percentage of total the given number is.
        /// </summary>
        /// <param name="value">The number</param>
        /// <param name="total">The total</param>
        /// <returns>What percent value is of total</returns>
        public static decimal PercentOf(this double value, long total)
        {
            double result = 0;

            if (value > 0 && total > 0)
            {
                result = value / (double)total * 100;
            }

            return (decimal)result;
        }

        /// <summary>
        /// Returns what percentage of total the given number is.
        /// </summary>
        /// <param name="value">The number</param>
        /// <param name="total">The total</param>
        /// <returns>What percent value is of total</returns>
        public static decimal PercentOf(this double value, float total)
        {
            double result = 0;

            if (value > 0 && total > 0)
            {
                result = value / (double)total * 100;
            }

            return (decimal)result;
        }

        /// <summary>
        /// Returns what percentage of total the given number is.
        /// </summary>
        /// <param name="value">The number</param>
        /// <param name="total">The total</param>
        /// <returns>What percent value is of total</returns>
        public static decimal PercentOf(this double value, double total)
        {
            double result = 0;

            if (value > 0 && total > 0)
            {
                result = value / total * 100;
            }

            return (decimal)result;
        }

        /// <summary>
        /// Returns what percentage of total the given number is.
        /// </summary>
        /// <param name="value">The number</param>
        /// <param name="total">The total</param>
        /// <returns>
        /// The percent value is of total
        /// </returns>
        public static decimal PercentOf(this float value, int total)
        {
            float result = 0;

            if (value > 0 && total > 0)
            {
                result = value / (float)total * 100;
            }

            return (decimal)result;
        }

        /// <summary>
        /// Returns what percentage of total the given number is.
        /// </summary>
        /// <param name="value">The number</param>
        /// <param name="total">The total</param>
        /// <returns>
        /// The percent value is of total
        /// </returns>
        public static decimal PercentOf(this float value, decimal total)
        {
            float result = 0;

            if (value > 0 && total > 0)
            {
                result = value / (float)total * 100;
            }

            return (decimal)result;
        }

        /// <summary>
        /// Returns what percentage of total the given number is.
        /// </summary>
        /// <param name="value">The number</param>
        /// <param name="total">The total</param>
        /// <returns>
        /// The percent value is of total
        /// </returns>
        public static decimal PercentOf(this float value, long total)
        {
            float result = 0;

            if (value > 0 && total > 0)
            {
                result = value / (float)total * 100;
            }

            return (decimal)result;
        }

        /// <summary>
        /// Returns what percentage of total the given number is.
        /// </summary>
        /// <param name="value">The number</param>
        /// <param name="total">The total</param>
        /// <returns>
        /// The percent value is of total
        /// </returns>
        public static decimal PercentOf(this float value, float total)
        {
            float result = 0;

            if (value > 0 && total > 0)
            {
                result = value / (float)total * 100;
            }

            return (decimal)result;
        }

        /// <summary>
        /// Returns what percentage of total the given number is.
        /// </summary>
        /// <param name="value">The number</param>
        /// <param name="total">The total</param>
        /// <returns>
        /// The percent value is of total
        /// </returns>
        public static decimal PercentOf(this float value, double total)
        {
            double result = 0;

            if (value > 0 && total > 0)
            {
                result = (double)value / total * 100;
            }

            return (decimal)result;
        }

        /// <summary>
        /// Returns what percentage of total the given number is.
        /// </summary>
        /// <param name="value">The number</param>
        /// <param name="total">The total</param>
        /// <returns>The percent value is of total</returns>
        public static decimal PercentOf(this int value, int total)
        {
            decimal result = 0;

            if (value > 0 && total > 0)
            {
                result = (decimal)value / (decimal)total * 100;
            }

            return result;
        }

        /// <summary>
        /// Returns what percentage of total the given number is.
        /// </summary>
        /// <param name="value">The number</param>
        /// <param name="total">The total</param>
        /// <returns>The percent value is of total</returns>
        public static decimal PercentOf(this int value, decimal total)
        {
            decimal result = 0;

            if (value > 0 && total > 0)
            {
                result = (decimal)value / (decimal)total * 100;
            }

            return result;
        }

        /// <summary>
        /// Returns what percentage of total the given number is.
        /// </summary>
        /// <param name="value">The number</param>
        /// <param name="total">The total</param>
        /// <returns>The percent value is of total</returns>
        public static decimal PercentOf(this int value, long total)
        {
            decimal result = 0;

            if (value > 0 && total > 0)
            {
                result = (decimal)value / (decimal)total * 100;
            }

            return result;
        }

        /// <summary>
        /// Returns what percentage of total the given number is.
        /// </summary>
        /// <param name="value">The number</param>
        /// <param name="total">The total</param>
        /// <returns>The percent value is of total</returns>
        public static decimal PercentOf(this int value, float total)
        {
            decimal result = 0;

            if (value > 0 && total > 0)
            {
                result = (decimal)value / (decimal)total * 100;
            }

            return result;
        }

        /// <summary>
        /// Returns what percentage of total the given number is.
        /// </summary>
        /// <param name="value">The number</param>
        /// <param name="total">The total</param>
        /// <returns>The percent value is of total</returns>
        public static decimal PercentOf(this int value, double total)
        {
            decimal result = 0;

            if (value > 0 && total > 0)
            {
                result = (decimal)value / (decimal)total * 100;
            }

            return result;
        }

        /// <summary>
        /// Returns what percentage of total the given number is.
        /// </summary>
        /// <param name="value">The number</param>
        /// <param name="total">The total</param>
        /// <returns>The percent value is of total</returns>
        public static decimal PercentOf(this long value, int total)
        {
            decimal result = 0;

            if (value > 0 && total > 0)
            {
                result = (decimal)value / (decimal)total * 100;
            }

            return result;
        }

        /// <summary>
        /// Returns what percentage of total the given number is.
        /// </summary>
        /// <param name="value">The number</param>
        /// <param name="total">The total</param>
        /// <returns>The percent value is of total</returns>
        public static decimal PercentOf(this long value, decimal total)
        {
            decimal result = 0;

            if (value > 0 && total > 0)
            {
                result = (decimal)value / (decimal)total * 100;
            }

            return result;
        }

        /// <summary>
        /// Returns what percentage of total the given number is.
        /// </summary>
        /// <param name="value">The number</param>
        /// <param name="total">The total</param>
        /// <returns>The percent value is of total</returns>
        public static decimal PercentOf(this long value, long total)
        {
            decimal result = 0;

            if (value > 0 && total > 0)
            {
                result = (decimal)value / (decimal)total * 100;
            }

            return result;
        }

        /// <summary>
        /// Returns what percentage of total the given number is.
        /// </summary>
        /// <param name="value">The number</param>
        /// <param name="total">The total</param>
        /// <returns>The percent value is of total</returns>
        public static decimal PercentOf(this long value, float total)
        {
            decimal result = 0;

            if (value > 0 && total > 0)
            {
                result = (decimal)value / (decimal)total * 100;
            }

            return result;
        }

        /// <summary>
        /// Returns what percentage of total the given number is.
        /// </summary>
        /// <param name="value">The number</param>
        /// <param name="total">The total</param>
        /// <returns>The percent value is of total</returns>
        public static decimal PercentOf(this long value, double total)
        {
            decimal result = 0;

            if (value > 0 && total > 0)
            {
                result = (decimal)value / (decimal)total * 100;
            }

            return result;
        }
    }
}
