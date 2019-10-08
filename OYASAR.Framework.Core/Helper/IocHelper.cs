using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using OYASAR.Framework.Core.Interface;
using OYASAR.Framework.Core.Manager;

namespace OYASAR.Framework.Core.Helper
{
#if (NET451 || NETSTANDARD1_3)
    public static class IocHelper
    {
        public static Type TypeInterface { get; set; }
        public static Type TypeImplementation { get; set; }

        public static RegisterType RegisterTypeValue { get; private set;}

        public static void RegisterIntefaceBasedTypes<TDependency, TTransient, TSingleton, TScoped>(Action[] action, string baseDir)
        {
            var assemblies = Utils.AppDomain.GetAllAssemblies(baseDir);

            var allTypes = assemblies.SelectMany(x => x.ExportedTypes).
                Where(x => !x.GetTypeInfo().IsAbstract && typeof(TDependency).IsAssignableFrom(x) && x.GetTypeInfo().IsClass).ToList();

            var transientTypes = allTypes.Where(x => !x.GetTypeInfo().IsAbstract && typeof(TTransient).IsAssignableFrom(x) && x.GetTypeInfo().IsClass);
            var singletonTypes = allTypes.Where(x => !x.GetTypeInfo().IsAbstract && typeof(TSingleton).IsAssignableFrom(x) && x.GetTypeInfo().IsClass);
            var scopedTypes = allTypes.Where(x => !x.GetTypeInfo().IsAbstract && typeof(TScoped).IsAssignableFrom(x) && x.GetTypeInfo().IsClass);

            RegisterTypes<TDependency, TTransient, TSingleton, TScoped>(transientTypes, IocLifeTime.Transient, action);
            RegisterTypes<TDependency, TTransient, TSingleton, TScoped>(singletonTypes, IocLifeTime.Singleton, action);
            RegisterTypes<TDependency, TTransient, TSingleton, TScoped>(scopedTypes, IocLifeTime.Scoped, action);
        }

        public enum RegisterType
        {
            AsName,
            AsFullName
        }

        private enum IocLifeTime
        {
            Transient, Scoped, Singleton
        }
        private static void RegisterTypes<TDependency, TTransient, TSingleton, TScoped>(IEnumerable<Type> transientTypes, IocLifeTime lifeTime, IReadOnlyList<Action> action)
        {
            foreach (var transientType in transientTypes)
            {
                //var implementedInterfaces = transientType.GetTypeInfo().ImplementedInterfaces;

                var implementedInterfaces = transientType.GetTypeInfo().ImplementedInterfaces
                    .Where(x => typeof(TDependency).IsAssignableFrom(x) && x != typeof(TTransient)
                                && x != typeof(TSingleton) && x != typeof(TScoped) && x != typeof(TDependency));

                foreach (var @interface in implementedInterfaces)
                {
                    TypeInterface = @interface;
                    TypeImplementation = transientType;

                    switch (lifeTime)
                    {
                        case IocLifeTime.Transient:
                            action[0].Invoke();
                            break;
                        case IocLifeTime.Scoped:
                            action[1].Invoke();
                            break;
                        case IocLifeTime.Singleton:
                            action[2].Invoke();
                            break;
                        default:
                            throw new ArgumentOutOfRangeException(nameof(lifeTime), lifeTime, null);
                    }
                }
            }
        }


        public static void RegisterIntefaceBasedTypes(RegisterType registerType = RegisterType.AsName, bool byKeyName = false)
        {
            RegisterTypeValue = registerType;

            var assemblies = Utils.AppDomain.GetAllAssemblies(DomainHelper.BaseDirForDll);

            var allTypes = assemblies.SelectMany(x => x.ExportedTypes).
                Where(x => !x.GetTypeInfo().IsAbstract && typeof(IDependency).IsAssignableFrom(x) && x.GetTypeInfo().IsClass).ToList();

            var transientTypes = allTypes.Where(x => !x.GetTypeInfo().IsAbstract && typeof(ITransientDependency).IsAssignableFrom(x) && x.GetTypeInfo().IsClass);
            var singletonTypes = allTypes.Where(x => !x.GetTypeInfo().IsAbstract && typeof(ISingletonDependency).IsAssignableFrom(x) && x.GetTypeInfo().IsClass);
            var scopedTypes = allTypes.Where(x => !x.GetTypeInfo().IsAbstract && typeof(IScopedDependency).IsAssignableFrom(x) && x.GetTypeInfo().IsClass);

            RegisterTypes(transientTypes, IocLifeTime.Transient, byKeyName);
            RegisterTypes(singletonTypes, IocLifeTime.Singleton, byKeyName);
            RegisterTypes(scopedTypes, IocLifeTime.Scoped, byKeyName);
        }

