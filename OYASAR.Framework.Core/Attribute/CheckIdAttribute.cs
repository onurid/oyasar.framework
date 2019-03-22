using System;
using OYASAR.Framework.Core.Exceptions;
using OYASAR.Framework.Core.Helper;
using OYASAR.Framework.Core.Interface;

namespace OYASAR.Framework.Core.Attribute
{
    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = true)]
    public class CheckIdAttribute : System.Attribute, IValidationAttribute
    {
        public void Validate(object value)
        {
            if (ValidationHelper.CheckId((int) value))
                throw new BusinessException("Id can not zero (0) or null");
        }
    }
}
