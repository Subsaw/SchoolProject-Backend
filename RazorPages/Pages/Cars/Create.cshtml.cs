using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Domain.Interfaces;
using Domain.Entities;
using System.Threading.Tasks;
using System;
using Application.Services;
using Application.Dtos;

namespace RazorPages.Pages.Cars
{
    public class CreateModel : PageModel
    {
        private readonly CarService _carService;

        public CreateModel(CarService carService)
        {
            _carService = carService;
        }

        [BindProperty]
        public CarDto Car { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Car.CarId = Guid.NewGuid();

            await _carService.AddCarAsync(Car);

            return RedirectToPage("./Index");
        }
    }
}
