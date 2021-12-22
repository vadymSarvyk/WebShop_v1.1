using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Domain.Models;
using WebShop.Domain.Abstract;
using WebShop.WebUI.Extensions;
using WebShop.WebUI.ViewModels;

namespace WebShop.WebUI.Controllers
{
    public class CartController : Controller
    {
        private readonly IUnitOfWork db;
        public CartController(IUnitOfWork unitOfWork)
        {
            db = unitOfWork;
        }
        [HttpPost]
        public IActionResult AddToCart(Cart cart, int id, string returnUrl)
        {
            Product product = db.Products.GetItem(id);
            if (product != null)
                cart.AddItem(product, 1);
            HttpContext.Session.Set<IEnumerable<CartItem>>("cart", cart.CartItems);
            return RedirectToAction("Index", "Cart", new { returnUrl});
        }

        [HttpPost]
        public IActionResult RemoveFromCart(Cart cart, int id, string returnUrl)
        {
            Product product = db.Products.GetItem(id);
            if (product != null)
                cart.RemoveItem(product);
            HttpContext.Session.Set<IEnumerable<CartItem>>("cart", cart.CartItems);
            return RedirectToAction("Index", "Cart", new { returnUrl });
        }

        public IActionResult Index(Cart cart, string returnUrl)
        {
            return View(new CartIndexViewModel { Cart = cart, ReturnUrl = returnUrl });
        }

        //public IActionResult Summary(Cart cart)
        //{

        //}
    }
}
