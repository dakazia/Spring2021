using System;
using System.IO;
using System.Reflection;
using System.Xml;
using log4net;
using log4net.Config;

namespace BrainstormSessions.Logger
{
    public class LoggerManager : ILoggerManager
    {
        private  readonly ILog _logger = LogManager.GetLogger(typeof(LoggerManager));

        public ILog GetLogger(Type type)
        {
            return LogManager.GetLogger(type);
        }

        public LoggerManager()
        {
            try
            {
                XmlDocument log4NetConfig = new XmlDocument();

                using (var fs = File.OpenRead("log4net.config"))
                {
                    log4NetConfig.Load(fs);

                    var repo = LogManager.CreateRepository(
                        Assembly.GetEntryAssembly(),
                        typeof(log4net.Repository.Hierarchy.Hierarchy));

                    XmlConfigurator.Configure(repo, log4NetConfig["log4net"]);

                    // The first log to be written 
                    _logger.Info("Log System Initialized");
                    
                }
            }
            catch (Exception ex)
            {
                _logger.Error("Error", ex);
            }
        }

        public void LogInformation(string message)
        {
            _logger.Info(message);
            Console.WriteLine(message);
        }

        public void LogDebug(string message)
        {
            _logger.Debug(message);
        }

        public void LogError(string message)
        {
            _logger.Error(message);
        }

        public void LogWarning(string message)
        {
            _logger.Warn(message);
        }
    }
}
