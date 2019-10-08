using System;
using System.IO;
using System.Reflection;
using System.Xml;
using log4net;
using Newtonsoft.Json;
using OYASAR.Framework.Core;

namespace OYASAR.Framework.Log4Net
{
    public class Log : Core.Interface.ILog
    {
        private static ILog _log = null;

        public void Write(Result result)
        {
            var json = JsonConvert.SerializeObject(result);

            if (result.Success)
                _log.Info(json);
            else
                _log.Warn(json);
        }

        public void Write(Exception ex)
        {
            _log.Error(ex.Message);
        }

        public void Write(string message)
        {
            _log.Fatal(message);
        }

        public static void SetLog4NetConfiguraiton(Type type)
        {
            XmlDocument log4netConfig = new XmlDocument();
            log4netConfig.Load(File.OpenRead("log4net.config"));

            var repo = LogManager.CreateRepository(
                Assembly.GetEntryAssembly(), typeof(log4net.Repository.Hierarchy.Hierarchy));

            log4net.Config.XmlConfigurator.Configure(repo, log4netConfig["log4net"]);

            _log = LogManager.GetLogger(type);

            _log.Info("Application - Main is invoked");
        }

        public static void SetLog4NetConfiguraitonForS3()
        {
        }
    }

}
