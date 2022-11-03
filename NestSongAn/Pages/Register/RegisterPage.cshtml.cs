using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DataAccessObjects.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories.Service;

namespace NestSongAn.Pages.Register
{
    public class RegisterPageModel : PageModel
    {
        private readonly IAccountService _accountRepository;

        [BindProperty]
        [Required]
        public string Name { get; set; }
        [BindProperty]
        [Required]
        public string AccountType { get; set; }
        [BindProperty]
        [Required]
        public string Password { get; set; }
        [BindProperty]
        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        [BindProperty]
        [Required]
        public string Phone { get; set; }
        [BindProperty]
        [Required]
        public string Email { get; set; }
        public Account account { get; set; }
        public string Role { get; set; }
        public RegisterPageModel(IAccountService accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            var checkExist = _accountRepository.CheckAccount(Email, Password);
            if (checkExist != null)
            {
                ViewData["ErrorMessage"] = "The username has existed, Please enter new username";
                return Page();
            }
            if (Password != ConfirmPassword)
            {
                ViewData["ErrorMessage"] = "The password must match confirm password";
                return Page();
            }
              _accountRepository.InsertAccount(account);

            if (account != null)
            {
                HttpContext.Session.SetString("Email", account.Email);
                HttpContext.Session.SetString("Role", account.AccountType.ToString("Customer"));
                return RedirectToPage("/Index");
            }
            return Page();

        }
    }
}
