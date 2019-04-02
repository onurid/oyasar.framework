﻿namespace OYASAR.Framework.Core
{
    public class Result
    {
        public bool Success { get; set; }
        public object Data { get; set; }

        public static Result Ok(object data)
        {
            return new Result { Success = true, Data = data };
        }

        public static Result Ok(string message, object resultId)
        {
            return new Result { Success = true, Data = new { Message = message, ResultId = resultId } };
        }

        public static Result Error(Error data)
        {
            return new Result { Success = false, Data = data };
        }
    }

    public class Error
    {
        public string Message { get; set; }
    }
}
