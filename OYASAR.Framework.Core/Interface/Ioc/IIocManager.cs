using System;

namespace OYASAR.Framework.Core.Interface
{
    public interface IIocManager : IIocRegistrar, IIocResolver
    {
        IDisposable BeginScope();
        void Initialize();
    }
}
