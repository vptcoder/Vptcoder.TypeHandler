using System;
using System.Collections.Generic;
using System.Reflection;
using Vptcoder.SystemType;

namespace Vptcoder.Type
{
    public class Mapper
    {
        public static object[] MapToMethodParams(MethodInfo method, params object[] values)
        {
            TypeHandler handler = new TypeHandler();
            List<object> result = new List<object>();

            ParameterInfo[] parameters = method.GetParameters();

            for (int i = 0; i < parameters.Length; i++)
            {
                if (values[i] == null)
                {
                    result.Add(handler.ChangeType(values[i], parameters[i].ParameterType));
                }
            }

            return result.ToArray();

        }
    }
}

