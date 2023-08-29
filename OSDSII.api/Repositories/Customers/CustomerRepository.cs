using Microsoft.EntityFrameworkCore;
using OSDSII.api.Data;
using OSDSII.api.Models;
using OSDSII.api.Repositories.Interfaces;

namespace OSDSII.api.Repositories.Customers
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DataContext _context;

        public CustomerRepository(DataContext context)
        {
            _context = context;

        }
        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            IEnumerable<Customer> customers = await _context.Customers.ToListAsync();
            return customers;
        }
        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
           return await _context.Customers.FirstOrDefaultAsync(customer => customer.Id == id);
        }
        public async Task CreateCustomerAsync(Customer customer)
        {
            await _context.AddAsync(customer);
        }

    }
}