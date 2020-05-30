using Customers.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Customers.BLL.Interfaces
{
    public interface ICustomerService
    {
        Task<Customer> CreateAsync(Customer customer);
        Task<List<Customer>> GetAsync(CustomerFilter filter);
    }
}
