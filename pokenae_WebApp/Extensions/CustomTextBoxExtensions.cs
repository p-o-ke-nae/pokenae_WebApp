using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Linq.Expressions;
using System.Numerics;

namespace pokenae_WebApp.Extensions
{
    public static class CustomTextBoxExtensions
    {
        /// <summary>
        /// stringå^
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="htmlHelper"></param>
        /// <param name="expression"></param>
        /// <param name="rows"></param>
        /// <returns></returns>
        public static IHtmlContent CustomTextBoxFor<TModel>(this IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, string>> expression)
        {
            var id = htmlHelper.IdFor(expression);
            var name = htmlHelper.NameFor(expression);
            var text = htmlHelper.ValueFor(expression).ToString();

            var (minLength, maxLength) = Utils.AnnotationUtil.GetStringLength<TModel>(name);

            var model = new pokenae_WebApp.Pages.CustomTextBoxModel
            {
                Id = id,
                Name = name,
                Text = text,
                IsRequired = Utils.AnnotationUtil.IsPropertyRequired<TModel>(name),
                IsReadOnly = Utils.AnnotationUtil.IsPropertyReadOnly<TModel>(name),
                DataValLengthMax = maxLength ?? -1,
                DataValLengthMin = minLength ?? -1
            };

            return htmlHelper.Partial("CustomTextBox", model);
        }

        /// <summary>
        /// stringå^
        /// ï°êîçs
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="htmlHelper"></param>
        /// <param name="expression"></param>
        /// <param name="rows"></param>
        /// <returns></returns>
        public static IHtmlContent CustomTextBoxFor<TModel>(this IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, string>> expression, int rows)
        {
            var id = htmlHelper.IdFor(expression);
            var name = htmlHelper.NameFor(expression);
            var text = htmlHelper.ValueFor(expression).ToString();

            var (minLength, maxLength) = Utils.AnnotationUtil.GetStringLength<TModel>(name);

            var model = new pokenae_WebApp.Pages.CustomTextBoxTextAreaModel
            {
                Id = id,
                Name = name,
                Rows = rows,
                Text = text,
                IsRequired = Utils.AnnotationUtil.IsPropertyRequired<TModel>(name),
                IsReadOnly = Utils.AnnotationUtil.IsPropertyReadOnly<TModel>(name),
                DataValLengthMax = maxLength ?? -1,
                DataValLengthMin = minLength ?? -1
            };

            return htmlHelper.Partial("CustomTextBoxTextArea", model);
        }

        /// <summary>
        /// êîílå^
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="htmlHelper"></param>
        /// <param name="expression"></param>
        /// <param name="rows"></param>
        /// <returns></returns>
        public static IHtmlContent CustomTextBoxFor<TModel, T>(this IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, T>> expression, double step = 1) where T : struct, INumber<T>
        {
            var id = htmlHelper.IdFor(expression);
            var name = htmlHelper.NameFor(expression);
            var text = htmlHelper.ValueFor(expression).ToString();
            
            var (minValue, maxValue) = Utils.AnnotationUtil.GetRange<TModel>(name);

            var model = new pokenae_WebApp.Pages.CustomTextBoxSpinBoxModel
            {
                Id = id,
                Name = name,
                Value = text,
                IsRequired = Utils.AnnotationUtil.IsPropertyRequired<TModel>(name),
                IsReadOnly = Utils.AnnotationUtil.IsPropertyReadOnly<TModel>(name),
                MaxValue = maxValue,
                MinValue = minValue,
                Step = step
            };

            return htmlHelper.Partial("CustomTextBoxSpinBox", model);
        }
    }
}

