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
        ///// <summary>
        ///// Formats the string with the given args.
        ///// </summary>
        ///// <param name="value">The string value.</param>
        ///// <param name="args">The arguments.</param>
        ///// <returns></returns>
        //[Pure]
        //public static string FormatWith(this string value, params object[] args)
        //{
        //    Contract.Requires<ArgumentNullException>(value != null, "value");
        //    Contract.Requires<ArgumentNullException>(args != null, "args");
        //    Contract.Ensures(Contract.Result<string>() != null);

        //    return FormatWith(value, CultureInfo.CurrentUICulture, args);
        //}

        ///// <summary>
        ///// Formats the string with the given args.
        ///// </summary>
        ///// <param name="value">The string value.</param>
        ///// <param name="provider">The format provider.</param>
        ///// <param name="args">The arguments.</param>
        ///// <returns></returns>
        //[Pure]
        //public static string FormatWith(this string value, IFormatProvider provider, params object[] args)
        //{
        //    Contract.Requires<ArgumentNullException>(provider != null, "provider");
        //    Contract.Requires<ArgumentNullException>(args != null, "args");
        //    Contract.Ensures(Contract.Result<string>() != null);

        //    if (value.IsNullOrWhiteSpace())
        //    {
        //        return value ?? string.Empty;
        //    }

        //    return string.Format(provider, value, args);
        //}

        /// <summary>
        /// Formats the string with the given args using SmartFormat.
        /// </summary>
        /// <param name="value">The string value.</param>
        /// <param name="args">The arguments.</param>
        /// <returns></returns>
        [Pure]
        public static string FormatWith(this string value, params object[] args)
        {
            Contract.Requires<ArgumentNullException>(args != null, "args");
            Contract.Ensures(Contract.Result<string>() != null);

            if (value.IsNullOrWhiteSpace())
            {
                return value ?? string.Empty;
            }

            return FormatWith(value, CultureInfo.CurrentUICulture, args);
        }

        /// <summary>
        /// Formats the string with the given args using SmartFormat.
        /// </summary>
        /// <param name="value">The string value.</param>
        /// <param name="provider">The provider.</param>
        /// <param name="args">The arguments.</param>
        /// <returns></returns>
        [Pure]
        public static string FormatWith(this string value, IFormatProvider provider, params object[] args)
        {
            Contract.Requires<ArgumentNullException>(provider != null, "provider");
            Contract.Requires<ArgumentNullException>(args != null, "args");
            Contract.Ensures(Contract.Result<string>() != null);

            if (value.IsNullOrWhiteSpace())
            {
                return value ?? string.Empty;
            }

            return Smart.Format(provider, value, args);
        }
    }
}
