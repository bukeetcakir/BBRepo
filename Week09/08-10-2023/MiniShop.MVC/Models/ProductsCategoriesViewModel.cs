using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniShop.MVC.Models
{
    public class ProductsCategoriesViewModel
    {
        public List<ProductViewModel> Products { get; set; }
        public List<CategoryViewModel> Categories { get; set; }

    }
}