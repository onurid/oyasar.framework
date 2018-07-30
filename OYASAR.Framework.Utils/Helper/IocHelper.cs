using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace OYASAR.Framework.Utils.Helper
{
    public static class IocHelper
    {
        public static Type TypeInterface { get; set; }
        public static Type TypeImplementation { get; set; }

        public static void RegisterIntefaceBasedTypes<Dependency, Transient, Singleton, Scoped>(Action[] action, string baseDir)
        {
            var assemblies = AppDomain.GetAllAssemblies(baseDir);

            var allTypes = assemblies.SelectMany(x => x.ExportedTypes).
                Where(x => !x.GetTypeInfo().IsAbstract && typeof(Dependency).IsAssignableFrom(x) && x.GetTypeInfo().IsClass).ToList();

            var transientTypes = allTypes.Where(x => !x.GetTypeInfo().IsAbstract && typeof(Transient).IsAssignableFrom(x) && x.GetTypeInfo().IsClass);
            var singletonTypes = allTypes.Where(x => !x.GetTypeInfo().IsAbstract && typeof(Singleton).IsAssignableFrom(x) && x.GetTypeInfo().IsClass);
            var scopedTypes = allTypes.Where(x => !x.GetTypeInfo().IsAbstract && typeof(Scoped).IsAssignableFrom(x) && x.GetTypeInfo().IsClass);

            RegisterTypes<Dependency, Transient, Singleton, Scoped>(transientTypes, IocLifeTime.Transient, action);
            RegisterTypes<Dependency, Transient, Singleton, Scoped>(singletonTypes, IocLifeTime.Singleton, action);
            RegisterTypes<Dependency, Transient, Singleton, Scoped>(scopedTypes, IocLifeTime.Scoped, action);
        }

        private enum IocLifeTime
        {
            Transient, Scoped, Singleton
        }
        private static void RegisterTypes<Dependency, Transient, Singleton, Scoped>(IEnumerable<Type> transientTypes, IocLifeTime lifeTime, IReadOnlyList<Action> action)
        {
            foreach (var transientType in transientTypes)
            {
                //var implementedInterfaces = transientType.GetTypeInfo().ImplementedInterfaces;

                var implementedInterfaces = transientType.GetTypeInfo().ImplementedInterfaces
                    .Where(x => typeof(Dependency).IsAssignableFrom(x) && x != typeof(Transient)
                                && x != typeof(Singleton) && x != typeof(Scoped) && x != typeof(Dependency));

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
    }
}