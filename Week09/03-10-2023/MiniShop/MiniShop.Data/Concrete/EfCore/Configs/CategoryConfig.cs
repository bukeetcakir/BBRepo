using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiniShop.Entity.Concrete;

namespace MiniShop.Data.Concrete.EfCore.Configs
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            // builder.Property(x=>x.Name).HasMaxLength(100);
            builder.HasData(
                new Category
                {
                    Id = 1,
                    CreatedDate = new DateTime(),
                    ModifiedDate = new DateTime(),
                    IsActive = true,
                    IsDeleted = false,
                    Name = "Telefon",
                    Description = "Telefonlar bu kategoride yer alıyor."
                },
                new Category
                {
                    Id = 2,
                    CreatedDate = new DateTime(),
                    ModifiedDate = new DateTime(),
                    IsActive = true,
                    IsDeleted = false,
                    Name = "Bilgisayar",
                    Description = "Bilgisayarlar bu kategoride yer alıyor."
                },
                new Category
                {
                    Id = 3,
                    CreatedDate = new DateTime(),
                    ModifiedDate = new DateTime(),
                    IsActive = true,
                    IsDeleted = false,
                    Name = "Elektronik",
                    Description = "Elektronik ürünler bu kategoride yer alıyor."
                }
            );
        }
    }
}