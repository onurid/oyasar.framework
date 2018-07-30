using System;
using System.IO;
using Castle.Windsor;
using Castle.Windsor.Configuration.Interpreters;
using OYASAR.Framework.PubSub.Client;
using OYASAR.Framework.PubSub.Core.Utils;
using log4net.Config;
using Microsoft.Practices.ServiceLocation;

namespace OYASAR.Framework.PubSub.Tests.Client
{
    internal class Program
    {
        private static void Main()
        {
            XmlConfigurator.Configure(new FileInfo(AppDomain.CurrentDomain.BaseDirectory + @"\App_Config\log4net.config"));

            IWindsorContainer container = new WindsorContainer(new XmlInterpreter(AppDomain.CurrentDomain.BaseDirectory + "App_Config\\castle.config"));

            //ServiceLocator.SetLocatorProvider(() => new WindsorServiceLocator(container));
            
            var client = new ClientManager(Constants.HubName, Constants.DefaultClientProvider);

            client.RegisterListener("Test", new TestListener());

            client.Start();
            
            Console.WriteLine("Client started! Press any key to stop...");
            
            while (true)
            {
                var pressButton = Console.ReadKey();

                if (pressButton.Key == ConsoleKey.Escape)
                    return;

                if (pressButton.Key == ConsoleKey.Enter)
                { 
                    client.Dispose();
                    client = null;
                }
            }
        }
    }
}
