using log4net;
using Newtonsoft.Json;
using OYASAR.Framework.Core;
using System;
using System.IO;
using System.Reflection;
using System.Xml;

namespace OYASAR.Framework.Log4Net
{
    public class Log : Core.Interface.ILog
    {
        private readonly ILog log;

        private static Type _type;

        private static readonly ILog _log =  LogManager.GetLogger(_type);

        public Log()
        {
            log = LogManager.GetLogger(_type);
        }

        public void Write(Result result)
        {
            var json = JsonConvert.SerializeObject(result);

            if (result.Success)
                log.Info(json);
            else
                log.Warn(json);
        }

        public void Write(Exception ex)
        {
            log.Error(ex.Message);
        }

        public void Write(string message)
        {
            throw new NotImplementedException();
        }

        public static void SetLog4NetConfiguraiton(Type type)
        {
            XmlDocument log4netConfig = new XmlDocument();
            log4netConfig.Load(File.OpenRead("log4net.config"));

            var repo = LogManager.CreateRepository(
                Assembly.GetEntryAssembly(), typeof(log4net.Repository.Hierarchy.Hierarchy));

            log4net.Config.XmlConfigurator.Configure(repo, log4netConfig["log4net"]);

            _type = type;

            _log.Info("Application - Main is invoked");
        }
    }

}
