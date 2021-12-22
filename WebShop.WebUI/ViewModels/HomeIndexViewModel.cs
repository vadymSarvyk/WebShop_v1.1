using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Domain.Models;
using PagedList.Core;

namespace WebShop.WebUI.ViewModels
{
    public class HomeIndexViewModel
    {
        //public IEnumerable<Category> Categories { get; set; }

        public IPagedList<Product> Products { get; set; }

        public string CurrentCategory { get; set; }

        public Cart Cart { get; set; }
    }
}
