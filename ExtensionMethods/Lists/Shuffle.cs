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
        /// Shuffles the order of the list.
        /// from http://stackoverflow.com/questions/271398/what-are-your-favorite-extension-methods-for-c-codeplex-com-extensionoverflow?page=2&tab=votes#tab-top
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">source</exception>
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
        {
            if (source == null) throw new ArgumentNullException("source");

            return ShuffleIterator(source);
        }

        /// <summary>
        /// Shuffle iterator.
        /// from http://stackoverflow.com/questions/271398/what-are-your-favorite-extension-methods-for-c-codeplex-com-extensionoverflow?page=2&tab=votes#tab-top
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        private static IEnumerable<T> ShuffleIterator<T>(this IEnumerable<T> source)
        {
            T[] array = source.ToArray();
            Random rnd = new Random();

            for (int n = array.Length; n > 1; )
            {
                int k = rnd.Next(n--); // 0 <= k < n

                //Swap items
                if (n != k)
                {
                    T tmp = array[k];
                    array[k] = array[n];
                    array[n] = tmp;
                }
            }

            foreach (var item in array)
            {
                yield return item;
            }
        }
    }
}
