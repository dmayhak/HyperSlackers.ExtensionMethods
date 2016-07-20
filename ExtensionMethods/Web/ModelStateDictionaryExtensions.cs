using System;
using System.Collections.Generic;

using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace HyperSlackers.Extensions.Web.Mvc
{
    public static partial class ExtensionMethods
    {
        /// <summary>
        /// Removes an item from the ModelStateDictionary.
        /// </summary>
        /// <typeparam name="TViewModel">The type of the view model.</typeparam>
        /// <param name="value">The ModelStateDictionary.</param>
        /// <param name="expression">The expression representing what to remove.</param>
        public static void Remove<TViewModel>(this ModelStateDictionary value, Expression<Func<TViewModel, object>> expression)
        {
            Helpers.ThrowIfNull(value != null, "value");
            Helpers.ThrowIfNull(expression != null, "expression");

            value.Remove(GetPropertyName(expression));
        }

        /// <summary>
        /// Gets the name of the property from an expression.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <returns>the property name</returns>
        private static string GetPropertyName(this Expression expression)
        {
            Helpers.ThrowIfNull(expression != null, "expression");

            var e = expression;

            while (true)
            {
                switch (e.NodeType)
                {
                    case ExpressionType.Lambda:
                        e = ((LambdaExpression)e).Body;
                        break;
                    case ExpressionType.MemberAccess:
                        var propertyInfo = ((MemberExpression)e).Member as PropertyInfo;
                        return propertyInfo != null ? propertyInfo.Name : string.Empty;
                    case ExpressionType.Convert:
                        e = ((UnaryExpression)e).Operand;
                        break;
                    default:
                        return string.Empty;
                }
            }
        }
    }
}
