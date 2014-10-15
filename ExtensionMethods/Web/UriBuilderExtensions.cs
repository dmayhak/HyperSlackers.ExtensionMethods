using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HyperSlackers.Extensions
{
    public static partial class ExtensionMethods
    {
        /// <summary>
        /// Adds the specified query parameter to the URI builder.
        /// from http://stackoverflow.com/questions/271398/what-are-your-favorite-extension-methods-for-c-codeplex-com-extensionoverflow?page=5&tab=votes#tab-top
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <param name="value">The URI escaped value.</param>
        /// <returns>The final full query string.</returns>
        public static string AddQueryParam(this UriBuilder builder, string parameterName, string value)
        {
            Contract.Requires<ArgumentNullException>(builder != null, "builder");
            Contract.Requires<ArgumentException>(!parameterName.IsNullOrWhiteSpace());
            Contract.Requires<ArgumentException>(!value.IsNullOrWhiteSpace());

            if (builder.Query.Length == 0)
            {
                builder.Query = String.Concat(parameterName, "=", value);
            }
            else if (builder.Query.Contains(String.Concat("&", parameterName, "=")) || builder.Query.Contains(String.Concat("?", parameterName, "=")))
            {
                throw new InvalidOperationException(String.Format("The parameter {0} already exists.", parameterName));
            }
            else
            {
                builder.Query = String.Concat(builder.Query.Substring(1), "&", parameterName, "=", value);
            }

            return builder.Query;
        }
    }
}
