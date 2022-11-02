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

namespace NestSongAn.Pages.Stocks
{
    /*[Authorize(Roles = "Admin")]*/
    
    public class CreateModel : PageModel
    {
        private readonly IStockService _stockRepository;
        private readonly IShopService _shopRepository;
        public CreateModel(IStockService stockRepo, IShopService shopRepo)
        {
            _stockRepository = stockRepo;
            _shopRepository = shopRepo;
        }
        public Stock Stocks { get; set; }
        public IActionResult OnGet()
        {
            ViewData["Shop"] = new SelectList(_shopRepository.GetShopList(), "Id", "Name");
            
            return Page();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _stockRepository.InsertStock(Stocks);
            return Redirect("./Index");
        }
    }
}
