using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessObjects.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories.Service;

namespace NestSongAn.Pages.Admin.Products
{
    //[Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly IProductService _productService;
        private readonly IStockService _stockService;
        public CreateModel(IProductService productRepo, IStockService stockService)
        {
            _productService = productRepo;
            _stockService = stockService;
        }
        [BindProperty(SupportsGet = true)]
        public Product Product { get; set; }
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
            _productService.InsertProduct(Product);
            return Redirect("./Index");
        }
    }
}
