using OSDSII.api.Models;
using OSDSII.api.Repositories.Interfaces;

namespace OSDSII.api.Services.Customers
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customersRepository;

        public CustomerService(ICustomerRepository customersRepository)
        {
            _customersRepository = customersRepository;
        }
        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            return await _customersRepository.GetAllCustomersAsync();
        }
    }
}