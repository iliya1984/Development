using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace FlightCrm.DAL.Repositories
{
    internal abstract class MssqlRepository
    {
        protected MssqlRepository()
        {

        }

        protected SqlConnection CreateConnection()
        {
            return new SqlConnection("Server=DESKTOP-LAS719G\\SQLEXPRESS;Database=FlightTest01;User Id=administrator;Password=password;");
        }

        protected async Task ExecuteAsync(Func<SqlConnection, Task> asyncAction)
        {
            try
            {
                using(var connection = CreateConnection())
                {
                    await connection.OpenAsync();
                    await asyncAction(connection);
                }
            }
            catch(Exception ex)
            {

            }

           
        }  
    }
}