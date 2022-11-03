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
    public class DetailsModel : PageModel
    {
        
            private readonly IAccountService _accountRepository;
            public DetailsModel(IAccountService accountRepo)
            {
                _accountRepository = accountRepo;
            }
        [BindProperty(SupportsGet = true)]
        public Account Saler { get; set; }
            public IActionResult OnGet(int Id)
            {
                Saler = _accountRepository.GetAccountByID(Id);
                return Page();
            }
        
    }
}
