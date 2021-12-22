using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Domain.Abstract;
using WebShop.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace WebShop.Domain.Repositories
{
    public class ProductEFRepository : IRepository<Product>
    {
        private readonly ShopContext _context;

        public ProductEFRepository(ShopContext context)
        {
            _context = context;
        }
        public void Add(Product item)
        {
            _context.Products.Add(item);
        }

        public void Delete(int id)
        {
            Product product = _context.Products.Find(id);
            _context.Products.Remove(product);
        }

        public IEnumerable<Product> Find(Func<Product, bool> predicate)
        {
            return _context.Products.Where(predicate).ToList();
        }

        public IQueryable<Product> GetAll()
        {
            return _context.Products.Include(t => t.Photos).Include(a => a.Category);
        }

        public Product GetItem(int id)
        {
            return _context.Products.Find(id);
        }

        public void Update(Product item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }
    }
}
