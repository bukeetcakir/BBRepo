using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MiniShop.Data.Abstract;
using MiniShop.Data.Concrete.EfCore.Contexts;
using MiniShop.Entity.Concrete;

namespace MiniShop.Data.Concrete.EfCore.Repositories
{
    public class EfCoreProductRepository : EfCoreGenericRepository<Product>, IProductRepository
    {
        public EfCoreProductRepository(MiniShopDbContext _context) : base(_context)
        {

        }
        MiniShopDbContext Context
        {
            get { return _dbContext as MiniShopDbContext; }
        }

        public Product GetProductByIdWithCategories(int id)
        {
            var product = Context
                .Products
                .Where(p => p.Id == id)
                .Include(p => p.ProductCategories)
                .ThenInclude(pc => pc.Category)
                .FirstOrDefault();
            return product;
        }

        public List<Product> GetProductsByCategoryId(int categoryId)
        {
            var products = Context
                .Products
                .Include(p => p.ProductCategories)
                .ThenInclude(pc => pc.Category)
                .Where(p => p.ProductCategories.Any(pc => pc.CategoryId == categoryId))
                .ToList();
            return products;
        }

        public List<Product> GetProductsWithCategories()
        {
            var products = Context
                .Products
                .Include(p => p.ProductCategories)
                .ThenInclude(pc => pc.Category)
                .ToList();
            return products;
        }

        public void SaveProductCategories(int productId, int[] categoryIds)
        {
            //productId=9
            //categoryIds = [3,6,8]
            List<ProductCategory> productCategories = categoryIds.Select(x => new ProductCategory
            {
                ProductId = productId,
                CategoryId = x
            }).ToList();
            /* 9-3
            *  9-6
            *  9-8
            */
            _dbContext.AddRange(productCategories);
            _dbContext.SaveChanges();
        }
    }
}

