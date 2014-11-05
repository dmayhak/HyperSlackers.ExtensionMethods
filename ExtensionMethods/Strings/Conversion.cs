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
        private static Dictionary<string, MethodInfo> _methodInfoCache = new Dictionary<string, MethodInfo>();

        /// <summary>
        /// Attempts to convert a string to the specified type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static T? ConvertTo<T>(this string value)
            where T : struct
        {
            T? returnValue = null;

            MethodInfo neededInfo = GetMethodInfo(typeof(T), "TryParse");
            if ((neededInfo != null) && (value != null) && (value.Trim().Length > 0))
            {
                Type t = typeof(T);
                if (t.IsEnum)
                {
                    return (T)Enum.Parse(t, value.Trim(), true);
                }

                T output = default(T);
                object[] paramsArray = new object[2] { value, output };
                returnValue = new T();

                object returnedValue = neededInfo.Invoke(returnValue.Value, paramsArray);

                if (returnedValue is Boolean && (Boolean)returnedValue)
                {
                    returnValue = (T)paramsArray[1];
                }
                else
                {
                    returnValue = null;
                }
            }

            return returnValue;
        }

        // TODO: is this better or worse?
        //public static TValue ConvertTo<TValue>(this string text)
        //{
        //    TValue res = default(TValue);
        //    System.ComponentModel.TypeConverter tc = System.ComponentModel.TypeDescriptor.GetConverter(typeof(TValue));
        //    if (tc.CanConvertFrom(text.GetType()))
        //        res = (TValue)tc.ConvertFrom(text);
        //    else
        //    {
        //        tc = System.ComponentModel.TypeDescriptor.GetConverter(text.GetType());
        //        if (tc.CanConvertTo(typeof(TValue)))
        //            res = (TValue)tc.ConvertTo(text, typeof(TValue));
        //        else
        //            throw new NotSupportedException();
        //    }
        //    return res;
        //}

        private static MethodInfo GetMethodInfo(Type type, string method)
        {
            string cacheKey = type.FullName + "|" + method;
            MethodInfo mi = _methodInfoCache.ContainsKey(cacheKey) ? _methodInfoCache[cacheKey] : null;

            if (mi == null)
            {
                Type[] paramTypes = new Type[2] { typeof(string), type.MakeByRefType() };
                mi = type.GetMethod(method, paramTypes);
                if (mi != null)
                {
                    _methodInfoCache.Add(cacheKey, mi);
                }
            }

            return mi;
        }

        /// <summary>
        /// Attempts to convert a string to an enum.
        /// </summary>
        /// <typeparam name="T">the enum type</typeparam>
        /// <param name="theValue">The value.</param>
        /// <param name="defaultValue">The result to return when value not found.</param>
        /// <param name="ignoreCase">if set to <c>true</c>, ignore case.</param>
        /// <returns></returns>
        public static T? ToEnum<T>(this string theValue, T? defaultValue = null, bool ignoreCase = false) where T : struct
        {
            T output;

            return Enum.TryParse<T>(theValue, ignoreCase, out output) ? (T?)output : defaultValue;
        }

        /// <summary>
        /// Converts a string to a boolean value; returns false value if conversion fails.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static bool ToBoolean(this string value)
        {
            // TODO: not localized....
            if (string.Compare("T", value, StringComparison.OrdinalIgnoreCase) == 0)
            {
                return true;
            }
            else if (string.Compare("F", value, StringComparison.OrdinalIgnoreCase) == 0)
            {
                return false;
            }
            else if (string.Compare("True", value, StringComparison.OrdinalIgnoreCase) == 0)
            {
                return true;
            }
            else if (string.Compare("False", value, StringComparison.OrdinalIgnoreCase) == 0)
            {
                return false;
            }
            else if (string.Compare("Y", value, StringComparison.OrdinalIgnoreCase) == 0)
            {
                return true;
            }
            else if (string.Compare("N", value, StringComparison.OrdinalIgnoreCase) == 0)
            {
                return false;
            }
            else if (string.Compare("Yes", value, StringComparison.OrdinalIgnoreCase) == 0)
            {
                return true;
            }
            else if (string.Compare("No", value, StringComparison.OrdinalIgnoreCase) == 0)
            {
                return false;
            }
            else if (string.Compare("Pass", value, StringComparison.OrdinalIgnoreCase) == 0)
            {
                return true;
            }
            else if (string.Compare("Fail", value, StringComparison.OrdinalIgnoreCase) == 0)
            {
                return false;
            }
            else if (string.Compare("1", value, StringComparison.OrdinalIgnoreCase) == 0)
            {
                return true;
            }
            else if (string.Compare("0", value, StringComparison.OrdinalIgnoreCase) == 0)
            {
                return false;
            }

            bool result;
            if (bool.TryParse(value, out result))
            {
                return result;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Converts a string to a decimal value if possible; returns default value if not.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns></returns>
        public static decimal ToDecimal(this string value, decimal defaultValue)
        {
            decimal number;

            return (decimal.TryParse(value, out number)) ? number : defaultValue;
        }

        /// <summary>
        /// Converts a string to a decimal value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static decimal ToDecimal(this string value)
        {
            return decimal.Parse(value);
        }

        /// <summary>
        /// Converts a string to an integer value if possible; returns default value if not.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <param name="provider">The provider.</param>
        /// <returns></returns>
        public static int ToInteger(this string value, int defaultValue, IFormatProvider provider)
        {
            int number;

            return (int.TryParse(value, NumberStyles.Any, provider, out number)) ? number : defaultValue;
        }

        /// <summary>
        /// Converts a string to an integer value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="provider">The provider.</param>
        /// <returns></returns>
        public static int ToInteger(this string value, IFormatProvider provider)
        {
            return int.Parse(value, provider);
        }

        /// <summary>
        /// Converts a string to an integer value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="provider">The provider.</param>
        /// <returns></returns>
        public static int ToInteger(this string value)
        {
            return int.Parse(value);
        }

        /// <summary>
        /// Converts a string to a Guid if possible; returns default value if not.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <param name="provider">The provider.</param>
        /// <returns></returns>
        public static Guid ToGuid(this string value, Guid defaultValue)
        {
            Guid guid;

            return (Guid.TryParse(value, out guid)) ? guid : defaultValue;
        }

        /// <summary>
        /// Converts a string to a Guid.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="provider">The provider.</param>
        /// <returns></returns>
        public static Guid ToGuid(this string value)
        {
            return Guid.Parse(value);
        }

        /// <summary>
        /// Converts a string to a long value if possible; returns default value if not.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <param name="provider">The provider.</param>
        /// <returns></returns>
        public static long ToLong(this string value, long defaultValue, IFormatProvider provider)
        {
            long number;

            return (long.TryParse(value, NumberStyles.Any, provider, out number)) ? number : defaultValue;
        }

        /// <summary>
        /// Converts a string to a long value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="provider">The provider.</param>
        /// <returns></returns>
        public static long ToLong(this string value, IFormatProvider provider)
        {
            return long.Parse(value, provider);
        }

        /// <summary>
        /// Converts a string to a long value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="provider">The provider.</param>
        /// <returns></returns>
        public static long ToLong(this string value)
        {
            return long.Parse(value);
        }

        /// <summary>
        /// Converts a string to a float value if possible; returns default value if not.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <param name="provider">The provider.</param>
        /// <returns></returns>
        public static float ToFloat(this string value, float defaultValue, IFormatProvider provider)
        {
            float number;

            return (float.TryParse(value, NumberStyles.Any, provider, out number)) ? number : defaultValue;
        }

        /// <summary>
        /// Converts a string to a float value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="provider">The provider.</param>
        /// <returns></returns>
        public static float ToFloat(this string value, IFormatProvider provider)
        {
            return float.Parse(value, provider);
        }

        /// <summary>
        /// Converts a string to a float value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="provider">The provider.</param>
        /// <returns></returns>
        public static float ToFloat(this string value)
        {
            return float.Parse(value);
        }

        /// <summary>
        /// Converts a string to a double value if possible; returns default value if not.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <param name="provider">The provider.</param>
        /// <returns></returns>
        public static double ToDouble(this string value, double defaultValue, IFormatProvider provider)
        {
            double number;

            return (double.TryParse(value, NumberStyles.Any, provider, out number)) ? number : defaultValue;
        }

        /// <summary>
        /// Converts a string to a double value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="provider">The provider.</param>
        /// <returns></returns>
        public static double ToDouble(this string value, IFormatProvider provider)
        {
            return double.Parse(value, provider);
        }

        /// <summary>
        /// Converts a string to a double value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="provider">The provider.</param>
        /// <returns></returns>
        public static double ToDouble(this string value)
        {
            return double.Parse(value);
        }

        /// <summary>
        /// Converts a string to a DateTime value if possible; returns default value if not.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <param name="provider">The provider.</param>
        /// <param name="styles">The styles.</param>
        /// <returns></returns>
        public static DateTime ToDateTime(this string value, DateTime defaultValue, IFormatProvider provider, DateTimeStyles styles)
        {
            DateTime date;

            return (DateTime.TryParse(value, provider, styles, out date)) ? date : defaultValue;
        }

        /// <summary>
        /// Converts a string to a DateTime value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="provider">The provider.</param>
        /// <returns></returns>
        public static DateTime ToDateTime(this string value, IFormatProvider provider, DateTimeStyles styles)
        {
            return DateTime.Parse(value, provider, styles);
        }

        /// <summary>
        /// Converts a string to a DateTime value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="provider">The provider.</param>
        /// <returns></returns>
        public static DateTime ToDateTime(this string value, IFormatProvider provider)
        {
            return DateTime.Parse(value, provider);
        }

        /// <summary>
        /// Converts a string to a DateTime value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="provider">The provider.</param>
        /// <returns></returns>
        public static DateTime ToDateTime(this string value)
        {
            return DateTime.Parse(value);
        }
    }
}
