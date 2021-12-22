 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop.Domain.Abstract
{
    public interface IRepository<T> where T: class
    {
        IQueryable<T> GetAll();
        T GetItem(int id);
        void Add(T item);

        void Update(T item);

        void Delete(int id);

        IEnumerable<T> Find(Func<T, bool> predicate);

    }
}
