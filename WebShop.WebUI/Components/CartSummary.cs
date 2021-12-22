using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Domain.Abstract;
using WebShop.Domain.Models;
using WebShop.WebUI.Extensions;

namespace WebShop.WebUI.Components
{
   
    public class CartSummary : ViewComponent
    {
        private readonly IUnitOfWork db;

        public CartSummary(IUnitOfWork unitOfWork)
        {
            db = unitOfWork;
        }

        public ViewViewComponentResult Invoke()
        {
            string sessionKey = "cart";
            IEnumerable<CartItem> cartItems = HttpContext.Session.Get<IEnumerable<CartItem>>(sessionKey);
            Cart cart = new Cart();
            cart.AddItems(cartItems);
            return View(cart);
        }
    }
}
