using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace pokenae_WebApp.Extensions
{
    public static class CustomSelectDialogExtensions
    {
        public static IHtmlContent CustomSelectDialogFor<TModel>(this IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, string>> expression, string buttonText, List<string> items)
        {
            var id = htmlHelper.IdFor(expression);
            var name = htmlHelper.NameFor(expression);
            var selectedValue = htmlHelper.ValueFor(expression).ToString();

            var model = new pokenae_WebApp.Pages.CustomSelectDialogModel
            {
                Id = id,
                Name = name,
                ButtonText = buttonText,
                Items = items,
                SelectedValue = selectedValue
            };

            return htmlHelper.Partial("CustomSelectDialog", model);
        }
    }
}

