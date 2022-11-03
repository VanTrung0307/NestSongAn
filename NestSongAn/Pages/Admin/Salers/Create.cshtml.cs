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

namespace NestSongAn.Pages.Admin.Salers
{
    //[Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {

        private readonly IAccountService _accountRepository;
        public CreateModel(IAccountService accountRepo)
        {
            _accountRepository = accountRepo;
        }
        [BindProperty]
        public Account Saler { get; set; }
        public IActionResult OnGet()
        {
            return Page();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _accountRepository.InsertAccount(Saler);
            return Redirect("./Index");
        }
    }
}
