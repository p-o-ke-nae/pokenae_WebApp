using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace pokenae_WebApp.Extensions
{
    public static class CustomComboBoxExtensions
    {
        public static IHtmlContent CustomComboBoxFor<TModel>(this IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, string>> expression, List<SelectListItem> items)
        {
            var id = htmlHelper.IdFor(expression);
            var name = htmlHelper.NameFor(expression);
            var selectedValue = htmlHelper.ValueFor(expression).ToString();

            var model = new pokenae_WebApp.Pages.CustomComboBoxModel
            {
                Id = id,
                Name = name,
                Items = items,
                SelectedValue = selectedValue
            };

            return htmlHelper.Partial("CustomComboBox", model);
        }
    }
}

