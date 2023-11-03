using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MiniShop.Entity.Concrete;

namespace MiniShop.Data.Abstract
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        List<Product> GetProductsByCategoryId(int categoryId);
        List<Product> GetProductsWithCategories();
        Product GetProductByIdWithCategories(int id);
        void SaveProductCategories(int productId, int[] categoryIds);
        List<Product> GetActiveAndUndeletedProducts(bool? isActive, bool? isDeleted);
    }
}