using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebShop.Domain.Models
{
    public class Photo
    {
        public int Id { get; set; }

        public string Filename { get; set; }

        public string ContentType { get; set; }

        public byte[] ImageData { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }

        public Product Product { get; set; }
    }
}
