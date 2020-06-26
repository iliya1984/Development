using BoltTest.Core.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace BoltTest.DAL.Repositories
{
    internal abstract class DapperRepository
    {
        protected string ConnectionString { get; private set; }
        protected ILoggingService Logger { get; private set; }

        protected DapperRepository(IConfiguration configuration, ILoggerFactory loggerFactory) 
        {
            ConnectionString = configuration["Database:ConnectionString"];
            Logger = loggerFactory.GetLoggerForType(GetType());
        }
    }
}
