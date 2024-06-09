using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Domain.Interfaces;
using Domain.Entities;
using System.Threading.Tasks;
using System;
using Application.Dtos;
using Application.Services;
using System.Security.Principal;

namespace RazorPages.Pages.Rentals
{
    public class EditModel : PageModel
    {
        private readonly RentalService _rentalService;

        public EditModel(RentalService rentalService)
        {
            _rentalService = rentalService;
        }

        [BindProperty]
        public RentalDto Rental { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            Rental = await _rentalService.GetRentalByIdAsync(id);
            if (Rental == null)
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

            await _rentalService.UpdateRentalAsync(Rental);

            return RedirectToPage("./Index");
        }
    }
}
