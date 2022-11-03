using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessObjects.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repositories.Service;

namespace NestSongAn.Pages.Admin.Customers
{
    //[Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        private readonly IAccountService _accountService;
        private readonly ICustomerRepository _customerRepository;
        public EditModel(ICustomerRepository customerRepository, IAccountService accRepo)
        {
            _accountService = accRepo;
            _customerRepository = customerRepository;
        }
        [BindProperty(SupportsGet = true)]
        public Customer Customer { get; set; }
        public IActionResult OnGet(int Id)
        {
            ViewData["Account"] = new SelectList(_accountService.GetListAccount(), "Id", "Name");
            Customer = _customerRepository.GetCustomerById(Id);
            return Page();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _customerRepository.UpdateCustomer(Customer);
            return RedirectToPage("./Index");
        }
    }
}
