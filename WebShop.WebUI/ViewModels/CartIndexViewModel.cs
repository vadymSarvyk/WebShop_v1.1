using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Domain.Models;

namespace WebShop.WebUI.ViewModels
{
    public class CartIndexViewModel
    {
        public string ReturnUrl { get; set; }

        public Cart  Cart { get; set; }
    }
}
