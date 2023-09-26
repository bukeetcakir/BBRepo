using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MiniShop.Entity.Concrete;

namespace MiniShop.Data.Concrete.EFCore.Context
{
    public class MiniShopDBContext:DbContext
    {
        public MiniShopDBContext(DbContextOptions options ):base(options)
        {
            
        }
        public DbSet<Category> Categories {get; set;}
        public DbSet<Product> Products {get; set;}
        public DbSet<ProductCategory> ProductCategories {get; set;}
        
    }
}