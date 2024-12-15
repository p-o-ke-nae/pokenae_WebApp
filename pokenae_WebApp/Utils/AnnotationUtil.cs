using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace pokenae_WebApp.Utils
{
    public static class AnnotationUtil
    {
        public static bool IsPropertyRequired<T>(string propertyName)
        {
            var property = GetNestedProperty(typeof(T), propertyName);
            if (property == null)
            {
                throw new ArgumentException($"Property '{propertyName}' not found on type '{typeof(T).Name}'");
            }

            var requiredAttribute = property.GetCustomAttribute<RequiredAttribute>();
            return requiredAttribute != null;
        }

        public static bool IsPropertyReadOnly<T>(string propertyName)
        {
            var property = GetNestedProperty(typeof(T), propertyName);
            if (property == null)
            {
                throw new ArgumentException($"Property '{propertyName}' not found on type '{typeof(T).Name}'");
            }

            var readOnlyAttribute = property.GetCustomAttribute<ReadOnlyAttribute>();
            return readOnlyAttribute != null && readOnlyAttribute.IsReadOnly;
        }

        public static (int? MinLength, int? MaxLength) GetStringLength<T>(string propertyName)
        {
            var property = GetNestedProperty(typeof(T), propertyName);
            if (property == null)
            {
                throw new ArgumentException($"Property '{propertyName}' not found on type '{typeof(T).Name}'");
            }

            var stringLengthAttribute = property.GetCustomAttribute<StringLengthAttribute>();
            if (stringLengthAttribute != null)
            {
                return (stringLengthAttribute.MinimumLength, stringLengthAttribute.MaximumLength);
            }

            return (null, null);
        }

        public static (double? MinValue, double? MaxValue) GetRange<T>(string propertyName)
        {
            var property = GetNestedProperty(typeof(T), propertyName);
            if (property == null)
            {
                throw new ArgumentException($"Property '{propertyName}' not found on type '{typeof(T).Name}'");
            }

            var rangeAttribute = property.GetCustomAttribute<RangeAttribute>();
            if (rangeAttribute != null)
            {
                double min = 0;
                double max = 0;
                double? resultmin = null;
                double? resultmax = null;
                if (double.TryParse(rangeAttribute.Minimum.ToString(), out min))
                {
                    resultmin = min;
                }
                if (double.TryParse(rangeAttribute.Maximum.ToString(), out max))
                {
                    resultmax = max;
                }

                return (resultmin, resultmax);
            }

            return (null, null);
        }

        public static PropertyInfo GetNestedProperty(Type type, string propertyName)
        {
            var parts = propertyName.Split('.');
            PropertyInfo property = null;

            foreach (var part in parts)
            {
                property = type.GetProperty(part);
                if (property == null)
                {
                    return null;
                }
                type = property.PropertyType;
            }

            return property;
        }
    }
}
