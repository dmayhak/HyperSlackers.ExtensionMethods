using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperSlackers.Extensions
{
    /// <summary>
    /// Discrete time units used to determine where to truncate DateTime values.
    /// </summary>
    public enum TimeUnit
    {
        Second,
        Minute,
        Hour,
        Day,
        Month,
        Year
    }
}
