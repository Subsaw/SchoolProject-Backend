using Application.Dtos;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RentalController : ControllerBase
    {
        private readonly RentalService _rentalService;

        public RentalController(RentalService rentalService)
        {
            _rentalService = rentalService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRentals()
        {
            var rentals = await _rentalService.GetAllRentalsAsync();
            return Ok(rentals);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRentalById(Guid id)
        {
            try
            {
                var rental = await _rentalService.GetRentalByIdAsync(id);
                if (rental == null)
                {
                    return NotFound("Rental not found");
                }

                return Ok(rental);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateRental([FromBody] RentalDto rentalDto)
        {
            if (rentalDto == null)
            {
                return BadRequest("Rental data is null");
            }

            try
            {
                var createdRental = await _rentalService.AddRentalAsync(rentalDto);
                return CreatedAtAction(nameof(GetRentalById), new { id = createdRental.RentalId }, createdRental);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRental(Guid id, [FromBody] RentalDto rentalDto)
        {
            if (rentalDto == null || id != rentalDto.RentalId)
            {
                return BadRequest("Rental data is invalid");
            }

            try
            {
                var updatedRental = await _rentalService.UpdateRentalAsync(rentalDto);
                if (updatedRental == null)
                {
                    return NotFound("Rental not found");
                }

                return Ok(updatedRental);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRental(Guid id)
        {
            try
            {
                var rental = await _rentalService.GetRentalByIdAsync(id);
                if (rental == null)
                {
                    return NotFound("Rental not found");
                }

                await _rentalService.DeleteRentalAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
