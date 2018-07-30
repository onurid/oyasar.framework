using System;
using OYASAR.Framework.Core.Exceptions;
using OYASAR.Framework.Core.Helper;

namespace OYASAR.Framework.Core.Attribute
{
    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = true)]
    public class CheckIsNullAttribute : System.Attribute
    {
        public void Validate(object value)
        {
            if (ValidationHelper.CheckIsNUll(value))
                throw new BusinessException("Value can not null or empty");
        }
    }
}
