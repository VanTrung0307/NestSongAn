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
    public class DetailsModel : PageModel
    {
        private readonly IProductService _productRepository;
        public DetailsModel(IProductService productRepo)
        {
            _productRepository = productRepo;
        }
        [BindProperty(SupportsGet = true)]
        public Product Product { get; set; }
        public IActionResult OnGet(int Id)
        {
            Product = _productRepository.GetProductByID(Id);
            return Page();
        }
    }
}
