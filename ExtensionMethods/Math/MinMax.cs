using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperSlackers.Extensions
{
    public static partial class ExtensionMethods
    {
        public static T Min<T>(params T[] list)
        {
            return list.Min();
        }

        public static T Max<T>(params T[] list)
        {
            return list.Max();
        }
    }
}
