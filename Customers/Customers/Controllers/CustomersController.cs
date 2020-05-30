using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Customers.BLL;
using Customers.BLL.Interfaces;
using Customers.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Customers.Controllers
{
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private ICustomerService _service;
        public CustomersController() 
        {
            //TODO: Inject service via constructor using Autofac
            _service = ServiceFactory.CreateCustomerService();
        }

        [HttpPost]
        [Route("api/customers/new")]
        public async Task<IActionResult> CreateCustomer(Customer customer) 
        {
            try
            {
                var result = await _service.CreateAsync(customer);

                if (result == null) 
                {
                    return new InternalServerErrorResult();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return new ExceptionResult(ex, true);
            }
        }

        [HttpGet]
        [Route("api/customers")]
        public async Task<IActionResult> GetCustomers(string customerId = null)
        {
            try
            {
                var result = await _service.GetAsync(new CustomerFilter { CustomerId = customerId });

                if (result == null)
                {
                    return new InternalServerErrorResult();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return new ExceptionResult(ex, true);
            }
        }

    }
}
