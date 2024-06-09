using Microsoft.AspNetCore.Mvc.RazorPages;
using Domain.Interfaces;
using Domain.Entities; 
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Services;
using Application.Dtos;

namespace RazorPages.Pages.Cars
{
    public class IndexModel : PageModel
    {
        private readonly CarService _carService;

        public IndexModel(CarService carService)
        {
            _carService = carService;
        }

        public IList<CarDto> Cars { get; set; }

        public async Task OnGetAsync()
        {
            Cars = (IList<CarDto>)await _carService.GetAllCarsAsync();
        }
    }
}
