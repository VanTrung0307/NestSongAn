using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
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
                    //throw error
                }

                switch (account.AccountType)
                {
                    case (int)AccountTypeEnum.Customer:
                        claims.Add(new Claim(ClaimTypes.Role, "Customer"));
                        break;
                    case (int)AccountTypeEnum.Admin:
                        claims.Add(new Claim(ClaimTypes.Role, "Admin"));
                        break;
                    case (int)AccountTypeEnum.Saller:
                        claims.Add(new Claim(ClaimTypes.Role, "Saler"));
                        break;
                }
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                await HttpContext.SignInAsync(claimsPrincipal);
                //return page nào tự set 
                return null;
            }
            TempData["Error"] = "Invalid input";
            //login fail -> return page nào
            return null;
        }
    }
}
