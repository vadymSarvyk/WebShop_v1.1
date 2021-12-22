using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Domain.Models;

namespace WebShop.Domain.Abstract
{
    public interface IUnitOfWork: IDisposable
    {
        IRepository<Category> Categories { get;  }
        IRepository<Photo> Photos { get;  }
        IRepository<Product> Products { get;  }

        void Save();

        Task SaveAsync();
    }
}
