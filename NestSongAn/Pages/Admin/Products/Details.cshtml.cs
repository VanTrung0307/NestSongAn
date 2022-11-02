using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NestSongAn.Pages.Admin.Products
{
    [Authorize(Roles = "Admin")]
    public class DetailsModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
