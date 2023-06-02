using System;
namespace Vptcoder.Type.Extensions
{
    public static class TypeExtension
    {
        /// <summary>
        /// Extension Method: Get the underlying type if Nullable.
        /// </summary>
        /// <param name="conversionType"></param>
        /// <param name="nullable"></param>
        /// <returns></returns>
        public static System.Type GetNullableUnderLyingType(this System.Type conversionType, out bool nullable)
        {
            var t = conversionType;
            nullable = false;

            if (t.IsGenericType && t.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
            {
                t = Nullable.GetUnderlyingType(t);
                nullable = true;
            }

            return t;
        }
    }
}

