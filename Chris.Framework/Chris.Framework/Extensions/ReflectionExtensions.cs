using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Chris.Framework.Extensions
{
    public static class ReflectionExtensions
    {
        public static bool IsNullableType(this Type type, Type argumentType)
        {
            if (type.GetTypeInfo().IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                return Nullable.GetUnderlyingType(type) == argumentType;
            }
            return false;
        }
        public static bool IsNullableEnum(this Type type)
        {
            if (type.GetTypeInfo().IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                return Nullable.GetUnderlyingType(type).GetTypeInfo().IsEnum;
            }
            return false;
        }
        public static bool HasAttribute<T>(this Type provider, bool inherit = false) where T : Attribute
        {
            return provider.GetTypeInfo().IsDefined(typeof(T), inherit);
        }
        public static IEnumerable<T> GetAttributes<T>(this Type provider, bool inherit = false) where T : Attribute
        {
            return provider.GetTypeInfo().GetCustomAttributes<T>(inherit);
        }
        public static T GetAttribute<T>(this Type provider, bool inherit = false) where T : Attribute
        {
            return provider.GetTypeInfo().GetCustomAttributes<T>(inherit)?.FirstOrDefault();
        }
    }

}
