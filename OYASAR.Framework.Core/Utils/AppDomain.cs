using System.Collections.Generic;
using System.Reflection;

#if (NET451 || NETSTANDARD1_3)
using System.IO;
using System.Linq;
using System;
#endif

#if (NETSTANDARD1_6)
using Microsoft.Extensions.DependencyModel;
#endif

namespace OYASAR.Framework.Core.Utils
{
    public class AppDomain
    {
        public static List<Assembly> GetAllAssemblies(string baseDir)
        {
            var assemblies = new List<Assembly>();

#if (NETSTANDARD1_6)
           var deps = DependencyContext.Default;
            

           foreach (var compilationLibrary in deps.CompileLibraries)
           {
               try
               {
                   var assembly2 = Assembly.Load(new AssemblyName(compilationLibrary.Name));

                   assemblies.Add(assembly2);
               }
               catch (Exception)
               {
                   // ignored
               }
           }
#endif

#if (NET451 || NETSTANDARD1_3)

            foreach (var file in Directory.EnumerateFiles(baseDir).Select(x => new FileInfo(x)))
            {
                if (string.Equals(file.Extension, ".dll", StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(file.Extension, ".exe", StringComparison.OrdinalIgnoreCase))
                {
                    try
                    {
                        assemblies.Add(Assembly.Load(new AssemblyName { Name = Path.GetFileNameWithoutExtension(file.Name) }));
                    }
                    catch 
                    {
                        //Ignore;
                    }
                }
            }
#endif

            return assemblies;
        }
    }
}
