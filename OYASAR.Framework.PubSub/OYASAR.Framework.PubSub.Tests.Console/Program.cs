using System;
using System.Configuration;
using System.IO;
using OYASAR.Framework.PubSub.Core.Model;
using OYASAR.Framework.PubSub.Server;
using log4net.Config;
using Microsoft.Owin.Hosting;
using OYASAR.Framework.PubSub.Core.Utils;

namespace OYASAR.Framework.PubSub.Tests.Console
{
    static class Program
    {
        static void Main(string[] args)
        {
            XmlConfigurator.Configure(new FileInfo(AppDomain.CurrentDomain.BaseDirectory + @"\App_Config\log4net.config"));

            var Url = ConfigurationSettings.AppSettings["MyApi"]; //"http://+:8700/";

            using (WebApp.Start<Startup>(Url))
            {
                System.Console.WriteLine("Server started");
                System.Console.ReadKey();

                while (true)
                {
                    WriteMenu();

                    var pressButton = System.Console.ReadKey();

                    if (pressButton.Key == ConsoleKey.Escape)
                    {
                        return;
                    }

                    if (pressButton.Key == ConsoleKey.Enter)
                    {
                        var message = "EventMessage";

                        System.Console.WriteLine(" -- #F2 => write message ( -- Press the any key => default: '" + message + "') ");

                        pressButton = System.Console.ReadKey();

                        if (pressButton.Key == ConsoleKey.F2)
                        {
                            System.Console.WriteLine("");
                            System.Console.Write("Enter the message..  : ");
                            message = System.Console.ReadLine();
                        }

                        var server = new ServerManager(Constants.HubName, Constants.DefaultServerProvider);

                        server.Publish("Test", new Package { Command = message });
                        
                        System.Console.WriteLine("");
                        System.Console.ForegroundColor = ConsoleColor.Green;
                        System.Console.WriteLine("____Has been sent message___");
                        System.Console.ForegroundColor = ConsoleColor.White;
                        System.Console.ReadKey();
                    }


                    if (pressButton.Key == ConsoleKey.F5)
                    {
                        var message = "EventMessage";

                        System.Console.WriteLine(" -- #F2 => write message ( -- Press the any key => default: '" + message + "') ");

                        pressButton = System.Console.ReadKey();

                        if (pressButton.Key == ConsoleKey.F2)
                        {
                            System.Console.WriteLine("");
                            System.Console.Write("Enter the message..  : ");
                            message = System.Console.ReadLine();
                        }

                        var server = new ServerManager(Constants.HubNameTest, Constants.DefaultServerProvider);

                        server.Publish("Test", new Package { Command = message });
                        
                        System.Console.WriteLine("");
                        System.Console.ForegroundColor = ConsoleColor.Green;
                        System.Console.WriteLine("____Has been sent message___");
                        System.Console.ForegroundColor = ConsoleColor.White;
                        System.Console.ReadKey();
                    }
                }
            }
        }


        private static void WriteMenu()
        {
            System.Console.Clear();
            System.Console.WriteLine("-----------------------------");
            System.Console.WriteLine(" -- #Escape => Program exit. ");

            System.Console.WriteLine(" -- #Enter => Send a message. ");
        }
    }
}
