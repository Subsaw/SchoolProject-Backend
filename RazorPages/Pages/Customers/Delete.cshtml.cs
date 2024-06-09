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
    public class DeleteModel : PageModel
    {
        private readonly CustomerService _customerService;

        public DeleteModel(CustomerService customerService)
        {
            _customerService = customerService;
        }

        [BindProperty]
        public CustomerDto Customer { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            Customer = await _customerService.GetCustomerByIdAsync(id);

            if (Customer == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid id)
        {
            var customer = await _customerService.GetCustomerByIdAsync(id);

            if (customer != null)
            {
                await _customerService.DeleteCustomerAsync(id);
            }

            return RedirectToPage("./Index");
        }
    }
}
