using System;
using OYASAR.Framework.Core.Interface;

namespace OYASAR.Framework.Core.Manager
{
    public abstract class IocManager : IIocManager
    {
        public static IIocManager Instance { get; set; }
       
        public abstract void Register<T, I>(params object[] dependency) where T : class where I : class, T;

        public abstract void Register<T, I>() where T : class where I : class, T;

        public abstract void Register<T, I>(string interceptor, params object[] dependency) where T : class where I : class, T;

        public abstract void Register<T, I>(string interceptor) where T : class where I : class, T;

        public abstract void RegisterTransient(Type @interface, Type impType);
        public abstract void RegisterSingleton(Type @interface, Type impType);
        public abstract void RegisterScoped(Type @interface, Type impType);

        public abstract void RegisterTransient(Type @interface, Type impType, string interceptor);

        public abstract object Resolve(object obj);

        public abstract T Resolve<T>() where T : class;

        public virtual void Initialize()
        {
            
        }
    }
}
