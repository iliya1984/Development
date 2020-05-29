using Customers.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Customers.BLL
{
    public static class ServiceFactory
    {
        public static ICustomerService CreateCustomerService() 
        {
            return new CustomersService();
        }
    }
}
