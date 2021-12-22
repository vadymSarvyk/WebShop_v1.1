using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Domain.Abstract;
using WebShop.Domain.Models;


namespace WebShop.Domain.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private ShopContext _context;

        public EFUnitOfWork(ShopContext context)
        {
            _context = context;
        }

        private IRepository<Category> categories;

        private IRepository<Photo> photos;

        private IRepository<Product> products;

        private bool disposedValue;

        public IRepository<Category> Categories => categories ??= new CategoryEFRepository(_context);

        public IRepository<Photo> Photos => photos ??= new PhotoEFRepository(_context);

        public IRepository<Product> Products => products ??= new ProductEFRepository(_context);

        public void Save()
        {
            _context.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: освободить управляемое состояние (управляемые объекты)
                    _context.Dispose();
                }

                // TODO: освободить неуправляемые ресурсы (неуправляемые объекты) и переопределить метод завершения
                // TODO: установить значение NULL для больших полей
                disposedValue = true;
            }
        }

        // // TODO: переопределить метод завершения, только если "Dispose(bool disposing)" содержит код для освобождения неуправляемых ресурсов
        // ~EFUnitOfWork()
        // {
        //     // Не изменяйте этот код. Разместите код очистки в методе "Dispose(bool disposing)".
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Не изменяйте этот код. Разместите код очистки в методе "Dispose(bool disposing)".
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
