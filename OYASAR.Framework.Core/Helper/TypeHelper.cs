using System;
using System.Reflection;

namespace OYASAR.Framework.Core.Helper
{
#if (NET451 || NETSTANDARD1_3 || NET35)
    public static class TypeHelper
    {
        public static bool IsAssignableFrom(Type fistType, Type secondType)
        {
            return secondType.IsAssignableFrom(fistType);
        }

        public static MethodInfo[] GetMethods<T>()
        {
            var type = typeof(T);

            return type.GetMethods();
        }
    }
#endif
}
