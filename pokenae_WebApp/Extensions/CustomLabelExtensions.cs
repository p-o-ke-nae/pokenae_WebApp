using Elfie.Serialization;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using pokenae_WebApp.Pages;
using pokenae_WebApp.Utils;
using System;
using System.Drawing;
using System.Linq.Expressions;
using System.Numerics;
using System.Reflection;
using System.Resources;

namespace pokenae_WebApp.Extensions
{
    public static class CustomLabelExtensions
    {
        private static readonly ResourceManager ResourceManager = new ResourceManager("pokenae_WebApp.Properties.ItemResource", typeof(CustomLabelExtensions).Assembly);

        public static IHtmlContent CustomLabelFor<TModel>(this IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, string>> expression)
        {
            var id = htmlHelper.IdFor(expression);
            var name = htmlHelper.NameFor(expression);

            var resource = ResourceManager.GetString(name);
            var labeltext = string.Empty;
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

            var model = new pokenae_WebApp.Pages.CustomLabelModel
            {
                Id = id,
                LabelText = labeltext
            };

            return htmlHelper.Partial("CustomLabel", model);
        }

        public static IHtmlContent CustomLabel<TModel>(this IHtmlHelper<TModel> htmlHelper, string labelText)
        {
            var model = new pokenae_WebApp.Pages.CustomLabelModel
            {
                Id = "",
                LabelText = labelText
            };

            return htmlHelper.Partial("CustomLabel", model);
        }

        #region string
        public static IHtmlContent CustomLabelHeaderFor<TModel>(this IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, string>> expression)
        {
            var name = htmlHelper.NameFor(expression);

            var resource = ResourceManager.GetString(name);
            var labeltext = string.Empty;
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

            return CustomLabelHeaderFor(htmlHelper, expression, labeltext);
        }

        public static IHtmlContent CustomLabelHeaderFor<TModel>(this IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, string>> expression, string labelText)
        {
            var id = htmlHelper.IdFor(expression);
            var name = htmlHelper.NameFor(expression);

            var model = new pokenae_WebApp.Pages.CustomLabelHeaderModel
            {
                Id = id,
                LabelText = labelText,
                IsRequired = AnnotationUtil.IsPropertyRequired<TModel>(name),
                IsReadOnly = AnnotationUtil.IsPropertyReadOnly<TModel>(name)
            };

            return htmlHelper.Partial("CustomLabelHeader", model);
        }
        #endregion

        #region êîílå^
        public static IHtmlContent CustomLabelHeaderFor<TModel,T>(this IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, T>> expression) where T : struct, INumber<T>
        {
            var name = htmlHelper.NameFor(expression);

            var resource = ResourceManager.GetString(name);
            var labeltext = string.Empty;
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

            return CustomLabelHeaderFor(htmlHelper, expression, labeltext);
        }

        public static IHtmlContent CustomLabelHeaderFor<TModel, T>(this IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, T>> expression, string labelText) where T : struct, INumber<T>
        {
            var id = htmlHelper.IdFor(expression);
            var name = htmlHelper.NameFor(expression);

            var model = new pokenae_WebApp.Pages.CustomLabelHeaderModel
            {
                Id = id,
                LabelText = labelText,
                IsRequired = AnnotationUtil.IsPropertyRequired<TModel>(name),
                IsReadOnly = AnnotationUtil.IsPropertyReadOnly<TModel>(name)
            };

            return htmlHelper.Partial("CustomLabelHeader", model);
        }
        #endregion

        #region bool
        public static IHtmlContent CustomLabelHeaderFor<TModel>(this IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, bool>> expression)
        {
            var name = htmlHelper.NameFor(expression);

            var resource = ResourceManager.GetString(name);
            var labeltext = string.Empty;
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

            return CustomLabelHeaderFor(htmlHelper, expression, labeltext);
        }

        public static IHtmlContent CustomLabelHeaderFor<TModel>(this IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, bool>> expression, string labelText)
        {
            var id = htmlHelper.IdFor(expression);
            var name = htmlHelper.NameFor(expression);

            var model = new pokenae_WebApp.Pages.CustomLabelHeaderModel
            {
                Id = id,
                LabelText = labelText,
                IsRequired = AnnotationUtil.IsPropertyRequired<TModel>(name),
                IsReadOnly = AnnotationUtil.IsPropertyReadOnly<TModel>(name)
            };

            return htmlHelper.Partial("CustomLabelHeader", model);
        }

        #endregion

        #region îCà”éwíË
        public static IHtmlContent CustomLabelHeader<TModel>(this IHtmlHelper<TModel> htmlHelper, string labelText, bool isRequired = false, bool isReadOnly = false)
        {
            string labeltext = labelText;
            
            var model = new pokenae_WebApp.Pages.CustomLabelHeaderModel
            {
                Id = "",
                LabelText = labeltext,
                IsRequired = isRequired,
                IsReadOnly = isReadOnly
            };

            return htmlHelper.Partial("CustomLabelHeader", model);
        }

        #endregion
    }

}

