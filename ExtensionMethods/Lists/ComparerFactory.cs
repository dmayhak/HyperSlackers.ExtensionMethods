using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperSlackers.Extensions
{
    /// <summary>
    /// Creates an <see cref="IComparer{T}"/> instance for the given delegate function.
    /// from http://stackoverflow.com/questions/271398/what-are-your-favorite-extension-methods-for-c-codeplex-com-extensionoverflow
    /// </summary>
    internal class ComparerFactory<T> : IComparer<T>
    {
        public static IComparer<T> Create(Func<T, T, int> comparison)
        {
            return new ComparerFactory<T>(comparison);
        }

        private readonly Func<T, T, int> _comparison;

        private ComparerFactory(Func<T, T, int> comparison)
        {
            _comparison = comparison;
        }

        #region IComparer<T> Members

        public int Compare(T x, T y)
        {
            return _comparison(x, y);
        }

        #endregion
    }
}
