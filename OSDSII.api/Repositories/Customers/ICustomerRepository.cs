using OSDSII.api.Models;

namespace OSDSII.api.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        public Task<IEnumerable<Customer>> GetAllCustomersAsync();
        public Task<Customer> GetCustomerByIdAsync(int id);
        public Task CreateCustomerAsync(Customer customer);
    }
}