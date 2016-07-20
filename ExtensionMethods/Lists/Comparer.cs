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
        /// Sorts the elements of a sequence in ascending order by using a specified comparison delegate.
        /// from http://stackoverflow.com/questions/271398/what-are-your-favorite-extension-methods-for-c-codeplex-com-extensionoverflow
        /// </summary>
        public static IOrderedEnumerable<TSource> OrderBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TKey, TKey, int> comparison)
        {
            var comparer = ComparerFactory<TKey>.Create(comparison);

            return source.OrderBy(keySelector, comparer);
        }

        /// <summary>
        /// Sorts the elements of a sequence in descending order by using a specified comparison delegate.
        /// from http://stackoverflow.com/questions/271398/what-are-your-favorite-extension-methods-for-c-codeplex-com-extensionoverflow
        /// </summary>
        public static IOrderedEnumerable<TSource> OrderByDescending<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TKey, TKey, int> comparison)
        {
            var comparer = ComparerFactory<TKey>.Create(comparison);

            return source.OrderByDescending(keySelector, comparer);
        }
    }
}
