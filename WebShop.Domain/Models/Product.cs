using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop.Domain.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public Category  Category { get; set; }

        public ICollection<Photo> Photos { get; set; }

        public Product()
        {
            Photos = new HashSet<Photo>();
        }
    }
}
