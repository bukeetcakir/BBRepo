using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniShop.Entity.Concrete
{
    public class ProductCategory
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; } //Navigation property
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}