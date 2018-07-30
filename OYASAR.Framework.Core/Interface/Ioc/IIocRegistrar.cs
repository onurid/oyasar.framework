using System;

namespace OYASAR.Framework.Core.Interface
{
    public interface IIocRegistrar
    {
        void Register<T, I>(params object[] dependency) where T : class where I : class, T;
        void Register<T, I>() where T : class where I : class, T;
        void Register<T, I>(string interceptor, params object[] dependency) where T : class where I : class, T;
        void Register<T, I>(string interceptor) where T : class where I : class, T;

        void RegisterTransient(Type @interface, Type impType);
        void RegisterSingleton(Type @interface, Type impType);
        void RegisterScoped(Type @interface, Type impType);

        void RegisterTransient(Type @interface, Type impType, string interceptor);
    }
}