using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using pokenae_WebApp.Utils;
using System;
using System.Linq.Expressions;
using System.Resources;

namespace pokenae_WebApp.Extensions
{
    public static class CustomCheckBoxExtensions
    {
        private static readonly ResourceManager ResourceManager = new ResourceManager("pokenae_WebApp.Properties.ItemResource", typeof(CustomLabelExtensions).Assembly);

        public static IHtmlContent CustomCheckBoxFor<TModel>(this IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, bool>> expression)
        {
            var name = htmlHelper.NameFor(expression);

            string labeltext = string.Empty;
            if (labeltext == "")
            {
                var resource = ResourceManager.GetString(name);
                if (!string.IsNullOrWhiteSpace(resource))
                {
                    labeltext = resource;
                }
                else
                {
                    var resourceIf = ResourceManager.GetString(AnnotationUtil.GetNestedProperty(typeof(TModel), name).Name);
                    if (!string.IsNullOrWhiteSpace(resourceIf))
                    {
                        labeltext = resourceIf;
                    }
                    else
                    {
                        labeltext = name;
                    }
                }
            }

            return CustomCheckBoxFor(htmlHelper, expression, labeltext);
        }
        public static IHtmlContent CustomCheckBoxFor<TModel>(this IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, bool>> expression, string labelText)
        {
            var id = htmlHelper.IdFor(expression);
            var name = htmlHelper.NameFor(expression);
            var isChecked = htmlHelper.ValueFor(expression).ToString() == "True";

            var model = new pokenae_WebApp.Pages.CustomCheckBoxModel
            {
                Id = id,
                Name = name,
                Label = labelText,
                IsChecked = isChecked
            };

            return htmlHelper.Partial("CustomCheckBox", model);
        }
    }
}

