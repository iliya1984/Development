using BoltTest.Core.Interfaces;
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

        protected DapperRepository(ILoggerFactory loggerFactory) 
        {
            //var section = configuration.GetSection("Database:ConnectionString");
            //ConnectionString = section.ToString();
            ConnectionString = "Server=DESKTOP-LAS719G\\SQLEXPRESS;Database=BoltTest;User Id=administrator;Password=password;";
            Logger = loggerFactory.GetLoggerForType(GetType());
        }
    }
}
