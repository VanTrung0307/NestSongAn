using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessObjects.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories.Service;

namespace NestSongAn.Pages.Admin.Customers
{
    //[Authorize(Roles = "Admin")]

    public class DeleteModel : PageModel
    {
        
        private readonly ICustomerRepository _customerRepository;
        public DeleteModel(ICustomerRepository cusRepo)
        {
            _customerRepository = cusRepo;
        }
        [BindProperty]
        public Customer Customer { get; set; }
        public IActionResult OnGet(int Id)
        {
            Customer = _customerRepository.GetCustomerById(Id);
            return Page();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _customerRepository.DeleteCustomer(Customer);
            return Redirect("./Index");
        }
    }
}
