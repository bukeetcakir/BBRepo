using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MiniShop.Shared.Dtos
{
    public class AddCategoryDto
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }
}