using Customers.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Customers.DAL
{
    public class RepositoryFactory
    {
        public static ICustomerRepository CreateCustomerRepository() 
        {
            return new CustomerRepository();
        }
    }
}
