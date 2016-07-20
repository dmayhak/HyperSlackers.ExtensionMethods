using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperSlackers.Extensions
{
    public static partial class ExtensionMethods
    {
        public static double StandardDeviation(this IEnumerable<int> source, bool isEntirePopulation = false)
        {
            Helpers.ThrowIfNull(source != null, "source");

            return StandardDeviation(source.Select(x => (double)x));
        }

        public static double StandardDeviation(this IEnumerable<long> source, bool isEntirePopulation = false)
        {
            Helpers.ThrowIfNull(source != null, "source");

            return StandardDeviation(source.Select(x => (double)x));
        }

        public static double StandardDeviation(this IEnumerable<float> source, bool isEntirePopulation = false)
        {
            Helpers.ThrowIfNull(source != null, "source");

            return StandardDeviation(source.Select(x => (double)x));
        }

        public static double StandardDeviation(this IEnumerable<double> source, bool isEntirePopulation = false)
        {
            Helpers.ThrowIfNull(source != null, "source");

            var data = source.ToList();
            var average = data.Average();
            var differences = data.Select(u => Math.Pow(average - u, 2.0)).ToList();

            return Math.Sqrt(differences.Sum() / (differences.Count() - (isEntirePopulation ? 0 : (data.Count <= 1 ? 0 : 1 ))));
        }
    }
}
