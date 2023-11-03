using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiniShop.Entity.Concrete;

namespace MiniShop.Data.Concrete.EfCore.Configs
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {

            builder.HasData(
                new Product
                {
                    Id = 1,
                    CreatedDate = new DateTime(),
                    ModifiedDate = new DateTime(),
                    IsActive = true,
                    IsDeleted = false,
                    Name = "Iphone 13 Pro",
                    Properties = "Harika bir telefon",
                    Price = 39000,
                    ImageUrl = "iphone-13.png",
                    Note = ""
                },
                new Product
                {
                    Id = 2,
                    CreatedDate = new DateTime(),
                    ModifiedDate = new DateTime(),
                    IsActive = true,
                    IsDeleted = false,
                    Name = "Iphone 14 Pro",
                    Properties = "Harika bir telefon",
                    Price = 59000,
                    ImageUrl = "iphone-14.png",
                    Note = ""
                },
                new Product
                {
                    Id = 3,
                    CreatedDate = new DateTime(),
                    ModifiedDate = new DateTime(),
                    IsActive = true,
                    IsDeleted = false,
                    Name = "HP Pavilion XYZ13",
                    Properties = "Uygulama geliştiriciler için harika bir cihaz",
                    Price = 19500,
                    ImageUrl = "hppavilion.png",
                    Note = ""
                },
                new Product
                {
                    Id = 4,
                    CreatedDate = new DateTime(),
                    ModifiedDate = new DateTime(),
                    IsActive = true,
                    IsDeleted = false,
                    Name = "Macbook Air M2",
                    Properties = "Gerçek performans",
                    Price = 35500,
                    ImageUrl = "macbook.png",
                    Note = ""
                },
                new Product
                {
                    Id = 5,
                    CreatedDate = new DateTime(),
                    ModifiedDate = new DateTime(),
                    IsActive = true,
                    IsDeleted = false,
                    Name = "Vestel Çamaşır Makinesi X16",
                    Properties = "Son teknoloji hijyen",
                    Price = 14900,
                    ImageUrl = "vestel-camasir-makinesi.png",
                    Note = ""
                },
                new Product
                {
                    Id = 6,
                    CreatedDate = new DateTime(),
                    ModifiedDate = new DateTime(),
                    IsActive = true,
                    IsDeleted = false,
                    Name = "Ipod Nano",
                    Properties = "Seste mucize",
                    Price = 128000,
                    ImageUrl = "ipod-nano.png",
                    Note = ""
                }
            );
        }
    }
}