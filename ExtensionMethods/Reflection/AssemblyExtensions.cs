using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HyperSlackers.Extensions
{
    public static partial class ExtensionMethods
    {
        /// <summary>
        /// Gets all types in an assembly. Handles the ReflectionTypeLoadException internally.
        /// (from: http://haacked.com/archive/2012/07/23/get-all-types-in-an-assembly.aspx/)
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        /// <returns></returns>
        public static IEnumerable<Type> GetLoadableTypes(this Assembly assembly)
        {
            Contract.Requires<ArgumentNullException>(assembly != null, "assembly");
            Contract.Ensures(Contract.Result<IEnumerable<Type>>() != null);

            try
            {
                return assembly.GetTypes();
            }
            catch (ReflectionTypeLoadException e)
            {
                return e.Types.Where(t => t != null);
            }
        }
    }
}
