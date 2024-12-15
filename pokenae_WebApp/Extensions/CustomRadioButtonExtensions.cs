using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using pokenae_WebApp.Pages;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace pokenae_WebApp.Extensions
{
    public static class CustomRadioButtonExtensions
    {
        public static IHtmlContent CustomRadioButtonFor<TModel>(this IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, string>> expression, List<RadioButtonOption> options)
        {
            var id = htmlHelper.IdFor(expression);
            var name = htmlHelper.NameFor(expression);
            var selectedOption = htmlHelper.ValueFor(expression).ToString();

            var model = new pokenae_WebApp.Pages.CustomRadioButtonModel
            {
                Id = id,
                Name = name,
                Options = options,
                SelectedOption = selectedOption
            };

            return htmlHelper.Partial("CustomRadioButton", model);
        }
    }
}

