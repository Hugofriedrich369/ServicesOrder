using OSDSII.api.Models;

namespace OSDSII.api.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        public Task<IEnumerable<Customer>> GetAllCustomersAsync();
    }
}