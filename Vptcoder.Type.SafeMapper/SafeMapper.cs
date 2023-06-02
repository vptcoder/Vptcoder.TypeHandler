using System;
using System.Reflection;

namespace Vptcoder.Type.SafeMapper
{
    public class Mapper
    {
        public static object[] MapToObjectArray(MethodInfo method, params object[] values)
        {
            List<object> result = new List<object>();

            try
            {

            }
            catch (Exception ex)
            {
                // log exception
                throw;
            }

            return result;

        }

    }
}

