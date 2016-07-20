using System;
using System.Collections.Generic;

using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace HyperSlackers.Extensions.Web.Mvc
{
    public static partial class ExtensionMethods
    {
        /// <summary>
        /// Gets the column name for a property.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TClass">The type of the class.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="helper">The helper.</param>
        /// <param name="model">The model.</param>
        /// <param name="expression">The expression.</param>
        /// <returns></returns>
        public static MvcHtmlString ColumnNameFor<TModel, TClass, TProperty>(this HtmlHelper<TModel> helper, IEnumerable<TClass> model, Expression<Func<TClass, TProperty>> expression)
        {
            Helpers.ThrowIfNull(helper != null, "helper");
            Helpers.ThrowIfNull(model != null, "model");
            Helpers.ThrowIfNull(expression != null, "expression");

            var name = ExpressionHelper.GetExpressionText(expression);
            string fullName;
            ModelMetadata metadata;

            // if name has a "." in it, we gotta go one property deeper
            if (name.Contains('.'))
            {
                List<string> names = name.SplitString('.').ToList();
                var subType = typeof(TClass).GetProperty(names[0]).PropertyType;

                fullName = helper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(names[1]);

                metadata = ModelMetadataProviders.Current.GetMetadataForProperty(() => Activator.CreateInstance(subType), subType, fullName);
            }
            else
            {
                fullName = helper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);

                metadata = ModelMetadataProviders.Current.GetMetadataForProperty(() => Activator.CreateInstance<TClass>(), typeof(TClass), fullName);
            }

            string columnName = metadata.ShortDisplayName;

            if (columnName.IsNullOrWhiteSpace())
            {
                columnName = metadata.DisplayName;
            }

            if (columnName.IsNullOrWhiteSpace())
            {
                columnName = metadata.PropertyName.SpaceOnUpperCase();
            }

            return new MvcHtmlString(columnName);
        }

        // TODO: tooltipfor, helptextfor.....  etc...
    }
}
