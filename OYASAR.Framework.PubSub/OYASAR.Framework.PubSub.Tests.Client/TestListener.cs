using System;
using OYASAR.Framework.PubSub.Core.Model;
using OYASAR.Framework.PubSub.Core.Persistence;

namespace OYASAR.Framework.PubSub.Tests.Client
{
    public class TestListener : IListener
    {
        private static int value = 1;
        public void Notify(Package package)
        {
            Console.WriteLine($"{value}Paket {package.Command}");
            value++;
        }
    }
}
