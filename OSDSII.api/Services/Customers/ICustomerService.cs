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
        public Task<Customer> GetCustomerByIdAsync(int id);
        public Task<Customer> CreateCustomerAsync(Customer customer);
        public Task<Customer> UpdateCustomerAsync(int id, Customer customer);
    }
}