using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Domain.Models;
using WebShop.Domain.Abstract;
using Microsoft.EntityFrameworkCore;

namespace WebShop.Domain.Repositories
{
    public class CategoryEFRepository : IRepository<Category>
    {
        private readonly ShopContext _context;
        public CategoryEFRepository(ShopContext context)
        {
            _context = context;
        }

        public void Add(Category item)
        {
            _context.Categories.Add(item);
        }

        public void Delete(int id)
        {
            Category category =  _context.Categories.Find(id);
            _context.Remove(category);
        }

        public IEnumerable<Category> Find(Func<Category, bool> predicate)
        {
            return _context.Categories.Where(predicate).ToList();
        }

        public IQueryable<Category> GetAll()
        {
            return _context.Categories.Include(t=>t.Products);
        }

        public Category GetItem(int id)
        {
            return _context.Categories.Find(id);
        }

        public void Update(Category item)
        {
            _context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
    }
}
