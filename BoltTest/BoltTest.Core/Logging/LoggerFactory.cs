using BoltTest.Core.Enums;
using BoltTest.Core.Interfaces;
using NLog;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoltTest.Core.Logging
{
    internal class LoggerFactory : ILoggerFactory
    {
        private ILogger _logger;
        private Func<ELoggingTechnology, Type, ILoggingService> _factoryMethod;

        public LoggerFactory(Func<ELoggingTechnology, Type, ILoggingService> factoryMethod) 
        {
            _logger = LogManager.GetCurrentClassLogger();
            _factoryMethod = factoryMethod;
        }

        public ILoggingService GetLoggerForType<T>()
        {
            try
            {
                return _factoryMethod.Invoke(ELoggingTechnology.NLog, typeof(T));
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        public ILoggingService GetLoggerForType(Type type)
        {
            try
            {
                return _factoryMethod.Invoke(ELoggingTechnology.NLog, type);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
        }
    }
}
