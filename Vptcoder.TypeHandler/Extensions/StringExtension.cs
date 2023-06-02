using System;
namespace Vptcoder.Type.Extensions
{
	public static class StringExtension
	{
        public static object ChangeType(this string value, System.Type newType)
        {
            var t = newType;

            if (t == typeof(Guid))
            {
                return new Guid(value.ToString());
            }

            return Convert.ChangeType(value, t);
        }

    }
}

