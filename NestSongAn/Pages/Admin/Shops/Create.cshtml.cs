using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessObjects.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories.Service;

namespace NestSongAn.Pages.Admin.Shops
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly IShopService _shopRepository;
        public CreateModel(IShopService shopRepo)
        {
            _shopRepository = shopRepo;
        }
        public Shop Shop { get; set; }
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
            _shopRepository.InsertShop(Shop);
            return Redirect("./Index");
        }
    }
}
