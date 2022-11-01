using DataAccessObjects.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Repositories.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NestSongAn.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IProductService _productService;

        public IndexModel(ILogger<IndexModel> logger, IProductService productService)
        {
            _productService = productService;
            _logger = logger;
        }
        public IEnumerable<Product> Products { get; set; }
        public IActionResult OnGet()
        {
            Products = _productService.GetProductList();
            return Page();
        }
    }
}
