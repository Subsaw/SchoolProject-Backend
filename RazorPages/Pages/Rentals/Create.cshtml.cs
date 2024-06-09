using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Domain.Interfaces;
using Domain.Entities;
using System.Threading.Tasks;
using System;
using Application.Services;
using Application.Dtos;

namespace RazorPages.Pages.Rentals
{
    public class CreateModel : PageModel
    {
        private readonly RentalService _rentalService;

        public CreateModel(RentalService rentalService)
        {
            _rentalService = rentalService;
        }

        [BindProperty]
        public RentalDto Rental { get; set; }

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

            Rental.RentalId = Guid.NewGuid();

            await _rentalService.AddRentalAsync(Rental);

            return RedirectToPage("./Index");
        }
    }
}
