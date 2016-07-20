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
        /// Gets the file extension from the uri.
        /// </summary>
        /// <param name="value">The file extension, or string.Empty if none.</param>
        /// <returns></returns>
        public static string FileExt(this Uri value)
        {
            Helpers.ThrowIfNull(value != null, "value");

            string[] parts = value.FileName().Split('.');
            string fileName = "";

            if (parts.Length > 0)
            {
                fileName = parts[parts.Length - 1];
            }
            else
            {
                fileName = string.Empty;
            }

            return fileName;
        }

        /// <summary>
        /// Gets the file name part of the url.
        /// </summary>
        /// <param name="value">The uri.</param>
        /// <returns></returns>
        public static string FileName(this Uri value)
        {
            Helpers.ThrowIfNull(value != null, "value");

            string[] parts = value.AbsoluteUri.Split('/');
            string fileName = "";

            if (parts.Length > 0)
            {
                fileName = parts[parts.Length - 1];
            }
            else
            {
                fileName = value.AbsoluteUri;
            }

            // return only stuff before the '?'
            return fileName.LeftBefore("?");
        }
    }
}
