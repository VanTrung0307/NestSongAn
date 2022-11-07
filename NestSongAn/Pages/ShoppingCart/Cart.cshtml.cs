using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DataAccessObjects.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NestSongAn.Helper;
using Repositories.Service;

namespace NestSongAn.Pages.ShoppingCart
{
    public class CartModel : PageModel
    {
        private readonly IAccountService _accountRepository;
        private readonly IProductService _productRepository;
        private readonly IOrderRepository _orderRepository;
        public readonly ICustomerRepository _customerRepository;
        /*private readonly IOrderDetailRepository _orderDetailRepository;*/

        public CartModel(IAccountService accountRepository, IProductService productRepository, IOrderRepository orderRepository, ICustomerRepository customerRepository)
        {
            _accountRepository = accountRepository;
            _productRepository = productRepository;
            _orderRepository = orderRepository;
            _customerRepository = customerRepository;
        }

        public string Name { get; set; }
        [BindProperty]
        [Required]
        public string Password { get; set; }
        [BindProperty]
        [Required]
        public string Email { get; set; }
        public string Role { get; set; }
        public List<Item> cartCus { get; set; }
        public Product Product { get; set; }
        public Account Account { get; set; }
        public Customer Customer { get; set; }
        public Order Order { get; set; }
        [BindProperty]
        public double? Total { get; set; } = 0;


        public void OnGet(int id, string email)
        {
            Email = HttpContext.Session.GetString("Email");
            Role = HttpContext.Session.GetString("Role");
            Customer = _customerRepository.GetCustomerByEmail(email);
            cartCus = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cartCus");
            var product = _productRepository.GetProductByID(id);
            if (cartCus == null)
            {
                cartCus = new List<Item>();
                cartCus.Add(new Item
                {
                    Product = product,
                    Quantity = 1
                });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cartCus", cartCus);

            }
            else
            {
                int index = Exists(cartCus, id);
                if (index == -1)
                {
                    cartCus.Add(new Item
                    {
                        Product = product,
                        Quantity = 1
                    });
                }
                else
                {
                    cartCus[index].Quantity++;
                }

                SessionHelper.SetObjectAsJson(HttpContext.Session, "cartCus", cartCus);
            }
        }

        private int Exists(List<Item> cart, int id)
        {
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Product.Id == id)
                {
                    return i;
                }
            }
            return -1;
        }

        public void OnGetDelete(int id)
        {
            Email = HttpContext.Session.GetString("Email");
        }
    }
}
