using System;

namespace OYASAR.Framework.Core.Interface
{
    public interface ILog
    {
        void Write(string message);
        void Write(Result result);
        void Write(Exception ex);
    }
}