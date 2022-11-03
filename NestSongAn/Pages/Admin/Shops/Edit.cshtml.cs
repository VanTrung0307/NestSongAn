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
    /*[Authorize(Roles = "Admin")]*/
    public class EditModel : PageModel
    {
        private readonly IShopService _shopRepository;
        public EditModel(IShopService shopRepo)
        {
            _shopRepository = shopRepo;
        }
        [BindProperty]
        public Shop Shop { get; set; }
        public IActionResult OnGet()
        {
            return Page();
        }
        public IActionResult OnPost(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _shopRepository.UpdateShop(id, Shop);
            return Redirect("./Index");
        }
    }
}
