using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiniShop.Entity.Concrete;

namespace MiniShop.Data.Concrete.EfCore.Configs
{
    public class ProductCategoryConfig : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.HasKey(x => new { x.ProductId, x.CategoryId });
            builder.HasData(
                new ProductCategory { ProductId = 1, CategoryId = 1 },
                new ProductCategory { ProductId = 1, CategoryId = 3 },

                new ProductCategory { ProductId = 2, CategoryId = 1 },
                new ProductCategory { ProductId = 2, CategoryId = 3 },

                new ProductCategory { ProductId = 3, CategoryId = 2 },
                new ProductCategory { ProductId = 3, CategoryId = 3 },

                new ProductCategory { ProductId = 4, CategoryId = 2 },
                new ProductCategory { ProductId = 4, CategoryId = 3 },

                new ProductCategory { ProductId = 5, CategoryId = 3 },

                new ProductCategory { ProductId = 6, CategoryId = 3 }
            );
        }
    }
}