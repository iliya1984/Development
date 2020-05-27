using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace FlightCrm.DAL.Repositories
{
    internal abstract class DapperRepository
    {
        protected DapperRepository()
        {

        }

        protected SqlConnection CreateConnection()
        {
            return new SqlConnection("");
        }

        protected async Task ExecuteAsync(Func<SqlConnection, Task> asyncAction)
        {
            using(var connection = CreateConnection())
            {
                await connection.OpenAsync();
                await asyncAction(connection);
            }
        }  
    }
}