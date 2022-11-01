using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessObjects.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repositories.Service;

namespace NestSongAn.Pages.Stocks
{
    public class IndexModel : PageModel
    {

        private readonly IStockService _stockRepository;
        private readonly IShopService _shopRepository;
        public IndexModel (IStockService stockRepo, IShopService shopRepo)
        {
            _stockRepository = stockRepo;
            _shopRepository = shopRepo;
        }
        public IEnumerable<Stock> Stocks { get; set; }
        public IActionResult OnGet()
        {
            ViewData["Shop"] = new SelectList(_shopRepository.GetShopList(), "Id", "Name");
            Stocks = _stockRepository.GetStocks();
            return Page();
        }
    }
}
