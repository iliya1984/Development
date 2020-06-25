using System;
using System.Collections.Generic;
using System.Text;

namespace BoltTest.Core.Interfaces
{
    public interface ILoggingService
    {
        void Error(string errorMessage);
        void Error(Exception ex);
    }
}
