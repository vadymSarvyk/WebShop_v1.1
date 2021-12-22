using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Domain.Abstract;
using WebShop.Domain.Models;

namespace WebShop.Domain.Repositories
{
    public class PhotoEFRepository : IRepository<Photo>
    {
        private readonly ShopContext _context;

        public PhotoEFRepository(ShopContext context)
        {
            _context = context;
        }
        public void Add(Photo item)
        {
            _context.Photos.Add(item);
        }

        public void Delete(int id)
        {
            Photo photo = _context.Photos.Find(id);
            _context.Remove(photo);
        }


        public IEnumerable<Photo> Find(Func<Photo, bool> predicate)
        {
            return _context.Photos.Where(predicate);
        }

        public IQueryable<Photo> GetAll()
        {
            return _context.Photos;
        }

        public Photo GetItem(int id)
        {
            return _context.Photos.Find(id);
        }

        public void Update(Photo item)
        {
            _context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
    }
}
