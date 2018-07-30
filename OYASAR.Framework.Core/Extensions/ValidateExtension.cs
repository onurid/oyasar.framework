using OYASAR.Framework.Core.Exceptions;

namespace OYASAR.Framework.Core.Extensions
{
    public static class ValidateExtension
    {
        public static T ToCheck<T>(this T obj, string errMsg)
        {
            if (obj == null)
                throw new BusinessException(errMsg);

            return obj;
        }
     }
}
