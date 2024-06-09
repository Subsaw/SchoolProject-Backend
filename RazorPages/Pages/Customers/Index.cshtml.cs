using Microsoft.AspNetCore.Mvc.RazorPages;
using Domain.Interfaces;
using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Services;
using Application.Dtos;

namespace RazorPages.Pages.Customers
{
    public class IndexModel : PageModel
    {
        private readonly CustomerService _customerService;

        public IndexModel(CustomerService customerService)
        {
            _customerService = customerService;
        }

        public IList<CustomerDto> Customers { get; set; }

        public async Task OnGetAsync()
        {
            Customers = (IList<CustomerDto>)await _customerService.GetAllCustomersAsync();
        }
    }
}
