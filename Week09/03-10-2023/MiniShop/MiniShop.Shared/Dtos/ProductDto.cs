using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniShop.Shared.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Properties { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }
        public string Note { get; set; }
        public bool IsActive { get; set; }
        public List<CategoryDto> Categories { get; set; }
    }
}