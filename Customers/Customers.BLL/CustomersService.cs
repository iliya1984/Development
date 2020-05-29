using Customers.BLL.Interfaces;
using Customers.DAL;
using Customers.DAL.Interfaces;
using Customers.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Customers.BLL
{
    internal class CustomersService : ICustomerService
    {
        private ICustomerRepository _repository;

        public CustomersService() 
        {
            //TODO: Inject repository via constructor using Autofac
            _repository = RepositoryFactory.CreateCustomerRepository();    
        }

        public async Task<Customer> CreateAsync(Customer customer)
        {
            try
            {
                return await _repository.CreateAsync(customer);
            }
            catch (Exception ex)
            {
                //TODO: log error
                return null;
            }
        }
    }
}
