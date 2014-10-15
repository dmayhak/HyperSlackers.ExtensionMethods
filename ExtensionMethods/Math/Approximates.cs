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
        /// Determines if two doubles are approximately equal.
        /// </summary>
        /// <param name="value">The number.</param>
        /// <param name="compareTo">The to compare to.</param>
        /// <returns>
        ///   <c>true</c> if the numbers are approximately equal, <c>false</c> if not.
        /// </returns>
        public static bool Approximates(this double value, double compareTo)
        {
            return Approximates(value, compareTo, 15);
        }

        /// <summary>
        /// Determines if two doubles are approximately equal.
        /// </summary>
        /// <param name="value">The number.</param>
        /// <param name="compareTo">The to compare to.</param>
        /// <param name="significantFigures">the number of significant figures to use for comparison.</param>
        /// <returns>
        ///   <c>true</c> if the numbers are approximately equal, <c>false</c> if not.
        /// </returns>
        public static bool Approximates(this double value, double compareTo, int significantFigures)
        {
            // if bit-wise equal, return true (it's faster!)
            if (value == compareTo)
            {
                return true;
            }

            // determine a close-enough delta value
            double significantValue = significantFigures == 15 ? 1.0E+15 : 10 ^ (significantFigures - 1);

            // are the two numbers within the delta?
            return Math.Abs(value - compareTo) < Math.Abs(value / significantValue);
        }

        /// <summary>
        /// Determines if two floats are approximately equal.
        /// </summary>
        /// <param name="value">The number.</param>
        /// <param name="compareTo">The to compare to.</param>
        /// <returns>
        ///   <c>true</c> if the numbers are approximately equal, <c>false</c> if not.
        /// </returns>
        public static bool Approximates(this float value, float compareTo)
        {
            return Approximates(value, compareTo, 7);
        }

        /// <summary>
        /// Determines if two floats are approximately equal.
        /// </summary>
        /// <param name="value">The number.</param>
        /// <param name="compareTo">The to compare to.</param>
        /// <param name="significantFigures">the number of significant figures to use for comparison.</param>
        /// <returns>
        ///   <c>true</c> if the numbers are approximately equal, <c>false</c> if not.
        /// </returns>
        public static bool Approximates(this float value, float compareTo, int significantFigures)
        {
            // if bit-wise equal, return true (it's faster!)
            if (value == compareTo)
            {
                return true;
            }

            // determine a close-enough delta value
            double significantValue = significantFigures == 7 ? 1.0E+7 : 10 ^ (significantFigures - 1);

            // are the two numbers within the delta?
            return Math.Abs(value - compareTo) < Math.Abs(value / significantValue);
        }
    }
}
