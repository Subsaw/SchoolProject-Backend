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
    public class DeleteModel : PageModel
    {
        private readonly CarService _carService;

        public DeleteModel(CarService carService)
        {
            _carService = carService;
        }

        [BindProperty]
        public CarDto Car { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            Car = await _carService.GetCarByIdAsync(id);

            if (Car == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid id)
        {
            var car = await _carService.GetCarByIdAsync(id);

            if (car != null)
            {
                await _carService.DeleteCarAsync(id);
            }

            return RedirectToPage("./Index");
        }
    }
}
