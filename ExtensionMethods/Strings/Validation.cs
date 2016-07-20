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
        /// <summary>
        /// Returns true if the string is either null, or empty.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this String value)
        {
            return string.IsNullOrEmpty(value);
        }

        /// <summary>
        /// Returns true if the string is null, empty, or contains only whitespace.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static bool IsNullOrWhiteSpace(this String value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        /// <summary>
        /// Determines whether a string contains only upper-case letters.
        /// </summary>
        /// <param name="value">The string value.</param>
        /// <returns></returns>
        public static bool IsAllUpperCase(this string value)
        {
            Helpers.ThrowIfNull(value != null, "value");

            for (int i = 0; i < value.Length; i++)
            {
                if (Char.IsLetter(value[i]) && !Char.IsUpper(value[i]))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Determines whether the specified value is date.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static bool IsDateTime(this string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                DateTime dt;
                return (DateTime.TryParse(value, out dt));
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Determines whether the specified string is an enum.
        /// </summary>
        /// <typeparam name="T">the enum type</typeparam>
        /// <param name="value">The string to check.</param>
        /// <returns></returns>
        public static bool IsEnum<T>(this string value)
        {
            return Enum.IsDefined(typeof(T), value);
        }

        /// <summary>
        /// Determines whether the specified input is a decimal.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// 	<c>true</c> if the specified input is a decimal; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsDecimal(this string value)
        {
            decimal number;

            return decimal.TryParse(value, out number);
        }

        /// <summary>
        /// Determines whether the specified input is an integer.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// 	<c>true</c> if the specified input is an integer; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsInteger(this string value)
        {
            int number;

            return int.TryParse(value, out number);
        }

        /// <summary>
        /// Determines whether the specified input is a long.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// 	<c>true</c> if the specified input is a long; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsLong(this string value)
        {
            long number;

            return long.TryParse(value, out number);
        }

        /// <summary>
        /// Determines whether the specified input is a Guid.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// 	<c>true</c> if the specified input is a Guid; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsGuid(this string value)
        {
            Guid guid;

            return Guid.TryParse(value, out guid);
        }

        /// <summary>
        /// Determines whether the specified input is numeric.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// 	<c>true</c> if the specified input is numeric; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNumeric(this string value)
        {
            double number;

            return double.TryParse(value, out number);
        }

        /// <summary>
        /// Determines whether the string is a valid email address.
        /// </summary>
        /// <param name="value">The string to test</param>
        /// <returns>
        /// 	<c>true</c> if the string is a valid email address; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsValidEmailAddress(this string value)
        {
            Helpers.ThrowIfNull(value != null, "value");

            return value.IsRegexMatch(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
        }

        /// <summary>
        /// Determines whether the string is a valid URL.
        /// </summary>
        /// <param name="value">The string to test</param>
        /// <returns>
        /// 	<c>true</c> if the string is a valid URL; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsValidUrl(this string value)
        {
            Helpers.ThrowIfNull(value != null, "value");

            return value.IsRegexMatch(@"http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?");
        }

        /// <summary>
        /// Determines whether [is valid ip address] [the specified value].
        /// from http://extensionmethod.net/csharp/string/isvalidipaddress
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static bool IsValidIPAddress(this string value)
        {
            return Regex.IsMatch(value, @"\b(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\b");
        }

        /// <summary>
        /// Returns the length of the string if it were trimmed.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static int LengthTrimmed(this String value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return 0;
            }

            return value.Trim().Length;
        }

        /// <summary>
        /// Determines whether the string contains the searchFor value.
        /// </summary>
        /// <param name="value">The string to search.</param>
        /// <param name="searchFor">To strig to look for.</param>
        /// <param name="comparer">The comparer.</param>
        /// <returns></returns>
        public static bool Contains(this string value, string searchFor, StringComparison comparer)
        {
            Helpers.ThrowIfNull(value != null, "value");
            Helpers.ThrowIfNull(searchFor != null, "toCheck");

            return value.IndexOf(searchFor, comparer) >= 0;
        }

        /// <summary>
        /// Determines if the string contains any of the specified chars.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="characters">The characters to search for.</param>
        /// <returns></returns>
        public static bool ContainsAny(this string value, char[] characters)
        {
            foreach (char character in characters)
            {
                if (value.Contains(character))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Indicates whether the current string matches the supplied wildcard pattern.  Behaves the same
        /// as VB's "Like" Operator.
        /// from http://stackoverflow.com/questions/271398/what-are-your-favorite-extension-methods-for-c-codeplex-com-extensionoverflow?page=2&tab=votes#tab-top
        /// </summary>
        /// <param name="s">The string instance where the extension method is called</param>
        /// <param name="wildcardPattern">The wildcard pattern to match.  Syntax matches VB's Like operator.</param>
        /// <returns>true if the string matches the supplied pattern, false otherwise.</returns>
        /// <remarks>See http://msdn.microsoft.com/en-us/library/swf8kaxw(v=VS.100).aspx</remarks>
        public static bool IsLike(this string s, string wildcardPattern)
        {
            if (s == null || String.IsNullOrEmpty(wildcardPattern))
            {
                return false;
            }

            // turn into regex pattern, and match the whole string with ^$
            var regexPattern = "^" + Regex.Escape(wildcardPattern) + "$";

            // add support for ?, #, *, [], and [!]
            regexPattern = regexPattern.Replace(@"\[!", "[^")
                                       .Replace(@"\[", "[")
                                       .Replace(@"\]", "]")
                                       .Replace(@"\?", ".")
                                       .Replace(@"\*", ".*")
                                       .Replace(@"\#", @"\d");

            var result = false;

            try
            {
                result = Regex.IsMatch(s, regexPattern);
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException(String.Format("Invalid pattern: {0}", wildcardPattern), ex);
            }

            return result;
        }

        /// <summary>
        /// Case-insensitive string comparison.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="compareTo">The compare to.</param>
        /// <returns></returns>
        public static bool EqualsIgnoreCase(this string value, string compareTo)
        {
            return string.Equals(value, compareTo, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Case-insensitive string comparison.
        /// from http://stackoverflow.com/questions/271398/what-are-your-favorite-extension-methods-for-c-codeplex-com-extensionoverflow?page=2&tab=votes#tab-top
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="compareTo">The compare to.</param>
        /// <returns></returns>
        public static bool StartsWithIgnoreCase(this string value, string compareTo)
        {
            return value.StartsWith(compareTo, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Case-insensitive string comparison.
        /// from http://stackoverflow.com/questions/271398/what-are-your-favorite-extension-methods-for-c-codeplex-com-extensionoverflow?page=2&tab=votes#tab-top
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="compareTo">The compare to.</param>
        /// <returns></returns>
        public static bool EndsWithIgnoreCase(this string value, string compareTo)
        {
            return value.EndsWith(compareTo, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Case-insensitive string comparison.
        /// from http://stackoverflow.com/questions/271398/what-are-your-favorite-extension-methods-for-c-codeplex-com-extensionoverflow?page=2&tab=votes#tab-top
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="compareTo">The compare to.</param>
        /// <returns></returns>
        public static bool ContainsIgnoreCase(this string value, string compareTo)
        {
            return value.Contains(compareTo, StringComparison.OrdinalIgnoreCase);
        }
    }
}
