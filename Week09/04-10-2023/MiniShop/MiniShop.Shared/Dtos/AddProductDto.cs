using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniShop.Shared.Dtos
{
    public class AddProductDto
    {
        public string Name { get; set; }
        public string Properties { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }
        public string Note { get; set; }
        public int[] CategoryIds { get; set; }
    }
}