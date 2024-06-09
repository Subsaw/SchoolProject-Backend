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
    public class DetailsModel : PageModel
    {
        private readonly RentalService _rentalService;

        public DetailsModel(RentalService rentalService)
        {
            _rentalService = rentalService;
        }

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
    }
}
