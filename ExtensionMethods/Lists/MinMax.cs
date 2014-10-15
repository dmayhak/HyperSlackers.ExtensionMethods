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
        /// Returns the object with the min value in the property specified.
        /// from http://stackoverflow.com/questions/271398/what-are-your-favorite-extension-methods-for-c-codeplex-com-extensionoverflow?page=2&tab=votes#tab-top
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="sequence">The sequence.</param>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        public static T ObjectWithMin<T, TResult>(this IEnumerable<T> sequence, Func<T, TResult> predicate)
            where T : class
            where TResult : IComparable
        {
            if (!sequence.Any()) return null;

            //get the first object with its predicate value
            var seed = sequence.Select(x => new { Object = x, Value = predicate(x) }).FirstOrDefault();
            //compare against all others, replacing the accumulator with the lesser value
            //tie goes to first object found
            return
                sequence.Select(x => new { Object = x, Value = predicate(x) })
                    .Aggregate(seed, (acc, x) => acc.Value.CompareTo(x.Value) <= 0 ? acc : x).Object;
        }

        /// <summary>
        /// Returns the object with the max value in the property specified.
        /// from http://stackoverflow.com/questions/271398/what-are-your-favorite-extension-methods-for-c-codeplex-com-extensionoverflow?page=2&tab=votes#tab-top
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="sequence">The sequence.</param>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        public static T ObjectWithMax<T, TResult>(this IEnumerable<T> sequence, Func<T, TResult> predicate)
            where T : class
            where TResult : IComparable
        {
            if (!sequence.Any()) return null;

            //get the first object with its predicate value
            var seed = sequence.Select(x => new { Object = x, Value = predicate(x) }).FirstOrDefault();
            //compare against all others, replacing the accumulator with the greater value
            //tie goes to last object found
            return
                sequence.Select(x => new { Object = x, Value = predicate(x) })
                    .Aggregate(seed, (acc, x) => acc.Value.CompareTo(x.Value) > 0 ? acc : x).Object;
        }
    }
}
