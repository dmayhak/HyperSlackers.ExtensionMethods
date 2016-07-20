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
        /// Splits the string at the given char and optionally trims the values.
        /// </summary>
        /// <param name="value">The string to split.</param>
        /// <param name="splitOn">The char to split on (deraults to ','.</param>
        /// <param name="trimValues">if set to <c>true</c> (the default) trims the split values.</param>
        /// <returns></returns>
        public static string[] SplitString(this string value, char splitOn = ',', bool trimValues = true)
        {
            if (value == null)
            {
                return new string[0];
            }
            else if (value.IsNullOrWhiteSpace())
            {
                return new string[] { string.Empty };
            }
            else
            {
                return value.Split(splitOn).Select(s => trimValues ? s.Trim() : s).Where(s => !s.IsNullOrWhiteSpace()).ToArray();
            }
        }

        /// <summary>
        /// Adds a space before each upper-case letter except the first.
        /// </summary>
        /// <param name="value">The string to format.</param>
        /// <returns></returns>
        public static string SpaceOnUpperCase(this string value)
        {
            if (value.IsNullOrWhiteSpace())
            {
                return string.Empty;
            }

            return string.Join(" ", value.SplitOnUpperCase());
        }

        /// <summary>
        /// Splits the string at upper-case letters.
        /// </summary>
        /// <param name="value">The string to split.</param>
        /// <returns></returns>
        private static string[] SplitOnUpperCase(this string value)
        {
            if (value.IsNullOrWhiteSpace())
            {
                return new[] { string.Empty };
            }

            if (value.IsAllUpperCase())
            {
                return new[] { value };
            }

            var words = new StringCollection();
            int wordStartIndex = 0;

            char[] letters = value.ToCharArray();
            char previousChar = char.MinValue;

            // Skip the first letter. we don't care what case it is.
            for (int i = 1; i < letters.Length; i++)
            {
                if (char.IsUpper(letters[i]) && !char.IsWhiteSpace(previousChar))
                {
                    //Grab everything before the current index.
                    words.Add(new String(letters, wordStartIndex, i - wordStartIndex));

                    wordStartIndex = i;
                }

                previousChar = letters[i];
            }

            //We need to have the last word.
            words.Add(new String(letters, wordStartIndex, letters.Length - wordStartIndex));

            //Copy to a string array.
            var wordArray = new string[words.Count];
            words.CopyTo(wordArray, 0);

            // TODO: should we force first word to start with a cap?

            return wordArray;
        }

        /// <summary>
        /// Returns the left 'length' characters of a string.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="length">The length.</param>
        /// <returns></returns>
        public static string Left(this String value, int length)
        {
            if (value.IsNullOrEmpty())
            {
                return string.Empty;
            }
            else if (value.Length <= length)
            {
                return value;
            }
            else
            {
                return value.Substring(0, length);
            }
        }

        /// <summary>
        /// Returns the left part of a string up to 'delimiter'.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="delimiter">The delimiter.</param>
        /// <returns></returns>
        public static string LeftBefore(this String value, string delimiter)
        {
            if (value.IsNullOrEmpty())
            {
                return string.Empty;
            }
            else
            {
                int index = value.IndexOf(delimiter, StringComparison.OrdinalIgnoreCase);
                if (index <= 0)
                {
                    return string.Empty;
                }
                else
                {
                    return value.Left(index);
                }
            }
        }

        /// <summary>
        /// Returns the left 'length' characters of a string after trimming the string.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="length">The length.</param>
        /// <returns></returns>
        public static string LeftTrimmed(this String value, int length)
        {
            if (value.IsNullOrWhiteSpace())
            {
                return string.Empty;
            }
            else
            {
                value = value.Trim();
                if (value.Length <= length)
                {
                    return value;
                }
                else
                {
                    return value.Substring(0, length);
                }
            }
        }

        /// <summary>
        /// Reverses the order of characters in the current string.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static string Reverse(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return value;
            }

            char[] reverse = value.ToCharArray();
            Array.Reverse(reverse);
            return new String(reverse);
        }

        /// <summary>
        /// Returns the right 'length' characters of a string.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="length">The length.</param>
        /// <returns></returns>
        public static string Right(this String value, int length)
        {
            if (value.IsNullOrEmpty())
            {
                return string.Empty;
            }
            else if (value.Length <= length)
            {
                return value;
            }
            else
            {
                return value.Substring(value.Length - length);
            }
        }

        /// <summary>
        /// Returns the right part of a string after 'delimiter'.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="delimiter">The delimiter.</param>
        /// <returns></returns>
        public static string RightAfter(this String value, string delimiter)
        {
            Helpers.ThrowIfNull(!String.IsNullOrEmpty(delimiter), "delimiter");

            if (value.IsNullOrEmpty())
            {
                return string.Empty;
            }
            else
            {
                int index = value.IndexOf(delimiter, StringComparison.OrdinalIgnoreCase);
                if (index + delimiter.Length >= value.Length)
                {
                    return string.Empty;
                }
                else
                {
                    return value.Right(value.Length - (index + delimiter.Length));
                }
            }
        }

        /// <summary>
        /// Returns the right 'length' characters of a string after trimming the string.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="length">The length.</param>
        /// <returns></returns>
        public static string RightTrimmed(this String value, int length)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return string.Empty;
            }
            else
            {
                value = value.Trim();
                if (value.Length <= length)
                {
                    return value;
                }
                else
                {
                    return value.Substring(value.Length - length);
                }
            }
        }

        /// <summary>
        /// Truncates the specified string to the length specified and appends '...'.
        /// </summary>
        /// <param name="value">The string to truncate.</param>
        /// <param name="maxLength">Maximum length of the returned string</param>
        /// <returns></returns>
        public static string Truncate(this string value, int maxLength)
        {
            return Truncate(value, maxLength, "...");
        }

        /// <summary> Truncates the specified string to the length specified and appends 'suffix'. </summary>
        ///
        /// <param name="value">     The string to truncate. </param>
        /// <param name="maxLength"> Maximum length of the returned string. </param>
        /// <param name="suffix">    The suffix. </param>
        ///
        /// <returns> . </returns>
        public static string Truncate(this string value, int maxLength, string suffix)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return string.Empty;
            }

            value = value.Trim();

            if (value.Length <= maxLength)
            {
                return value;
            }

            if (maxLength <= suffix.Length || value.Length <= suffix.Length)
            {
                return suffix;
            }

            return value.Trim().Substring(0, maxLength - suffix.Length).TrimEnd() + suffix;
        }

        /// <summary>
        /// Repeats the specified string count times.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="count">The count.</param>
        /// <returns></returns>
        public static string Repeat(this string input, int count)
        {
            if (input == null)
            {
                return null;
            }

            var sb = new StringBuilder();

            for (var repeat = 0; repeat < count; repeat++)
            {
                sb.Append(input);
            }

            return sb.ToString();
        }

        /// <summary>
        /// Returns the plural form of the specified word.
        /// </summary>
        /// <param name="count">How many of the specified word there are. A count equal to 1 will not pluralize the specified word.</param>
        /// <returns>A string that is the plural form of the input parameter.</returns>
        public static string ToPlural(this string value, int count = 0)
        {
            if (count == 1)
            {
                return value;
            }
            else
            {
                return System.Data.Entity.Design.PluralizationServices.PluralizationService.CreateService(new System.Globalization.CultureInfo("en-US")).Pluralize(value);
            }
        }
    }
}
