using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MiniShop.Data.Concrete.EfCore.Configs;
using MiniShop.Entity.Concrete;

namespace MiniShop.Data.Concrete.EfCore.Contexts
{
    public class MiniShopDbContext : DbContext
    {
        public MiniShopDbContext(DbContextOptions options):base(options)
        {
            
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Eyyyy EF Core! Git bu uygulamadaki configuration dosyalarını işle!
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CategoryConfig).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}