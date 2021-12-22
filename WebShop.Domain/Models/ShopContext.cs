using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebShop.Domain.Models
{
    public class ShopContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Photo> Photos { get; set; }

        public DbSet<Product> Products { get; set; }

        public ShopContext(DbContextOptions<ShopContext> options): base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Телефоны"},
                new Category { Id = 2, Name = "Телевизоры"},
                new Category { Id = 3, Name = "Ноутбуки"}
                );
            builder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Redmi Note 10 Pro", Price = 8999, CategoryId = 1 },
                new Product { Id = 2, Name = "POCO X3", Price = 6999, CategoryId = 1 },
                new Product { Id = 3, Name = "HP ProBook 5623S", Price = 18999, CategoryId = 3 },
                new Product { Id = 4, Name = "Xiaomi MiTV 40M", Price = 7999, CategoryId = 2 }
                );
        }
    }
}
