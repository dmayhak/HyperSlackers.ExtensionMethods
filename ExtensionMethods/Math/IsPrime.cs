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
        /// Determines whether the specified value is prime.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns><c>true</c> if the number is prime, <c>false</c> otherwise.</returns>
        public static bool IsPrime(this int value)
        {
            if ((value % 2) == 0)
            {
                return value == 2;
            }

            int sqrt = (int)Math.Sqrt(value);
            for (int i = 3; i <= sqrt; i += 2)
            {
                if (value % i == 0)
                {
                    return false;
                }
            }

            return value != 1;
        }

        /// <summary>
        /// Determines whether the specified value is prime.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns><c>true</c> if the number is prime, <c>false</c> otherwise.</returns>
        public static bool IsPrime(this long value)
        {
            if ((value % 2) == 0)
            {
                return value == 2;
            }

            int sqrt = (int)Math.Sqrt(value);
            for (int i = 3; i <= sqrt; i += 2)
            {
                if (value % i == 0)
                {
                    return false;
                }
            }

            return value != 1;
        }
    }
}
