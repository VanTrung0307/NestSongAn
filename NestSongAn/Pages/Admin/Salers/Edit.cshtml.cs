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
    public class EditModel : PageModel
    {
        private readonly IAccountService _accountRepository;
        public EditModel(IAccountService accountRepo)
        {
            _accountRepository = accountRepo;
        }
        [BindProperty]
        public Account Saler { get; set; }
        public IActionResult OnGet(int Id)
        {
            Saler = _accountRepository.GetAccountByID(Id);
            return Page();
        }
        public IActionResult OnPost(int Id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _accountRepository.UpdateAccount(Id, Saler);
            return RedirectToPage("./Index");
        }
    }
}
