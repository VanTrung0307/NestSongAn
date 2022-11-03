using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessObjects.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories.Service;

namespace NestSongAn.Pages.Admin.Salers
{
    //[Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly IAccountService _accountRepository;
        
        public IndexModel(IAccountService accountRepo)
        {
            _accountRepository = accountRepo;
        }
        [BindProperty]
        public IEnumerable<Account> Saler { get; set; }
        public IActionResult OnGet()
        {
            Saler = _accountRepository.GetListAccount();
            return Page();
        }
        public IActionResult OnGetLogout()
        {
            HttpContext.Session.Remove("Role");
            return RedirectToPage("/Login/LoginPage");
        }
    }
}
