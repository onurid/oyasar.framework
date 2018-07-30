using System;
using Microsoft.Extensions.DependencyInjection;
using OYASAR.Framework.Core.Manager;

namespace OYASAR.Framework.NetCoreIoc
{
    public class NetCoreIocManager : IocManager, INetCoreIocManager
    {
        private IServiceCollection _container;

        private IServiceProvider _resolver;

        public IServiceCollection Container
        {
            get
            {
                if (_container == null)
                {
                    throw new Exception("Container is not initialized yet");
                }
                return _container;
            }
            private set => _container = value;
        }

        public IServiceProvider Resolver
        {
            get
            {
                if (_resolver == null)
                {
                    throw new Exception("Provider is not initialized yet");
                }
                return _resolver;
            }
            private set => _resolver = value;
        }
        
        public new static INetCoreIocManager Instance
        {
            get
            {
                if (IocManager.Instance == null)
                {
                    throw new Exception("Instance cannot be null");
                }
                return (INetCoreIocManager)IocManager.Instance;
            }
        }

        static NetCoreIocManager()
        {
            IocManager.Instance = new NetCoreIocManager();
        }

        public void Initialize(IServiceCollection collection)
        {
            Container = collection;

            base.Initialize();
        }

        public void SetServiceProvider(IServiceProvider serviceProvider)
        {
            Resolver = serviceProvider;
        }

        public override void Register<T, I>(params object[] dependency)
        {
            var parameter = (Func<IServiceProvider, I>)dependency[0];
            Container.AddTransient<T, I>(parameter);            
        }

        public override void Register<T, I>()
        {
            Container.AddTransient<T, I>();
        }

        public override void Register<T, I>(string interceptor, params object[] dependency)
        {
            throw new NotImplementedException();
        }

        public override void Register<T, I>(string interceptor)
        {
            throw new NotImplementedException();
        }

        public override void RegisterTransient(Type @interface, Type impType, string interceptor)
        {
            
        }

        public override object Resolve(object obj)
        {
            return Resolver.GetService(obj.GetType());
        }

        public override T Resolve<T>()
        {
            return Resolver.GetService<T>();
        }

        public override void RegisterTransient(Type @interface, Type impType)
        {
            Container.AddTransient(@interface, x => Activator.CreateInstance(impType));
        }

        public override void RegisterSingleton(Type @interface, Type impType)
        {
            Container.AddSingleton(@interface, x => Activator.CreateInstance(impType));
        }

        public override void RegisterScoped(Type @interface, Type impType)
        {
            Container.AddScoped(@interface, x => Activator.CreateInstance(impType));
        }
    }
}
