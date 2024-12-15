using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq.Expressions;

namespace pokenae_WebApp.Extensions
{
    public static class CustomMessageAreaExtensions
    {
        public static IHtmlContent CustomMessageAreaFor<TModel>(this IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, string>> expression)
        {
           var name = htmlHelper.NameFor(expression);

            var model = new pokenae_WebApp.Pages.CustomMessageAreaModel
            {
                Name = name,
            };

            return htmlHelper.Partial("CustomMessageArea", model);
        }
    }
}

