﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop.Domain.Models
{
    public class CartItem
    {
        public Product Product { get; set; }

        public int Quantity { get; set; }
    }
}
