using Customers.DAL.Entities;
using Customers.DAL.Interfaces;
using Customers.Entities;
using Dapper;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Customers.DAL
{
    internal class CustomerRepository : DapperRepository, ICustomerRepository
    {
        public CustomerRepository()
        {
        }

        public async Task<Customer> CreateAsync(Customer customer)
        {
            try
            {
                var dbCustomer = toDbCustomer(customer);

                await ExecuteAsync(async (connection) => 
                {
                    var result = await connection.QueryAsync<DbCustomer>(
                        sql: "usp_ustomerInsert", 
                        param: dbCustomer, 
                        commandType: CommandType.StoredProcedure
                    );

                    dbCustomer = result.FirstOrDefault();
                });

                return toCustomer(dbCustomer);
            }
            catch (Exception ex)
            {
                //TODO: log error
                return null;
            }
        }

        private DbCustomer toDbCustomer(Customer customer)
        {
            var dbCustomer = new DbCustomer();
            dbCustomer.Id = customer.Id;
            dbCustomer.FirstName = customer.FirstName;
            dbCustomer.LastName = customer.LastName;
            dbCustomer.Email = customer.Email;
            dbCustomer.Phone = customer.Phone;
            return dbCustomer;
        }

        private Customer toCustomer(DbCustomer dbCustomer)
        {
            var customer = new Customer();
            customer.Id = dbCustomer.Id;
            customer.FirstName = dbCustomer.FirstName;
            customer.LastName = dbCustomer.LastName;
            customer.Email = dbCustomer.Email;
            customer.Phone = dbCustomer.Phone;
            return customer;
        }
    }
}
