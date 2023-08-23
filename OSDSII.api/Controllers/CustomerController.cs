using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OSDSII.api.Data;
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
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                Customer customer = await _context.Customers.FirstOrDefaultAsync(customer => customer.Id == id);
                if (customer == null)
                {
                    return NotFound();
                }

                return Ok(customer);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] Customer novoCustomer)
        {
            try
            {
                Customer Customer = await _context.Customers.FirstOrDefaultAsync(c => c.Email == novoCustomer.Email);
                if (novoCustomer != null && Customer.Equals(novoCustomer.Email))
                {
                    throw new Exception("Usuário já existe");
                }
                await _context.Customers.AddAsync(novoCustomer);
                await _context.SaveChangesAsync();

                return Ok(novoCustomer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(Customer novoCustomer)
        {
            try
            {
                _context.Customers.Update(novoCustomer);
                int linhaAfetadas = await _context.SaveChangesAsync();

                return Ok(linhaAfetadas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
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
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
