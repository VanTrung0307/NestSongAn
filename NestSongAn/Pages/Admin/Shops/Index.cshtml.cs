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

namespace NestSongAn.Pages.Admin.Shops
{
    /*[Authorize(Roles = "Admin")]*/
    public class IndexModel : PageModel
    {
        private readonly IShopService _shopRepository;
        public IndexModel(IShopService shopRepo)
        {
            _shopRepository = shopRepo;
        }
        [BindProperty]
        public IEnumerable<Shop> Shop { get; set; }
        public IActionResult OnGet()
        {
            Shop = _shopRepository.GetShopList();
            return Page();
        }
        public IActionResult OnGetLogout()
        {
            HttpContext.Session.Remove("Role");
            return RedirectToPage("/Login/LoginPage");
        }
    }
}
