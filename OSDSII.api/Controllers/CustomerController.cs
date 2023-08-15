using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OSDSII.api.Data;
using OSDSII.api.Models;

namespace OSDSII.api.Controllers
{
    [Controller]
    [Route("[Controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly DataContext _context;

        public CustomerController(DataContext context) {
            _context = context;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
            List<Customer> listacustomer = await _context.Customers.ToListAsync();
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
                return Ok(customer);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer(Customer novoCustomer)
        {
            try
            {
                await _context.Customers.AddAsync(novoCustomer);
                await _context.SaveChangesAsync();

                return Ok(novoCustomer.Id);
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
