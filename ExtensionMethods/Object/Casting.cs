using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartFormat;
using System.Diagnostics;

namespace HyperSlackers.Extensions
{
    public static partial class ExtensionMethods
    {
        /// <summary>
        /// Determines whether the item is of type T.
        /// from http://stackoverflow.com/questions/271398/what-are-your-favorite-extension-methods-for-c-codeplex-com-extensionoverflow?page=2&tab=votes#tab-top
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        [DebuggerStepThrough()]
        public static bool Is<T>(this object item) where T : class
        {
            return item is T;
        }

        /// <summary>
        /// Determines whether the specified item is not of type T.
        /// from http://stackoverflow.com/questions/271398/what-are-your-favorite-extension-methods-for-c-codeplex-com-extensionoverflow?page=2&tab=votes#tab-top
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        [DebuggerStepThrough()]
        public static bool IsNot<T>(this object item) where T : class
        {
            return !(item.Is<T>());
        }

        /// <summary>
        /// Casts the item to type T.
        /// from http://stackoverflow.com/questions/271398/what-are-your-favorite-extension-methods-for-c-codeplex-com-extensionoverflow?page=2&tab=votes#tab-top
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        [DebuggerStepThrough()]
        public static T As<T>(this object item) where T : class
        {
            return item as T;
        }
    }
}
