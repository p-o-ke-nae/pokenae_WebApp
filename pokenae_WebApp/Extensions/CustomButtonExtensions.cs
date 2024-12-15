using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq.Expressions;

namespace pokenae_WebApp.Extensions
{
    public static class CustomButtonExtensions
    {
        public static IHtmlContent CustomButtonFor<TModel>(this IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, string>> expression, string buttonText)
        {
            var id = htmlHelper.IdFor(expression);
            var name = htmlHelper.NameFor(expression);

            var model = new pokenae_WebApp.Pages.CustomButtonModel
            {
                Id = id,
                Name = name,
                ButtonText = buttonText
            };

            return htmlHelper.Partial("CustomButton", model);
        }

        public static IHtmlContent CustomButtonPostFor<TModel>(this IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, string>> expression, string buttonText, string url)
        {
            var id = htmlHelper.IdFor(expression);
            var name = htmlHelper.NameFor(expression);

            var model = new pokenae_WebApp.Pages.CustomButtonPostModel
            {
                Id = id,
                Name = name,
                ButtonText = buttonText,
                Url = url
            };

            return htmlHelper.Partial("CustomButtonPost", model);
        }

        public static IHtmlContent CustomButtonNavigationFor<TModel>(this IHtmlHelper<TModel> htmlHelper, string buttonText, string url)
        {
            var model = new pokenae_WebApp.Pages.Shared.CustomNavigationButtonModel
            {
                ButtonText = buttonText,
                Url = url
            };

            return htmlHelper.Partial("CustomButtonNavigation", model);
        }
    }
}

