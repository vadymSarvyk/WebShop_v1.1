using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop.Domain.Models
{
    public class Cart
    {
        List<CartItem> cartItems = new List<CartItem>();

        public IEnumerable<CartItem> CartItems => cartItems;

        public void AddItem(Product product, int quantity)
        {
            CartItem cartItem = cartItems.FirstOrDefault(t => t.Product.Id == product.Id);
            if (cartItem != null)
                cartItem.Quantity += quantity;
            else
                cartItems.Add(new CartItem { Product = product, Quantity = quantity });
        }

        public void RemoveItem(Product product)
        {
            cartItems.RemoveAll(t => t.Product.Id == product.Id);
        }

        public void Clear()
        {
            cartItems.Clear();
        }

        public double GetTotalSum()
        {
            return cartItems.Sum(t => t.Product.Price * t.Quantity);
        }

        public void AddItems(IEnumerable<CartItem> items)
        {
            cartItems.AddRange(items);
        }
    }
}
