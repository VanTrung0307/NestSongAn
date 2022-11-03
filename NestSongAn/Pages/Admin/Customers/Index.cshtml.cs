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
    public class IndexModel : PageModel
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IAccountService _accountService;

        public IndexModel(ICustomerRepository customerRepo, IAccountService accRepo)
        {
            _customerRepository = customerRepo;
            _accountService = accRepo;
        }
        [BindProperty(SupportsGet = true)]
        public IEnumerable<Customer> Customer { get; set; }
        public IActionResult OnGet()
        {
            ViewData["Account"] = new SelectList(_accountService.GetListAccount(), "Id", "Name");
            _customerRepository.GetCustomer();
            return Page();
        }
        public IActionResult OnGetLogout()
        {
            HttpContext.Session.Remove("Role");
            return RedirectToPage("/Login/LoginPage");
        }
    }
}
