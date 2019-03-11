using System;
using Castle.Core;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using OYASAR.Framework.Core.Manager;

namespace OYASAR.Framework.CastleWindsor
{
    public class WindsorIocManager : IocManager, IWindsorIocManger
    {
        private IWindsorContainer _container;
       
        public IWindsorContainer Container
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

        public new static IWindsorIocManger Instance
        {
            get
            {
                if (IocManager.Instance == null)
                {
                    throw new Exception("Instance cannot be null");
                }
                return (IWindsorIocManger)IocManager.Instance;
            }
        }

        public override void Initialize()
        {
            Container = new WindsorContainer();
        }

        static WindsorIocManager()
        {
            IocManager.Instance = new WindsorIocManager();
        }

        public override void Register<T, I>()
        {
            Container.Register(Component.For<T>().ImplementedBy<I>().Named(typeof(I).Name));
        }

        public override void Register<T, I>(string interceptor, params object[] dependency)
        {
            var rndName = Guid.NewGuid().ToString();
            var registration = Component.For<T>().ImplementedBy<I>().NamedAutomatically(rndName); ;

            foreach (var item in dependency)
            {
                registration.DependsOn(item);
            }

            var componentRegistration = registration.Interceptors(InterceptorReference.ForKey(interceptor)).Anywhere;

            _container.Register(componentRegistration.LifestyleTransient());
        }

        public override void Register<T, I>(string interceptor) 
        {
            Container.Register(Component.For<T>().ImplementedBy<I>().Named(typeof(I).Name)
                .Interceptors(InterceptorReference.ForKey(interceptor)).Anywhere);
        }

        public override void Register<T, I>(params object[] dependency)
        {
            var rndName = Guid.NewGuid().ToString();
            var registration = Component.For<T>().ImplementedBy<I>().NamedAutomatically(rndName);

            foreach (var item in dependency)
            {
                registration.DependsOn(item);
            }
            _container.Register(registration.LifestyleTransient());
        }

        public override void RegisterTransient(Type @interface, Type impType, string interceptor)
        {
            Container.Register(Component.For(@interface).ImplementedBy(impType).Named(impType.Name).LifestyleTransient()
                .Interceptors(InterceptorReference.ForKey(interceptor)).Anywhere);
        }

        public override void RegisterTransient(string impKeyName, Type @interface, Type impType, string interceptor)
        {
            Container.Register(Component.For(@interface).ImplementedBy(impType).Named(impKeyName).LifestyleTransient()
                .Interceptors(InterceptorReference.ForKey(interceptor)).Anywhere);
        }

        public override void RegisterSingleton(string impKeyName, Type @interface, Type impType, string interceptor)
        {
            Container.Register(Component.For(@interface).ImplementedBy(impType).Named(impKeyName).LifestyleSingleton()
                .Interceptors(InterceptorReference.ForKey(interceptor)).Anywhere);
        }

        public override void RegisterScoped(string impKeyName, Type @interface, Type impType, string interceptor)
        {
            Container.Register(Component.For(@interface).ImplementedBy(impType).Named(impKeyName).LifestyleScoped()
                .Interceptors(InterceptorReference.ForKey(interceptor)).Anywhere);
        }

        public override object Resolve(object obj)
        {
            return Container.Resolve(obj.GetType());
        }

        public override T Resolve<T>()
        {
            return Container.Resolve<T>();
        }

        public override object Resolve(object obj, string impKeyName)
        {
            return Container.Resolve(impKeyName, obj.GetType());
        }

        public override T Resolve<T>(string impKeyName)
        {
            return Container.Resolve<T>(impKeyName);
        }

        public override void RegisterTransient(Type @interface, Type impType)
        {
            Container.Register(Component.For(@interface).ImplementedBy(impType).LifestyleTransient());
        }

        public override void RegisterSingleton(Type @interface, Type impType)
        {
            Container.Register(Component.For(@interface).ImplementedBy(impType).LifestyleSingleton());
        }

        public override void RegisterScoped(Type @interface, Type impType)
        {
            Container.Register(Component.For(@interface).ImplementedBy(impType).LifestyleScoped());
        }

        public override void RegisterTransient(string impKeyName, Type @interface, Type impType)
        {
            Container.Register(Component.For(@interface).ImplementedBy(impType).Named(impKeyName).LifestyleTransient());
        }

        public override void RegisterSingleton(string impKeyName, Type @interface, Type impType)
        {
            Container.Register(Component.For(@interface).ImplementedBy(impType).Named(impKeyName).LifestyleSingleton());
        }

        public override void RegisterScoped(string impKeyName, Type @interface, Type impType)
        {
            Container.Register(Component.For(@interface).ImplementedBy(impType).Named(impKeyName).LifestyleScoped());
        }
    }
}
