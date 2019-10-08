using System;
using Microsoft.Extensions.DependencyInjection;
using OYASAR.Framework.Core.Interface;

namespace OYASAR.Framework.NetCoreIoc
{
    public interface INetCoreIocManager : IIocManager, INetcoreIocResolver
    {
        IServiceCollection Container { get; }

        void Initialize(IServiceCollection collection);

        void SetServiceProvider(IServiceProvider serviceProvider);
    }
}