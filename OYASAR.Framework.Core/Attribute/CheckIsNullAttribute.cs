﻿using System;
using OYASAR.Framework.Core.Exceptions;
using OYASAR.Framework.Core.Helper;
using OYASAR.Framework.Core.Interface;

namespace OYASAR.Framework.Core.Attribute
{
    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = true)]
    public class CheckIsNullAttribute : System.Attribute, IValidationAttribute
    {
        public void Validate(object value)
        {
            if (ValidationHelper.CheckIsNull(value))
                throw new BusinessException("Value can not null");
        }
    }
}
