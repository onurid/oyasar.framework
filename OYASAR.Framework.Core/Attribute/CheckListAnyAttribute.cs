using System;
using System.Collections;
using OYASAR.Framework.Core.Exceptions;
using OYASAR.Framework.Core.Helper;
using OYASAR.Framework.Core.Interface;

namespace OYASAR.Framework.Core.Attribute
{
    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = true)]
    public class CheckListAnyAttribute : System.Attribute, IValidationAttribute
    {
        public void Validate(object value)
        {
            if (ValidationHelper.CheckListAny((IEnumerable) value))
                throw new BusinessException("List value can count zero");
        }
    }
}
