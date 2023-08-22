using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OSDSII.api.Models;

namespace OSDSII.api.Services.Customers
{
    public interface ICustomerService
    {
        public Task<IEnumerable<Customer>> GetAllCustomersAsync();
    }
}