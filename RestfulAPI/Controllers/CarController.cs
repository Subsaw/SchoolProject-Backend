using Application.Dtos;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarController : ControllerBase
    {
        private readonly CarService _carService;

        public CarController(CarService carService)
        {
            _carService = carService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCars()
        {
            var cars = await _carService.GetAllCarsAsync();
            return Ok(cars);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarById(Guid id)
        {
            try
            {
                var car = await _carService.GetCarByIdAsync(id);
                if (car == null)
                {
                    return NotFound("Car not found");
                }

                return Ok(car);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateCar([FromBody] CarDto carDto)
        {
            if (carDto == null)
            {
                return BadRequest("Car data is null");
            }

            try
            {
                var createdCar = await _carService.AddCarAsync(carDto);
                return CreatedAtAction(nameof(GetCarById), new { id = createdCar.CarId }, createdCar);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCar(Guid id, [FromBody] CarDto carDto)
        {
            if (carDto == null || id != carDto.CarId)
            {
                return BadRequest("Car data is invalid");
            }

            try
            {
                var updatedCar = await _carService.UpdateCarAsync(carDto);
                if (updatedCar == null)
                {
                    return NotFound("Car not found");
                }

                return Ok(updatedCar);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(Guid id)
        {
            try
            {
                var car = await _carService.GetCarByIdAsync(id);
                if (car == null)
                {
                    return NotFound("Car not found");
                }

                await _carService.DeleteCarAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
