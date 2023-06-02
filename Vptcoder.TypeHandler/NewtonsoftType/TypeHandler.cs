using System;
using Vptcoder.SystemType;
using Vptcoder.Type.Interface;
using Vptcoder.Type.Extensions;
using Newtonsoft.Json.Linq;

namespace Vptcoder.NewtonsoftType
{
	public class TypeHandler : SystemType.TypeHandler, ITypeHandler
	{
        /// <summary>
        /// (Generic) Primary method for conversion from Newtonsoft Json.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidCastException"></exception>
        public T ChangType<T>(object value)
        {
            var conversionType = typeof(T);

            return (T)ChangeType(value, conversionType);
        }

        /// <summary>
        /// Primary method for conversion from Newtonsoft Json.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="conversionType"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidCastException"></exception>
        public override object ChangeType(object value, System.Type conversionType)
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

            if(value.GetType() == typeof(JArray))
            {
                return (value as JArray).ToObject(t);
            }
            if (value.GetType() == typeof(JObject))
            {
                return (value as JObject).ToObject(t);
            }
            if (value.GetType() == typeof(JProperty))
            {
                return (value as JProperty).ToObject(t);
            }
            if (value.GetType() == typeof(JContainer))
            {
                return (value as JContainer).ToObject(t);
            }
            if (value.GetType() == typeof(JValue))
            {
                return (value as JValue).ToObject(t);
            }
            if (value.GetType() == typeof(JToken))
            {
                return (value as JToken).ToObject(t);
            }

            // if value is not a Newtonsoft Type, fall back to base implementation
            return base.ChangeType(value, conversionType);
		}
    }
}

