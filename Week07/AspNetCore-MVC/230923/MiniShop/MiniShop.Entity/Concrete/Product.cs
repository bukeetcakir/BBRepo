using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MiniShop.Entity.Abstract;

namespace MiniShop.Entity.Concrete
{
    public class Product : BaseEntity
    {
        public string Properties { get; set; }
        public double Price {get; set;}
        public string ImageURL { get; set; }
        public List<ProductCategory> ProductCategories { get; set; }
    }
}