using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartFormat;

namespace HyperSlackers.Extensions
{
    public static partial class ExtensionMethods
    {
        /// <summary>
        /// Writes the object to the debug window.
        /// </summary>
        /// <param name="value">The value.</param>
        public static void DebugWrite(this object value)
        {
            System.Diagnostics.Debug.Write(value);
        }

        /// <summary>
        /// Writes the object to the debug window.
        /// </summary>
        /// <param name="value">The value.</param>
        public static void DebugWrite(this object value, string format)
        {
            System.Diagnostics.Debug.Write(format.FormatWith(value));
        }

        /// <summary>
        /// Writes the object to the debug window.
        /// </summary>
        /// <param name="value">The value.</param>
        public static void DebugWriteLine(this object value)
        {
            System.Diagnostics.Debug.WriteLine(value);
        }

        /// <summary>
        /// Writes the object to the debug window.
        /// </summary>
        /// <param name="value">The value.</param>
        public static void DebugWriteLine(this object value, string format)
        {
            System.Diagnostics.Debug.WriteLine(format.FormatWith(value));
        }

        /// <summary>
        /// Determines whether the specified value is null.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// 	<c>true</c> if the specified value is null; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNull(this object value)
        {
            return (value == null) || (value.GetType() == typeof(DBNull));
        }

        /// <summary>
        /// Equals method that lets you specify on what property or field value you want to compare an object on. Also compares the object types. Useful to use in an overridden Equals method of an object. 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="obj">The object.</param>
        /// <param name="obj1">The obj1.</param>
        /// <param name="selector">The selector.</param>
        /// <returns></returns>
        public static bool Equals<T, TResult>(this T obj, object obj1, Func<T, TResult> selector)
        {
            return obj1 is T && selector(obj).Equals(selector((T)obj1));
        }
    }
}
