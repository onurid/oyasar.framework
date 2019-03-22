using System;
using OYASAR.Framework.Core.Exceptions;
using OYASAR.Framework.Core.Helper;
using OYASAR.Framework.Core.Interface;

namespace OYASAR.Framework.Core.Attribute
{
    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = true)]
    public class CheckIsNullOrEmptyAttribute : System.Attribute, IValidationAttribute
    {
        public void Validate(object value)
        {
            if (ValidationHelper.CheckIsNullOrEmpty((string) value))
                throw new BusinessException("Value can not null or empty");
        }
    }
}
