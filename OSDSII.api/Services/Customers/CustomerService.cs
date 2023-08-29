using OSDSII.api.Models;
using OSDSII.api.Repositories.Interfaces;
using OSDSII.api.Repositories.Unit_Of_Work;

namespace OSDSII.api.Services.Customers
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customersRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CustomerService(ICustomerRepository customersRepository, IUnitOfWork unitOfWork)
        {
            _customersRepository = customersRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            return await _customersRepository.GetAllCustomersAsync();
        }

        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            Customer customer = await _customersRepository.GetCustomerByIdAsync(id);

            return customer;
        }

        public async Task<Customer> CreateCustomerAsync(Customer customer)
        {
            Customer currentCustomer = await _customersRepository.GetCustomerByIdAsync(customer.Id);

            if (currentCustomer != null && currentCustomer.Equals(customer))
            {
                throw new Exception("Customer already exists.");
            }

            await _customersRepository.CreateCustomerAsync(customer);
            await _unitOfWork.SaveChangesAsync();
            return currentCustomer;
        }

        public async Task<Customer> UpdateCustomerAsynAsync(int id, Customer customer)
        {
            Customer currentCustomer = await _customersRepository.GetCustomerByIdAsync(id);
            if(currentCustomer is null)
            {
                throw new Exception("Not found"); 
            }

            currentCustomer.Name = customer.Name;
            currentCustomer.Email = customer.Email;
            currentCustomer.Phone = customer.Phone;

            await _unitOfWork.SaveChangesAsync();

            return customer;
        }
    }

}