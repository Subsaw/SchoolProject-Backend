using Application.Dtos;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService _customerService;

        public CustomerController(CustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            var customers = await _customerService.GetAllCustomersAsync();
            return Ok(customers);
        }

        [HttpGet("by-id/{id:guid}")]
        public async Task<IActionResult> GetCustomerById(Guid id)
        {
            try
            {
                var customer = await _customerService.GetCustomerByIdAsync(id);
                if (customer == null)
                {
                    return NotFound("Customer not found");
                }

                return Ok(customer);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] CustomerDto customerDto)
        {
            if (customerDto == null)
            {
                return BadRequest("Customer data is null");
            }

            try
            {
                var createdCustomer = await _customerService.AddCustomerAsync(customerDto);
                return CreatedAtAction(nameof(GetCustomerById), new { id = createdCustomer.CustomerId }, createdCustomer);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(Guid id, [FromBody] CustomerDto customerDto)
        {
            if (customerDto == null || id != customerDto.CustomerId)
            {
                return BadRequest("Customer data is invalid");
            }

            try
            {
                var updatedCustomer = await _customerService.UpdateCustomerAsync(customerDto);
                if (updatedCustomer == null)
                {
                    return NotFound("Customer not found");
                }

                return Ok(updatedCustomer);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(Guid id)
        {
            try
            {
                var customer = await _customerService.GetCustomerByIdAsync(id);
                if (customer == null)
                {
                    return NotFound("Customer not found");
                }

                await _customerService.DeleteCustomerAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("byemail/{email}")]
        public async Task<IActionResult> GetCustomerByEmail(string email)
        {
            try
            {
                var customer = await _customerService.GetCustomerByEmailAsync(email);
                if (customer == null)
                {
                    return NotFound("Customer not found");
                }

                return Ok(customer);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
