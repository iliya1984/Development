using BoltTest.Core.Interfaces;
using NLog;
using NLog.Fluent;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoltTest.Core.Logging
{
    internal class NLogLoggingService : ILoggingService
    {
        private ILogger _logger;
        private ILogger _innerLogger;

        public NLogLoggingService(Type type) 
        {
            _logger = LogManager.GetLogger(type.FullName);
            _innerLogger = LogManager.GetCurrentClassLogger();
        }

        public void Error(Exception ex) 
        {
            try
            {
                _logger.Error(ex);
            }
            catch (Exception innerEx)
            {
                _innerLogger.Error(innerEx);
            }
        }

        public void Error(string errorMessage)
        {
            try
            {
                _logger.Error(errorMessage);
            }
            catch (Exception innerEx)
            {
                _innerLogger.Error(innerEx);
            }
        }
    }
}
