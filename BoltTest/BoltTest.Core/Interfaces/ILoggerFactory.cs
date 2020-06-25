using System;
using System.Collections.Generic;
using System.Text;

namespace BoltTest.Core.Interfaces
{
    public interface ILoggerFactory
    {
        ILoggingService GetLoggerForType<T>();
        ILoggingService GetLoggerForType(Type type);
    }
}
