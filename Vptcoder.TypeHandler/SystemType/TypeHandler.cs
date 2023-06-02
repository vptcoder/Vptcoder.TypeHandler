using System;
using Vptcoder.Type.Interface;
using Vptcoder.Type.Extensions;

namespace Vptcoder.SystemType
{
    public class TypeHandler : ITypeHandler
    {
        /// <summary>
        /// (Generic) Primary method for Type Conversion.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidCastException"></exception>
        public virtual T ChangeType<T>(object value)
        {
            var conversionType = typeof(T);

            return (T)ChangeType(value, conversionType);
        }

        /// <summary>
        /// Primary method for Type Conversion.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="conversionType"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidCastException"></exception>
        public virtual object ChangeType(object value, System.Type conversionType)
        {
            if (conversionType == null)
            {
                throw new ArgumentNullException("Conversion Type cannot be null.");
            }

            bool nullable;

            var t = conversionType.GetNullableUnderLyingType(out nullable);

            if (value is null && nullable)
            {
                return null;
            }

            if (value.GetType() == typeof(string))
            {
                return (value as string).ChangeType(t);
            }

            if (value is IConvertible)
            {
                return Convert.ChangeType(value, t);
            }

            throw new InvalidCastException("This conversion is not supported.");
        }
    }
}

