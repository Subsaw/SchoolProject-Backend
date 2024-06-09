using Microsoft.AspNetCore.Mvc.RazorPages;
using Domain.Interfaces;
using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Services;
using Application.Dtos;

namespace RazorPages.Pages.Rentals
{
    public class IndexModel : PageModel
    {
        private readonly RentalService _rentalService;

        public IndexModel(RentalService rentalService)
        {
            _rentalService = rentalService;
        }

        public IList<RentalDto> Rentals { get; set; }

        public async Task OnGetAsync()
        {
            Rentals = (IList<RentalDto>)await _rentalService.GetAllRentalsAsync();
        }
    }
}
