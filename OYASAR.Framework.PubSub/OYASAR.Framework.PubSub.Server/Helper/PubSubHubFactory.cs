using System;
using System.CodeDom.Compiler;
using System.Linq;
using Microsoft.CSharp;

namespace OYASAR.Framework.PubSub.Server.Helper
{
    public class PubSubHubFactory
    {
        private const string templateCode = @"
using Framework.PubSub.Core.Utils;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace Framework.PubSub.Server.Base {{

    [HubName(""{0}"")]
    public class {0} : Hub {{

      public {0}(){{


        }}

    }}    

}}

";

        public bool Run(string hubName)
        {
            var source = string.Format(templateCode, hubName);

            if (CompileAndLoadAssembly(source))
                return true;

            return false;
        }


        private bool CompileAndLoadAssembly(string source)
        {
            using (CodeDomProvider provider = new CSharpCodeProvider())
            {
                CompilerParameters options = new CompilerParameters
                {
                    CompilerOptions = "/target:library",
                    GenerateExecutable = false,
                    GenerateInMemory = true,
                };


                var coreDllLocation = AppDomain.CurrentDomain
                    .GetAssemblies()
                    .Where(a => !a.IsDynamic && a.Location.Contains("Framework.PubSub.Core.dll"))
                    .Select(a => a.Location).FirstOrDefault();
                
                options.ReferencedAssemblies.Add("Microsoft.AspNet.SignalR.Core.dll");
                options.ReferencedAssemblies.Add("Microsoft.AspNet.SignalR.Client.dll");
                options.ReferencedAssemblies.Add(coreDllLocation);

                CompilerResults result = provider.CompileAssemblyFromSource(options, source);
                
                if (result.Errors.Count == 0)
                {
                    //Assembly assembly = result.CompiledAssembly;
                    //foreach (Type t in assembly.ExportedTypes)
                    //{
                    //    Type baseInterface = t.GetInterface("IHub");
                    //    if (baseInterface != null)
                    //    {

                    //    }
                    //}
                    return true;
                }

            }
            return false;
        }
    }
}
