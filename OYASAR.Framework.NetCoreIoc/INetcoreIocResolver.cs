using System;
using OYASAR.Framework.Core.Interface;

namespace OYASAR.Framework.NetCoreIoc
{
    public interface INetcoreIocResolver : IIocResolver
    {
        IServiceProvider Resolver { get; }
    }
}