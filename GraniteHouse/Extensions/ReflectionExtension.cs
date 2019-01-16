using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraniteHouse.Extensions
{
    public static class ReflectionExtension
    {
        public static string GetPropertyValue<T>(this T value, string propertyName)
        {
            return value.GetType().GetProperty(propertyName).GetValue(value, null).ToString();
        }
    }
}
