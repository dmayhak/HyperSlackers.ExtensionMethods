using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperSlackers.Extensions
{
    // adapted from
    // http://stackoverflow.com/questions/271398/what-are-your-favorite-extension-methods-for-c-codeplex-com-extensionoverflow?page=2&tab=votes#tab-top
    public static partial class ExtensionMethods
    {
        // 10 digits vs. 52 alphabetic characters (upper & lower);
        // probability of being numeric: 10 / 62 = 0.1612903225806452
        private const double AlphanumericProbabilityNumericAny = 10.0 / 62.0;

        // 10 digits vs. 26 alphabetic characters (upper OR lower);
        // probability of being numeric: 10 / 36 = 0.2777777777777778
        private const double AlphanumericProbabilityNumericCased = 10.0 / 36.0;


        /// <summary>
        /// Gets the next random bool (weighted).
        /// </summary>
        /// <param name="random">The random.</param>
        /// <param name="probability">The probability of a true result.</param>
        /// <returns>true/false result</returns>
        public static bool NextBool(this Random random, double probability)
        {
            Contract.Requires<ArgumentNullException>(random != null, "random");

            return random.NextDouble() <= probability;
        }

        /// <summary>
        /// Gets the next random bool.
        /// </summary>
        /// <param name="random">The random.</param>
        /// <returns>true/false result</returns>
        public static bool NextBool(this Random random)
        {
            Contract.Requires<ArgumentNullException>(random != null, "random");

            return random.NextDouble() <= 0.5;
        }

        /// <summary>
        /// Gets the next random char.
        /// </summary>
        /// <param name="random">The random.</param>
        /// <param name="mode">The mode.</param>
        /// <returns>a random char</returns>
        public static char NextChar(this Random random, RandomCharType mode)
        {
            Contract.Requires<ArgumentNullException>(random != null, "random");

            switch (mode)
            {
                case RandomCharType.AlphabeticAny:
                    return random.NextAlphabeticChar();
                case RandomCharType.AlphabeticLower:
                    return random.NextAlphabeticChar(false);
                case RandomCharType.AlphabeticUpper:
                    return random.NextAlphabeticChar(true);
                case RandomCharType.AlphanumericAny:
                    return random.NextAlphanumericChar();
                case RandomCharType.AlphanumericLower:
                    return random.NextAlphanumericChar(false);
                case RandomCharType.AlphanumericUpper:
                    return random.NextAlphanumericChar(true);
                case RandomCharType.Numeric:
                    return random.NextNumericChar();
                default:
                    return random.NextAlphanumericChar();
            }
        }

        /// <summary>
        /// Gets the next random char.
        /// </summary>
        /// <param name="random">The random.</param>
        /// <returns>a random char</returns>
        public static char NextChar(this Random random)
        {
            Contract.Requires<ArgumentNullException>(random != null, "random");

            return random.NextChar(RandomCharType.AlphanumericAny);
        }

        /// <summary>
        /// Gets the next random DateTime.
        /// </summary>
        /// <param name="random">The random.</param>
        /// <param name="minValue">The min value.</param>
        /// <param name="maxValue">The max value.</param>
        /// <returns>a random date between dates specified</returns>
        public static DateTime NextDateTime(this Random random, DateTime minValue, DateTime maxValue)
        {
            Contract.Requires<ArgumentNullException>(random != null, "random");
            Contract.Requires<ArgumentOutOfRangeException>(minValue < maxValue);

            return DateTime.FromOADate(random.NextDouble(minValue.ToOADate(), maxValue.ToOADate()));
        }

        /// <summary>
        /// Gets the next random DateTime.
        /// </summary>
        /// <param name="random">The random.</param>
        /// <returns>a random date</returns>
        public static DateTime NextDateTime(this Random random)
        {
            Contract.Requires<ArgumentNullException>(random != null, "random");

            return random.NextDateTime(DateTime.MinValue, DateTime.MaxValue);
        }

        /// <summary>
        /// Gets the next random double.
        /// </summary>
        /// <param name="random">The random.</param>
        /// <param name="minValue">The min value.</param>
        /// <param name="maxValue">The max value.</param>
        /// <returns>a random double</returns>
        public static double NextDouble(this Random random, double minValue, double maxValue)
        {
            Contract.Requires<ArgumentNullException>(random != null, "random");
            Contract.Requires<ArgumentOutOfRangeException>(minValue < maxValue);

            double difference = maxValue - minValue;
            if (!double.IsInfinity(difference))
            {
                return minValue + (random.NextDouble() * difference);
            }
            else
            {
                // to avoid evaluating to Double.Infinity, we split the range into two halves:
                double halfDifference = (maxValue * 0.5) - (minValue * 0.5);

                // 50/50 chance of returning a value from the first or second half of the range
                if (random.NextBool())
                {
                    return minValue + (random.NextDouble() * halfDifference);
                }
                else
                {
                    return (minValue + halfDifference) + (random.NextDouble() * halfDifference);
                }
            }
        }

        /// <summary>
        /// Gets the next random string.
        /// </summary>
        /// <param name="random">The random.</param>
        /// <param name="length">The length of the string.</param>
        /// <param name="mode">The mode.</param>
        /// <returns>a random string</returns>
        public static string NextString(this Random random, int length, RandomCharType mode)
        {
            Contract.Requires<ArgumentNullException>(random != null, "random");
            Contract.Requires<ArgumentOutOfRangeException>(length > 0);

            char[] chars = new char[length];

            for (int i = 0; i < length; ++i)
            {
                chars[i] = random.NextChar(mode);
            }

            return new string(chars);
        }

        /// <summary>
        /// Gets the next random string.
        /// </summary>
        /// <param name="random">The random.</param>
        /// <param name="length">The string length.</param>
        /// <returns>a random string</returns>
        public static string NextString(this Random random, int length)
        {
            Contract.Requires<ArgumentNullException>(random != null, "random");
            Contract.Requires<ArgumentOutOfRangeException>(length > 0);

            return random.NextString(length, RandomCharType.AlphanumericAny);
        }

        /// <summary>
        /// Gets the next random TimeSpan.
        /// </summary>
        /// <param name="random">The random.</param>
        /// <param name="minValue">The min value.</param>
        /// <param name="maxValue">The max value.</param>
        /// <returns>a random timespan between specified values</returns>
        public static TimeSpan NextTimeSpan(this Random random, TimeSpan minValue, TimeSpan maxValue)
        {
            Contract.Requires<ArgumentNullException>(random != null, "random");

            return TimeSpan.FromMilliseconds(random.NextDouble(minValue.TotalMilliseconds, maxValue.TotalMilliseconds));
        }

        /// <summary>
        /// Gets the next random TimeSpan.
        /// </summary>
        /// <param name="random">The random.</param>
        /// <returns></returns>
        public static TimeSpan NextTimeSpan(this Random random)
        {
            Contract.Requires<ArgumentNullException>(random != null, "random");

            return random.NextTimeSpan(TimeSpan.MinValue, TimeSpan.MaxValue);
        }

        /// <summary>
        /// Returns a random element from the given list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="random">The random.</param>
        /// <param name="list">The list of things to choose from.</param>
        /// <returns>a random item from a list</returns>
        public static T OneOf<T>(this Random random, IList<T> list)
        {
            Contract.Requires<ArgumentNullException>(random != null, "random");
            Contract.Requires<ArgumentNullException>(list != null, "list");
            Contract.Requires<ArgumentException>(list.Count > 0);

            return list[random.Next(list.Count)];
        }

        /// <summary>
        /// Gets the next random alphabetic character.
        /// </summary>
        /// <param name="random">The random.</param>
        /// <param name="uppercase">if set to <c>true</c> returns an uppercase char, else a lowercase char.</param>
        /// <returns>a random char of the specified case</returns>
        private static char NextAlphabeticChar(this Random random, bool uppercase)
        {
            if (uppercase)
            {
                return (char)random.Next(65, 91);
            }
            else
            {
                return (char)random.Next(97, 123);
            }
        }

        /// <summary>
        /// Gets the next random alphabetic character of either case.
        /// </summary>
        /// <param name="random">The random.</param>
        /// <returns>a random alphabetic char</returns>
        private static char NextAlphabeticChar(this Random random)
        {
            return random.NextAlphabeticChar(random.NextBool());
        }

        /// <summary>
        /// Gets the next random alphanumeric character.
        /// </summary>
        /// <param name="random">The random.</param>
        /// <param name="uppercase">if set to <c>true</c> returns an uppercase char, else a lowercase char.</param>
        /// <returns>a random alphanumeric char of the specified case</returns>
        private static char NextAlphanumericChar(this Random random, bool uppercase)
        {
            bool numeric = random.NextBool(AlphanumericProbabilityNumericCased);

            if (numeric)
            {
                return random.NextNumericChar();
            }
            else
            {
                return random.NextAlphabeticChar(uppercase);
            }
        }

        /// <summary>
        /// Gets the next random alphanumeric character of either case.
        /// </summary>
        /// <param name="random">The random.</param>
        /// <returns>a random alphanumeric char</returns>
        private static char NextAlphanumericChar(this Random random)
        {
            bool numeric = random.NextBool(AlphanumericProbabilityNumericAny);

            if (numeric)
            {
                return random.NextNumericChar();
            }
            else
            {
                return random.NextAlphabeticChar(random.NextBool());
            }
        }

        /// <summary>
        /// Gets the next random numeric character.
        /// </summary>
        /// <param name="random">The random.</param>
        /// <returns>a random numeric char</returns>
        private static char NextNumericChar(this Random random)
        {
            return (char)random.Next(48, 58);
        }
    }
}
