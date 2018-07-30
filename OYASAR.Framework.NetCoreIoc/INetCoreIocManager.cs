using System;
using OYASAR.Framework.Core.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace OYASAR.Framework.NetCoreIoc
{
    public interface INetCoreIocManager : IIocManager, INetcoreIocResolver
    {
        IServiceCollection Container { get; }

        void Initialize(IServiceCollection collection);

        void SetServiceProvider(IServiceProvider serviceProvider);
    }
}