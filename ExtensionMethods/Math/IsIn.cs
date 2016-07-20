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
        /// Returns true if input is in specified list; false otherwise.
        /// (from http://stackoverflow.com/questions/271398/what-are-your-favorite-extension-methods-for-c-codeplex-com-extensionoverflow)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input">The input.</param>
        /// <param name="list">The list.</param>
        /// <returns>
        /// true if input is in specified list; false otherwise
        /// </returns>
        /// <exception cref="System.ArgumentNullException">input</exception>
        public static bool IsIn<T>(this T input, params T[] list)
        {
            Helpers.ThrowIfNull(input != null, "input");
            Helpers.ThrowIfNull(list != null, "list");

            return list.Contains(input);
        }
    }
}
