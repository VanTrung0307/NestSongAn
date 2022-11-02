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
    [Authorize(Roles = "Admin")]
    public class DetailsModel : PageModel
    {
        private readonly IShopService _shopRepository;
        public DetailsModel(IShopService shopRepo)
        {
            _shopRepository = shopRepo;
        }
        public Shop Shop { get; set; }
        public IActionResult OnGet(int Id)
        {
            ViewData["Shop"] = new SelectList(_shopRepository.GetShopList(), "Id", "Name");
            Shop = _shopRepository.GetShopByID(Id);
            return Page();
        }
    }
}
