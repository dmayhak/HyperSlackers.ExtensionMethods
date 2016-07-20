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
        /// Groups the elements of a sequence according to a specified firstKey selector function and rotates the unique values from the
        /// secondKey selector function into multiple values in the output, and performs aggregations.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <typeparam name="TFirstKey">The type of the first key.</typeparam>
        /// <typeparam name="TSecondKey">The type of the second key.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="firstKeySelector">The first key selector.</param>
        /// <param name="secondKeySelector">The second key selector.</param>
        /// <param name="aggregate">The aggregate.</param>
        /// <returns></returns>
        public static Dictionary<TFirstKey, Dictionary<TSecondKey, TValue>> Pivot<TSource, TFirstKey, TSecondKey, TValue>(this IEnumerable<TSource> source, Func<TSource, TFirstKey> firstKeySelector, Func<TSource, TSecondKey> secondKeySelector, Func<IEnumerable<TSource>, TValue> aggregate)
        {
            Helpers.ThrowIfNull(source != null, "source");
            Helpers.ThrowIfNull(firstKeySelector != null, "firstKeySelector");

            var retVal = new Dictionary<TFirstKey, Dictionary<TSecondKey, TValue>>();

            var l = source.ToLookup(firstKeySelector);
            foreach (var item in l)
            {
                var dict = new Dictionary<TSecondKey, TValue>();
                retVal.Add(item.Key, dict);
                var subdict = item.ToLookup(secondKeySelector);
                foreach (var subitem in subdict)
                {
                    dict.Add(subitem.Key, aggregate(subitem));
                }
            }
            return retVal;
        }

        /// <summary>
        /// Provides a Distinct method that takes a key selector lambda as parameter. The .net framework
        /// only provides a Distinct method that takes an instance of an implementation of IEqualityComparer<T>
        /// where the standard parameterless Distinct that uses the default equality comparer doesn't suffice.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <param name="source">The this.</param>
        /// <param name="keySelector">The key selector.</param>
        /// <returns></returns>
        public static IEnumerable<T> Distinct<T, TKey>(this IEnumerable<T> source, Func<T, TKey> keySelector)
        {
            Helpers.ThrowIfNull(source != null, "source");
            Helpers.ThrowIfNull(keySelector != null, "keySelector");

            return source.GroupBy(keySelector).Select(grps => grps).Select(e => e.First());
        }

        /// <summary>
        /// Shortcut for foreach
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The source.</param>
        /// <param name="action">The action.</param>
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            Helpers.ThrowIfNull(source != null, "source");

            foreach (var item in source)
            {
                action(item);
            }
        }

        /// <summary>
        /// When building a LINQ query, you may need to involve optional filtering criteria. Avoids if statements
        /// when building predicates & lambdas for a query. Useful when you don't know at compile time
        /// whether a filter should apply. Borrowed from Andrew Robinson. http://bit.ly/1V36G9
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="condition">if set to <c>true</c> [condition].</param>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        public static IEnumerable<TSource> WhereIf<TSource>(this IEnumerable<TSource> source, bool condition, Func<TSource, bool> predicate)
        {
            if (condition)
                return source.Where(predicate);
            else
                return source;
        }

        /// <summary>
        /// When building a LINQ query, you may need to involve optional filtering criteria. Avoids if statements
        /// when building predicates & lambdas for a query. Useful when you don't know at compile time
        /// whether a filter should apply. Borrowed from Andrew Robinson. http://bit.ly/1V36G9
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="condition">if set to <c>true</c> [condition].</param>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        public static IEnumerable<TSource> WhereIf<TSource>(this IEnumerable<TSource> source, bool condition, Func<TSource, int, bool> predicate)
        {
            if (condition)
                return source.Where(predicate);
            else
                return source;
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance. Applies the format string to each item in the list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <param name="format">The format.</param>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public static string ToString<T>(this IEnumerable<T> value, string format, bool addNewLine = false)
        {
            return value.ToString(item => format.FormatWith(item), addNewLine); // uses SmartFormat behind the scenes...
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance. Calls formatFunction on each item in the list to format the item.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <param name="formatFunction">The format function.</param>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public static string ToString<T>(this IEnumerable<T> value, Func<T, object> formatFunction, bool addNewLine = false)
        {
            var result = new StringBuilder();

            foreach (var item in value)
            {
                result.Append(formatFunction(item) + (addNewLine ? Environment.NewLine : string.Empty));
            }

            return result.ToString();
        }

        /// <summary>
        /// Joins the IEnumerable items into a string with each item delimited by separator.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <param name="separator">The separator.</param>
        /// <returns></returns>
        public static string Join<T>(this IEnumerable<T> value, string separator)
        {
            return String.Join(separator, value);
        }
    }
}
