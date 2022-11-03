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
    public class IndexModel : PageModel
    {
        private readonly IProductService _productRepository;

        public IndexModel(IProductService productRepo)
        {
            _productRepository = productRepo;
        }
        [BindProperty(SupportsGet = true)]
        public IEnumerable<Product> Product { get; set; }
        public IActionResult OnGet()
        {
            Product = _productRepository.GetProductList();
            return Page();
        }
        public IActionResult OnGetLogout()
        {
            HttpContext.Session.Remove("Role");
            return RedirectToPage("/Login/LoginPage");
        }
    }
}
