using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Domain.Interfaces;
using Domain.Entities;
using System.Threading.Tasks;
using System;
using Application.Services;
using Application.Dtos;

namespace RazorPages.Pages.Customers
{
    public class CreateModel : PageModel
    {
        private readonly CustomerService _customerService;

        public CreateModel(CustomerService customerService)
        {
            _customerService = customerService;
        }

        [BindProperty]
        public CustomerDto Customer{ get; set; }

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

            Customer.CustomerId = Guid.NewGuid();

            await _customerService.AddCustomerAsync(Customer);

            return RedirectToPage("./Index");
        }
    }
}
