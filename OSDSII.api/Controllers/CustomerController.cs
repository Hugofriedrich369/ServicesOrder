using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OSDSII.api.Data;
using OSDSII.api.Exceptions;
using OSDSII.api.Models;
using OSDSII.api.Repositories.Interfaces;
using OSDSII.api.Services.Customers;

namespace OSDSII.api.Controllers
{
    [Controller]
    [Route("[Controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly ICustomerService _customerService;

        public CustomerController(DataContext context, ICustomerService customerService)
        {
            _context = context;
            _customerService = customerService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                IEnumerable<Customer> listacustomer = await _customerService.GetAllCustomersAsync();
                return Ok(listacustomer);
            }
            catch (BaseException ex)
            {
                return ex.GetResponse();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                Customer customer = await _customerService.GetCustomerByIdAsync(id);

                return Ok(customer);
            }
            catch (BaseException ex)
            {
                return ex.GetResponse();
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] Customer novoCustomer)
        {
            try
            {
                Customer customer = await _customerService.CreateCustomerAsync(novoCustomer);
                return Ok(customer);
            }
            catch (BaseException ex)
            {
                return ex.GetResponse();
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(Customer novoCustomer)
        {
            try
            {
                await _customerService.UpdateCustomerAsync(novoCustomer.Id, novoCustomer);
                return Ok();
            }
            catch (BaseException ex)
            {
                return ex.GetResponse();
            }
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            try
            {
                Customer customerRemover = await _context.Customers.FirstOrDefaultAsync(p => p.Id == id);

                _context.Customers.Remove(customerRemover);
                int linhaAfetadas = await _context.SaveChangesAsync();

                return Ok(linhaAfetadas);
            }
            catch (BaseException ex)
            {
                return ex.GetResponse();
            }
        }


    }
}
