using System;
using System.Net.Http;
using System.Web.Http;
using Castle.Windsor;
using Castle.Windsor.Configuration.Interpreters;
using OYASAR.Framework.PubSub.Core.Model;
using OYASAR.Framework.PubSub.Core.Utils;
using OYASAR.Framework.PubSub.Server;
using Microsoft.Practices.ServiceLocation;

namespace OYASAR.Framework.PubSub.Tests.Api.Controllers
{
    public class TestController : ApiController
    {
        public HttpResponseMessage Get(string message = "EventMessage")
        {
            IWindsorContainer container = new WindsorContainer(new XmlInterpreter(AppDomain.CurrentDomain.BaseDirectory + "App_Config\\castle.config"));

            //ServiceLocator.SetLocatorProvider(() => new WindsorServiceLocator(container));

            var server = new ServerManager(Constants.HubName, Constants.DefaultServerProvider);

            server.Publish("Test", new Package { Command = message + "Source: " + HostHelper.GetHostName() });

            return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
        }
    }
}
