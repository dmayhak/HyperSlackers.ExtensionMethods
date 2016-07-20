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
        /// Appends a formatted string to the StringBuilder object.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="format">The format.</param>
        /// <param name="args">The args.</param>
        public static StringBuilder AppendLine(this StringBuilder builder, string format, params object[] args)
        {
            Helpers.ThrowIfNull(builder != null, "builder");
            Helpers.ThrowIfNull(format != null, "format");
            Helpers.ThrowIfNull(args != null, "args");

            builder.AppendLine(format.FormatWith(args));

            return builder;
        }

        /// <summary>
        /// Appends value to the StringBuilder if condition is true.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="condition">if set to <c>true</c> [condition].</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static StringBuilder AppendIf(this StringBuilder builder, bool condition, string value)
        {
            if (condition)
            {
                builder.Append(value);
            }

            return builder;
        }

        /// <summary>
        /// Appends value and newline to the StringBuilder if condition is true.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="condition">if set to <c>true</c> [condition].</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static StringBuilder AppendLineIf(this StringBuilder builder, bool condition, string value)
        {
            if (condition)
            {
                builder.AppendLine(value);
            }

            return builder;
        }

        /// <summary>
        /// Appends formatted value and newline to the StringBuilder if condition is true.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="condition">if set to <c>true</c> [condition].</param>
        /// <param name="format">The format.</param>
        /// <param name="args">The arguments.</param>
        /// <returns></returns>
        public static StringBuilder AppendLineIf(this StringBuilder builder, bool condition, string format, params object[] args)
        {
            if (condition)
            {
                builder.AppendLine(format, args);
            }

            return builder;
        }
    }
}
