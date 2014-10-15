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
        /// Returns true if input is between lower and upper; false otherwise.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input">The input.</param>
        /// <param name="lower">The lower.</param>
        /// <param name="upper">The upper.</param>
        /// <returns>
        /// true if input is between lower and upper; false otherwise
        /// </returns>
        public static bool Between<T>(this T input, T lower, T upper)
            where T : IComparable<T>
        {
            return input.CompareTo(lower) > 0 && input.CompareTo(upper) < 0;
        }

        /// <summary>
        /// Returns true if input is between lower and upper (or equal to either); false otherwise.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input">The input.</param>
        /// <param name="lower">The lower.</param>
        /// <param name="upper">The upper.</param>
        /// <returns>
        /// true if input is between lower and upper (or equal to either); false otherwise
        /// </returns>
        public static bool BetweenIncludeBoth<T>(this T input, T lower, T upper)
            where T : IComparable<T>
        {
            return input.CompareTo(lower) >= 0 && input.CompareTo(upper) <= 0;
        }

        /// <summary>
        /// Returns true if input is between lower and upper (or equal to lower); false otherwise.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input">The input.</param>
        /// <param name="lower">The lower.</param>
        /// <param name="upper">The upper.</param>
        /// <returns>
        /// true if input is between lower and upper (or equal to lower); false otherwise
        /// </returns>
        public static bool BetweenIncludeLower<T>(this T input, T lower, T upper)
            where T : IComparable<T>
        {
            return input.CompareTo(lower) >= 0 && input.CompareTo(upper) < 0;
        }

        /// <summary>
        /// Returns true if input is between lower and upper (or equal to upper); false otherwise.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input">The input.</param>
        /// <param name="lower">The lower.</param>
        /// <param name="upper">The upper.</param>
        /// <returns>
        /// true if input is between lower and upper (or equal to upper); false otherwise
        /// </returns>
        public static bool BetweenIncludeUpper<T>(this T input, T lower, T upper)
            where T : IComparable<T>
        {
            return input.CompareTo(lower) > 0 && input.CompareTo(upper) <= 0;
        }
    }
}
