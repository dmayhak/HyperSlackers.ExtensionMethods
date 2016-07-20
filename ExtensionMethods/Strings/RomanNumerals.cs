using SmartFormat;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;

using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HyperSlackers.Extensions
{
    public static partial class ExtensionMethods
    {
        private static readonly Regex validRomanNumeral = new Regex("^(?i:(?=[MDCLXVI])((M{0,3})((C[DM])|(D?C{0,3}))?((X[LC])|(L?XX{0,2})|L)?((I[VX])|(V?(II{0,2}))|V)?))$", RegexOptions.Compiled);
        private const int NumberOfRomanNumeralMaps = 13;
        private static readonly Dictionary<string, int> romanNumerals = new Dictionary<string, int>(NumberOfRomanNumeralMaps)
        {
            { "M", 1000 },
            { "CM", 900 },
            { "D", 500 },
            { "CD", 400 },
            { "C", 100 },
            { "XC", 90 },
            { "L", 50 },
            { "XL", 40 },
            { "X", 10 },
            { "IX", 9 },
            { "V", 5 },
            { "IV", 4 },
            { "I", 1 }
        };

        /// <summary>
        /// Determines whether value is a valid Roman numeral.
        /// from http://stackoverflow.com/questions/271398/what-are-your-favorite-extension-methods-for-c-codeplex-com-extensionoverflow
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static bool IsValidRomanNumeral(this string value)
        {
            Helpers.ThrowIfNull(!value.IsNullOrWhiteSpace(), "value");

            return validRomanNumeral.IsMatch(value);
        }

        /// <summary>
        /// Converts Roman numeral string to integer.
        /// from http://stackoverflow.com/questions/271398/what-are-your-favorite-extension-methods-for-c-codeplex-com-extensionoverflow
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static int FromRomanNumeral(this string value)
        {
            Helpers.ThrowIfNull(!value.IsNullOrWhiteSpace(), "value");
            Helpers.ThrowIfNull(value.IsValidRomanNumeral(), "Argument not a valid Roman numeral.");

            value = value.ToUpperInvariant().Trim();

            var total = 0;
            var i = value.Length;

            while (i > 0)
            {
                var digit = romanNumerals[value[--i].ToString()];

                if (i > 0)
                {
                    var previousDigit = romanNumerals[value[i - 1].ToString()];

                    if (previousDigit < digit)
                    {
                        digit -= previousDigit;
                        i--;
                    }
                }

                total += digit;
            }

            return total;
        }

        /// <summary>
        /// Converts integer (in the range of 1 to 3999) to a Roman numeral string.
        /// from http://stackoverflow.com/questions/271398/what-are-your-favorite-extension-methods-for-c-codeplex-com-extensionoverflow
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static string ToRomanNumeral(this int value)
        {
            Helpers.ThrowIfNull(value >= 1 && value <= 3999, "Argument out of Roman numeral range."); // can only handle this range

            var sb = new StringBuilder(15); // maximum length for roman numeral string

            foreach (var pair in romanNumerals)
            {
                while (value / pair.Value > 0)
                {
                    sb.Append(pair.Key);

                    value -= pair.Value;
                }
            }

            return sb.ToString();
        }
    }
}
