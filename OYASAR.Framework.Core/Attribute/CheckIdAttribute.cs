using System;
using OYASAR.Framework.Core.Exceptions;
using OYASAR.Framework.Core.Helper;

namespace OYASAR.Framework.Core.Attribute
{
    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = true)]
    public class CheckIdAttribute : System.Attribute
    {
        public void Validate(object value)
        {
            if (ValidationHelper.CheckId(value))
                throw new BusinessException("Id can not zero (0) or null");
        }
    }
}
