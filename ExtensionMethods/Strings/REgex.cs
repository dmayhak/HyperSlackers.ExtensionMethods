using SmartFormat;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics.Contracts;
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
        /// Executes a regex replace with a replacement value of "".
        /// </summary>
        /// <param name="value">The input string.</param>
        /// <param name="pattern">The pattern to search for.</param>
        /// <returns></returns>
        public static string RegexRemove(this string value, string pattern)
        {
            return Regex.Replace(value, pattern, "");
        }

        /// <summary>
        /// Returns the matched string from the regex pattern. The
        /// groupName is for named group match values in the form (?<name>group).
        /// from http://stackoverflow.com/questions/271398/what-are-your-favorite-extension-methods-for-c-codeplex-com-extensionoverflow?page=5&tab=votes#tab-top
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="pattern">The pattern.</param>
        /// <param name="options">The options.</param>
        /// <param name="groupName">Name of the group.</param>
        /// <returns></returns>
        public static string RegexMatch(this string value, string pattern, RegexOptions options, string groupName)
        {
            if (groupName.IsNullOrWhiteSpace())
            {
                return Regex.Match(value, pattern, options).Value;
            }
            else
            {
                return Regex.Match(value, pattern, options).Groups[groupName].Value;
            }
        }

        /// <summary>
        /// Returns the matched string from the regex pattern. The
        /// groupName is for named group match values in the form (?<name>group).
        /// from http://stackoverflow.com/questions/271398/what-are-your-favorite-extension-methods-for-c-codeplex-com-extensionoverflow?page=5&tab=votes#tab-top
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="pattern">The pattern.</param>
        /// <returns></returns>
        public static string RegexMatch(this string value, string pattern)
        {
            return RegexMatch(value, pattern, RegexOptions.None, null);
        }

        /// <summary>
        /// Returns the matched string from the regex pattern. The
        /// groupName is for named group match values in the form (?<name>group).
        /// from http://stackoverflow.com/questions/271398/what-are-your-favorite-extension-methods-for-c-codeplex-com-extensionoverflow?page=5&tab=votes#tab-top
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="pattern">The pattern.</param>
        /// <param name="options">The options.</param>
        /// <returns></returns>
        public static string RegexMatch(this string value, string pattern, RegexOptions options)
        {
            return RegexMatch(value, pattern, options, null);
        }

        /// <summary>
        /// Returns the matched string from the regex pattern. The
        /// groupName is for named group match values in the form (?<name>group).
        /// from http://stackoverflow.com/questions/271398/what-are-your-favorite-extension-methods-for-c-codeplex-com-extensionoverflow?page=5&tab=votes#tab-top
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="pattern">The pattern.</param>
        /// <param name="groupName">Name of the group.</param>
        /// <returns></returns>
        public static string RegexMatch(this string value, string pattern, string groupName)
        {
            return RegexMatch(value, pattern, RegexOptions.None, groupName);
        }

        /// <summary>
        /// Returns true if there is a match from the regex pattern
        /// from http://stackoverflow.com/questions/271398/what-are-your-favorite-extension-methods-for-c-codeplex-com-extensionoverflow?page=5&tab=votes#tab-top
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="pattern">The pattern.</param>
        /// <param name="options">The options.</param>
        /// <returns></returns>
        public static bool IsRegexMatch(this string value, string pattern, RegexOptions options)
        {
            return value.RegexMatch(pattern, options).Length > 0;
        }

        /// <summary>
        /// Returns true if there is a match from the regex pattern
        /// from http://stackoverflow.com/questions/271398/what-are-your-favorite-extension-methods-for-c-codeplex-com-extensionoverflow?page=5&tab=votes#tab-top
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="pattern">The pattern.</param>
        /// <returns></returns>
        public static bool IsRegexMatch(this string value, string pattern)
        {
            return value.IsRegexMatch(pattern, RegexOptions.None);
        }

        /// <summary>
        /// Returns a string where matching patterns are replaced by the replacement string.
        /// from http://stackoverflow.com/questions/271398/what-are-your-favorite-extension-methods-for-c-codeplex-com-extensionoverflow?page=5&tab=votes#tab-top
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="pattern">The regex pattern for matching the items to be replaced</param>
        /// <param name="replacement">The string to replace matching items</param>
        /// <param name="options">The options.</param>
        /// <returns></returns>
        public static string RegexReplace(this string value, string pattern, string replacement, RegexOptions options)
        {
            return Regex.Replace(value, pattern, replacement, options);
        }

        /// <summary>
        /// Returns a string where matching patterns are replaced by the replacement string.
        /// from http://stackoverflow.com/questions/271398/what-are-your-favorite-extension-methods-for-c-codeplex-com-extensionoverflow?page=5&tab=votes#tab-top
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="pattern">The regex pattern for matching the items to be replaced</param>
        /// <param name="replacement">The string to replace matching items</param>
        /// <returns></returns>
        public static string RegexReplace(this string value, string pattern, string replacement)
        {
            return Regex.Replace(value, pattern, replacement, RegexOptions.None);
        }

        /// <summary>
        /// Splits an input string into an array of substrings at the positions defined by a regular
        /// expression pattern specified in the System.Text.RegularExpressions.Regex constructor.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="regexPattern">The regex pattern.</param>
        /// <returns></returns>
        public static string[] RegexSplit(this string value, string regexPattern)
        {
            return value.RegexSplit(regexPattern, RegexOptions.None);
        }

        /// <summary>
        /// Splits an input string into an array of substrings at the positions defined by a regular
        /// expression pattern specified in the System.Text.RegularExpressions.Regex constructor.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="regexPattern">The regex pattern.</param>
        /// <param name="options">The options.</param>
        /// <returns></returns>
        public static string[] RegexSplit(this string value, string regexPattern, RegexOptions options)
        {
            return Regex.Split(value, regexPattern, options);
        }
    }
}
