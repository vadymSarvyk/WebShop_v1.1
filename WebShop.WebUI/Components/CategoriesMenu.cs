using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Domain.Abstract;

namespace WebShop.WebUI.Components
{
    //[ViewComponent]
    public class CategoriesMenu : ViewComponent
    {
        private readonly IUnitOfWork db;

        public CategoriesMenu(IUnitOfWork unitOfWork)
        {
            db = unitOfWork;
        }
        //public async Task<IActionResult> InvokeAsync()
        //{ }
        //current-category
        public ViewViewComponentResult Invoke(string currentCategory)
        {
            var products = db.Products.GetAll();
            var categories = products
               .Select(t => t.Category.Name)
               .Distinct()
               .OrderBy(t => t);
            return View(new Tuple<IEnumerable<string>, string>(categories, currentCategory));
        }
    }
}
