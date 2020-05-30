using Customers.DAL.Entities;
using Customers.DAL.Interfaces;
using Customers.Entities;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Customers.DAL
{
    internal class MssqlCustomerRepository : MssqlRepository, ICustomerRepository
    {
        public MssqlCustomerRepository()
        {
        }

        public async Task<List<Customer>> GetAsync(CustomerFilter filter)
        {
            try
            {
                List<Customer> customers = new List<Customer>();
                List<DbCustomer> dbCustomers = null;
                
                var dbCustomerFilter = new DbCustomerFilter();
                dbCustomerFilter.CustomerId = filter.CustomerId;

                await ExecuteAsync(async (connection) =>
                {
                    var dbItems = await connection.QueryAsync<DbCustomer>(
                        sql: "usp_ustomerSelect",
                        param: dbCustomerFilter,
                        commandType: CommandType.StoredProcedure
                    );

                    dbCustomers = dbItems.ToList();
                });

                if (dbCustomers == null || false == dbCustomers.Any())
                {
                    return customers;
                }

                dbCustomers.ForEach(dbCustomer => 
                {
                    try
                    {
                        var customer = toCustomer(dbCustomer);
                        if (customer != null) 
                        {
                            customers.Add(customer);
                        }
                        else 
                        {
                            //TODO: log error
                        }
                    }
                    catch (Exception ex)
                    {
                        //TODO: log error
                    }
                });

                return customers;
            }
            catch (Exception ex)
            {
                //TODO: log error
                return null;
            }
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

        public async Task<Customer>UpdateAsync(Customer customer)
        {
            try
            {
                var dbCustomer = toDbCustomer(customer);

                await ExecuteAsync(async (connection) =>
                {
                    var result = await connection.QueryAsync<DbCustomer>(
                        sql: "usp_ustomerUpdate",
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
            dbCustomer.Pkid = customer.Id;
            dbCustomer.FirstName = customer.FirstName;
            dbCustomer.LastName = customer.LastName;
            dbCustomer.Email = customer.Email;
            dbCustomer.Phone = customer.Phone;
            return dbCustomer;
        }

        private Customer toCustomer(DbCustomer dbCustomer)
        {
            var customer = new Customer();
            customer.Id = dbCustomer.Pkid;
            customer.FirstName = dbCustomer.FirstName;
            customer.LastName = dbCustomer.LastName;
            customer.Email = dbCustomer.Email;
            customer.Phone = dbCustomer.Phone;
            return customer;
        }

       
    }
}
