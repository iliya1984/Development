using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Customers.DAL
{
    internal abstract class DapperRepository
    {
        protected DapperRepository() 
        {
        
        }

        protected SqlConnection CreateConnection() 
        {
            //TODO: read from configuration file
            string connectionString = "Server=DESKTOP-LAS719G\\SQLEXPRESS;Database=CustomersTest;User Id=administrator;Password=password;";
            return new SqlConnection(connectionString);
        }

        protected async Task ExecuteAsync(Func<SqlConnection, Task> asyncAction) 
        {
            using (var connection = CreateConnection()) 
            {
                connection.Open();

                await asyncAction.Invoke(connection);
            }
        }
    }
}
