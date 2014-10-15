using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperSlackers.Extensions
{
    public static partial class ExtensionMethods
    {
        /// <summary>
        /// Returns true if the supplied enum contains all of the specified flags.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="flags">The flags.</param>
        /// <returns>
        /// true if value contains all flags, false otherwise
        /// </returns>
        /// <exception cref="System.InvalidOperationException">Enum type mismatch</exception>
        public static bool IncludesAll(this Enum value, Enum flags)
        {
            Contract.Requires<ArgumentNullException>(value != null, "value");
            Contract.Requires<ArgumentNullException>(flags != null, "flags");

            if (value.GetType() != flags.GetType())
            {
                throw new InvalidOperationException("Enum type mismatch");
            }

            long a = Convert.ToInt64(value);
            long b = Convert.ToInt64(flags);

            return (a & b) == b;
        }

        /// <summary>
        /// Returns true if the supplied enum contains any of the specified flags.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="flags">The flags.</param>
        /// <returns>
        /// true if value contains any flags, false otherwise
        /// </returns>
        /// <exception cref="System.InvalidOperationException">Enum type mismatch</exception>
        public static bool IncludesAny(this Enum value, Enum flags)
        {
            Contract.Requires<ArgumentNullException>(value != null, "value");
            Contract.Requires<ArgumentNullException>(flags != null, "flags");

            if (value.GetType() != flags.GetType())
            {
                throw new InvalidOperationException("Enum type mismatch");
            }

            long a = Convert.ToInt64(value);
            long b = Convert.ToInt64(flags);

            return (a & b) != 0L;
        }
    }
}
