using System;
using System.Collections;
using OYASAR.Framework.Core.Exceptions;
using OYASAR.Framework.Core.Helper;
using OYASAR.Framework.Core.Interface;

namespace OYASAR.Framework.Core.Attribute
{
    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = true)]
    public class CheckValueAttribute : System.Attribute, IValidationAttribute
    {
        private readonly CheckValueType checkValueType;

        public CheckValueAttribute(CheckValueType checkValueType)
        {
            this.checkValueType = checkValueType;
        }

        public void Validate(object value)
        {
            switch(checkValueType)
            {
                case CheckValueType.CheckId:
                    if (ValidationHelper.CheckId((int)value))
                        throw new BusinessException("Id can not zero (0) or null");
                    break;
                case CheckValueType.CheckIsNull:
                    if (ValidationHelper.CheckIsNull(value))
                        throw new BusinessException("Value can not null");
                    break;
                case CheckValueType.CheckIsNullOrEmpty:
                    if (ValidationHelper.CheckIsNullOrEmpty((string)value))
                        throw new BusinessException("Value can not null or empty");
                    break;
                case CheckValueType.CheckListAny:
                    if (ValidationHelper.CheckListAny((IEnumerable)value))
                        throw new BusinessException("List value can count zero");
                    break;
            }
        }
    }

    public enum CheckValueType
    {
        CheckIsNull,
        CheckIsNullOrEmpty,
        CheckId,
        CheckListAny
    }
}
