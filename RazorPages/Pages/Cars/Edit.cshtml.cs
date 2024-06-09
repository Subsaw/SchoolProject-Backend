using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Domain.Interfaces;
using Domain.Entities;
using System.Threading.Tasks;
using System;
using Application.Dtos;
using Application.Services;
using System.Security.Principal;

namespace RazorPages.Pages.Cars
{
    public class EditModel : PageModel
    {
        private readonly CarService _carService;

        public EditModel(CarService carService)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _carService.UpdateCarAsync(Car);

            return RedirectToPage("./Index");
        }
    }
}
