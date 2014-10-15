using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperSlackers.Extensions
{
    public static partial class ExtensionMethods
    {
        /// <summary>
        /// Returns the data as a pipe '|' delimited string with headers.
        /// </summary>
        /// <param name="value">The data</param>
        /// <returns>The CSV string</returns>
        public static string ToCsvString(this IOrderedQueryable value)
        {
            Contract.Requires<ArgumentNullException>(value != null, "value");

            return ToCsvString(value, "|", string.Empty);
        }

        /// <summary>
        /// Returns the data as a delimited string with headers.
        /// </summary>
        /// <param name="value">The data</param>
        /// <param name="delimiter">The delimiter</param>
        /// <returns>The CSV string</returns>
        public static string ToCsvString(this IOrderedQueryable value, string delimiter)
        {
            Contract.Requires<ArgumentNullException>(value != null, "value");
            Contract.Requires<ArgumentNullException>(delimiter != null, "delimiter");

            return ToCsvString(value, delimiter, string.Empty);
        }

        /// <summary>
        /// Returns the data as a delimited string with headers.
        /// </summary>
        /// <param name="value">The data</param>
        /// <param name="delimiter">The delimiter</param>
        /// <param name="nullValue">The value to display for null values</param>
        /// <returns>The CSV string</returns>
        public static string ToCsvString(this IOrderedQueryable value, string delimiter, string nullValue)
        {
            Contract.Requires<ArgumentNullException>(value != null, "value");
            Contract.Requires<ArgumentNullException>(delimiter != null, "delimiter");
            Contract.Requires<ArgumentNullException>(nullValue != null, "nullValue");

            StringBuilder csv = new StringBuilder();

            string replaceFrom = delimiter.Trim();
            string replaceDelimiter = ";";
            switch (replaceFrom)
            {
                case "|":
                    replaceDelimiter = ":";
                    break;
                case ";":
                    replaceDelimiter = ":";
                    break;
                case ",":
                    replaceDelimiter = ";";
                    break;
                case "\t":
                    replaceDelimiter = "    ";
                    break;
                default:
                    break;
            }

            System.Reflection.PropertyInfo[] headers = value.ElementType.GetProperties();
            if (headers.Length > 0)
            {
                StringBuilder line = new StringBuilder();

                foreach (var head in headers)
                {
                    line.Append(head.Name.Replace("_", " ") + delimiter);
                }

                // trim off last delimiter
                string l = line.ToString();
                l = l.Substring(0, l.Length - delimiter.Length);

                csv.Append(l + System.Environment.NewLine);
            }

            foreach (var row in value)
            {
                StringBuilder line = new StringBuilder();

                var fields = row.GetType().GetProperties();
                for (int i = 0; i < fields.Length; i++)
                {
                    object obj = null;
                    try
                    {
                        obj = fields[i].GetValue(row, null);
                    }
                    catch { }
                    if (obj != null)
                    {
                        line.Append(obj.ToString().Replace("\r", "\f").Replace("\n", " \f").Replace("_", " ").Replace(replaceFrom, replaceDelimiter) + delimiter);
                    }
                    else
                    {
                        line.Append(nullValue);
                    }

                    line.Append(delimiter);
                }

                // trim off last delimiter
                string l = line.ToString();
                l = l.Substring(0, l.Length - delimiter.Length);

                csv.Append(l + System.Environment.NewLine);
            }

            return csv.ToString();
        }
    }
}
