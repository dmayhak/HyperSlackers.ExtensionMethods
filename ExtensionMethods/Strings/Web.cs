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
        /// Decodes an HTML-encoded string.
        /// </summary>
        /// <param name="value">The string to decode</param>
        /// <returns></returns>
        public static string HtmlDecode(this string value)
        {
            return System.Web.HttpUtility.HtmlDecode(value);
        }

        /// <summary>
        /// HTML-encodes the string.
        /// </summary>
        /// <param name="value">The string to encode</param>
        /// <returns></returns>
        public static string HtmlEncode(this string value)
        {
            return System.Web.HttpUtility.HtmlEncode(value);
        }

        /// <summary>
        /// Decodes a URl-encoded string.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static string UrlDecode(this string value)
        {
            return System.Web.HttpUtility.UrlDecode(value);
        }

        /// <summary>
        /// URL-encodes a string.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static string UrlEncode(this string value)
        {
            return System.Web.HttpUtility.UrlEncode(value);
        }

        /// <summary>
        /// URL-encodes the path portion of a URL string.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static string UrlPathEncode(this string value)
        {
            return System.Web.HttpUtility.UrlPathEncode(value);
        }

        /// <summary>
        /// Parses a query string into a System.Collections.Specialized.NameValueCollection
        /// using System.Text.Encoding.UTF8 encoding.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static System.Collections.Specialized.NameValueCollection ParseQueryString(this string value)
        {
            Contract.Requires<ArgumentNullException>(value != null, "value");

            return System.Web.HttpUtility.ParseQueryString(value);
        }

        /// <summary>
        /// Strips the HTML tags from a string.
        /// </summary>
        /// <param name="value">The input string.</param>
        /// <returns>The string with all tags removed.</returns>
        public static string StripHtml(this string value)
        {
            var tagsExpression = new Regex(@"</?.+?>"); // TODO: is this too simple?

            return tagsExpression.Replace(value, " "); // TODO: probably add space where we don't need to
        }

        /// <summary>
        /// Replaces each new line with a br tag.
        /// </summary>
        /// <param name="value">The string value.</param>
        /// <returns></returns>
        [Pure]
        public static string ReplaceNewLineWithBr(this string value)
        {
            Contract.Ensures(!String.IsNullOrEmpty(Contract.Result<string>()));

            if (value.IsNullOrEmpty())
            {
                return string.Empty;
            }

            return value.Replace(Environment.NewLine, "<br/>");
        }
    }
}
