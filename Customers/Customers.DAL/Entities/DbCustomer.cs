using System;
using System.Collections.Generic;
using System.Text;

namespace Customers.DAL.Entities
{
    public class DbCustomer
    {
        public long Pkid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