        private static void RegisterTypes(IEnumerable<Type> transientTypes, IocLifeTime lifeTime, bool byKeyName)
        {
            foreach (var transientType in transientTypes)
            {
                //var implementedInterfaces = transientType.GetTypeInfo().ImplementedInterfaces;

                var transientTypeName = transientType.Name;

                if (RegisterTypeValue == RegisterType.AsFullName)
                    transientTypeName = transientType.FullName;

                var implementedInterfaces = transientType.GetTypeInfo().ImplementedInterfaces
                    .Where(x => typeof(IDependency).IsAssignableFrom(x) && x != typeof(ITransientDependency)
                                && x != typeof(ISingletonDependency) && x != typeof(IScopedDependency) && x != typeof(IDependency));

                var implementedInterfaces2 = transientType.GetTypeInfo().ImplementedInterfaces
                    .Where(x => x.Name.Contains("Interceptor")).ToList();

                var interceptorName = string.Empty;

                if (implementedInterfaces2.Any())
                {
                    var interceptorTypeName = implementedInterfaces2.Where(x => x.Name != "IInterceptor").FirstOrDefault();
                    
                    if (interceptorTypeName != null)
                        interceptorName = interceptorTypeName.Name.Substring(1);
                }

                foreach (var @interface in implementedInterfaces)
                {
                    if (implementedInterfaces2.Any())
                    {
                        if (!implementedInterfaces2.Where(x => x.Name == @interface.Name).Any())
                        {
                            if (byKeyName)
                            {
                                switch (lifeTime)
                                {
                                    case IocLifeTime.Transient:
                                        IocManager.Instance.RegisterTransient(transientTypeName, @interface, transientType, interceptorName);
                                        break;
                                    case IocLifeTime.Scoped:
                                        IocManager.Instance.RegisterScoped(transientTypeName, @interface, transientType, interceptorName);
                                        break;
                                    case IocLifeTime.Singleton:
                                        IocManager.Instance.RegisterSingleton(transientTypeName, @interface, transientType, interceptorName);
                                        break;
                                    default:
                                        throw new ArgumentOutOfRangeException(nameof(lifeTime), lifeTime, null);
                                }
                            }
                            else
                            {
                                switch (lifeTime)
                                {
                                    case IocLifeTime.Transient:
                                        IocManager.Instance.RegisterTransient(@interface, transientType, interceptorName);
                                        break;
                                    case IocLifeTime.Scoped:
                                        IocManager.Instance.RegisterScoped(@interface, transientType);
                                        break;
                                    case IocLifeTime.Singleton:
                                        IocManager.Instance.RegisterSingleton(@interface, transientType);
                                        break;
                                    default:
                                        throw new ArgumentOutOfRangeException(nameof(lifeTime), lifeTime, null);
                                }
                            }
                        }
                        else
                        {
                            if (transientType.Name == interceptorName)
                            {
                                if (byKeyName)
                                {
                                    switch (lifeTime)
                                    {
                                        case IocLifeTime.Transient:
                                            IocManager.Instance.RegisterTransient(transientType.Name, @interface, transientType);
                                            break;
                                        case IocLifeTime.Scoped:
                                            IocManager.Instance.RegisterScoped(transientType.Name, @interface, transientType);
                                            break;
                                        case IocLifeTime.Singleton:
                                            IocManager.Instance.RegisterSingleton(transientType.Name, @interface, transientType);
                                            break;
                                        default:
                                            throw new ArgumentOutOfRangeException(nameof(lifeTime), lifeTime, null);
                                    }
                                }
                                else
                                {
                                    switch (lifeTime)
                                    {
                                        case IocLifeTime.Transient:
                                            IocManager.Instance.RegisterTransient(@interface, transientType);
                                            break;
                                        case IocLifeTime.Scoped:
                                            IocManager.Instance.RegisterScoped(@interface, transientType);
                                            break;
                                        case IocLifeTime.Singleton:
                                            IocManager.Instance.RegisterSingleton(@interface, transientType);
                                            break;
                                        default:
                                            throw new ArgumentOutOfRangeException(nameof(lifeTime), lifeTime, null);
                                    }
                                }
                            }
                        }

                    }
                    else
                    {
                        if (byKeyName)
                        {
                            switch (lifeTime)
                            {
                                case IocLifeTime.Transient:
                                    IocManager.Instance.RegisterTransient(transientTypeName, @interface, transientType);
                                    break;
                                case IocLifeTime.Scoped:
                                    IocManager.Instance.RegisterScoped(transientTypeName, @interface, transientType);
                                    break;
                                case IocLifeTime.Singleton:
                                    IocManager.Instance.RegisterSingleton(transientTypeName, @interface, transientType);
                                    break;
                                default:
                                    throw new ArgumentOutOfRangeException(nameof(lifeTime), lifeTime, null);
                            }
                        }
                        else
                        {
                            switch (lifeTime)
                            {
                                case IocLifeTime.Transient:
                                    IocManager.Instance.RegisterTransient(@interface, transientType);
                                    break;
                                case IocLifeTime.Scoped:
                                    IocManager.Instance.RegisterScoped(@interface, transientType);
                                    break;
                                case IocLifeTime.Singleton:
                                    IocManager.Instance.RegisterSingleton(@interface, transientType);
                                    break;
                                default:
                                    throw new ArgumentOutOfRangeException(nameof(lifeTime), lifeTime, null);
                            }
                        }
                    }
                }
            }
        }
    }

#endif
}