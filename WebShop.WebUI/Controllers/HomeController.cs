using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using WebShop.Domain.Models;
using WebShop.WebUI.Extensions;
using WebShop.Domain.Abstract;
using WebShop.WebUI.ViewModels;
using PagedList.Core;


namespace WebShop.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork db;

        public HomeController(IUnitOfWork unitOfWork)
        {
            db = unitOfWork;
        }
        public IActionResult Index(int? page, string category, Cart cart)
        {
            var products = db.Products.GetAll();
            if (!string.IsNullOrEmpty(category))
                products = products.Where(t => t.Category.Name.ToLower() == category.ToLower());
            int pageNumber = page ?? 1;
            int pageSize = 1;
            return View(new HomeIndexViewModel { Products = products.ToPagedList(pageNumber, pageSize), CurrentCategory = category, Cart = cart });
        }

        public IActionResult ShowName()
        {
            string name = HttpContext.Session.GetString("name");
            return Content($"Name: {name}");
        }

        public IActionResult SetCart()
        {
            Cart cart = new Cart();

            Product product1 = db.Products.GetAll().FirstOrDefault(t => t.Id == 1);
            Product product2 = db.Products.GetAll().FirstOrDefault(t => t.Id == 2);
            cart.AddItem(product1, 2);
            cart.AddItem(product2, 1);
            HttpContext.Session.Set("cart", cart.CartItems);
            return RedirectToAction("ShowCart");
        }

        public IActionResult ShowCart(Cart cart)
        {
            //Cart cart = GetCart();
            return View(cart);
        }

        private Cart GetCart()
        {
            IEnumerable<CartItem> cartItems = HttpContext.Session.Get<IEnumerable<CartItem>>("cart");
            if (cartItems == null)
            {
                cartItems = new List<CartItem>();
                HttpContext.Session.Set<IEnumerable<CartItem>>("cart", cartItems);
            }
            Cart cart = new Cart();
            cart.AddItems(cartItems);
            return cart;
        }
    }
}
