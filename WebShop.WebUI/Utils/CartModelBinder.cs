﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using WebShop.Domain.Models;
using WebShop.WebUI.Extensions;

namespace WebShop.WebUI.Utils
{
    public class CartModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            string sessionKey = "cart";
            Cart cart = new Cart();
            IEnumerable<CartItem> cartItems = null;
            if (bindingContext.HttpContext.Session!=null)
            {
                cartItems = bindingContext.HttpContext.Session.Get<IEnumerable<CartItem>>(sessionKey);
            }
            if(cartItems==null)
            {
                cartItems = new List<CartItem>();
                bindingContext.HttpContext.Session.Set(sessionKey, cartItems);
            }
            cart.AddItems(cartItems);
            bindingContext.Result = ModelBindingResult.Success(cart);
            return Task.CompletedTask;
        }
    }
}
