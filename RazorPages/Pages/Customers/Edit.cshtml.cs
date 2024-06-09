using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Domain.Interfaces;
using Domain.Entities;
using System.Threading.Tasks;
using System;
using Application.Dtos;
using Application.Services;
using System.Security.Principal;

namespace RazorPages.Pages.Customers
{
    public class EditModel : PageModel
    {
        private readonly CustomerService _customerService;

        public EditModel(CustomerService customerService)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _customerService.UpdateCustomerAsync(Customer);

            return RedirectToPage("./Index");
        }
    }
}
