using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories.Service;
using static BusinessObjects.Enum.Enum;

namespace NestSongAn.Pages.Login
{
    public class LoginModel : PageModel
    {
        private readonly IAccountService _accountRepository;
        public LoginModel(IAccountService account)
        {
            _accountRepository = account;
        }
        public string Name { get; set; }
        [BindProperty]
        [Required]
        public string Password { get; set; }
        [BindProperty]
        [Required]
        public string Email { get; set; }
        public string Role { get; set; }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            var claims = new List<Claim>();
            if (ModelState.IsValid)
            {
                var account = _accountRepository.CheckAccount(Email, Password);
                if (account == null)
                {
                    throw new Exception("Account does not exist");
                }

                switch (account.AccountType)
                {
                    case (int)AccountTypeEnum.Customer:
                        Role = "Customers";
                        HttpContext.Session.SetString("Role", Role);
                        break;
                    case (int)AccountTypeEnum.Admin:
                        Role = "Admin";
                        HttpContext.Session.SetString("Role", Role);

                        break;
                    case (int)AccountTypeEnum.Saller:
                        Role = "Saler";
                        HttpContext.Session.SetString("Role", Role);
                        break;
                }
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                await HttpContext.SignInAsync(claimsPrincipal);
                return Redirect("/Index");
                //return null;
            }
            TempData["Error"] = "Invalid input";
            return Redirect("/Login/LoginPage");
            //return null;
        }
    }
}
