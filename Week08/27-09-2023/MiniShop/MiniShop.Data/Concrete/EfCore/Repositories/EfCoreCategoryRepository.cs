using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MiniShop.Data.Abstract;
using MiniShop.Data.Concrete.EfCore.Contexts;
using MiniShop.Entity.Concrete;

namespace MiniShop.Data.Concrete.EfCore.Repositories
{
    public class EfCoreCategoryRepository : EfCoreGenericRepository<Category>, ICategoryRepository
    {
        public EfCoreCategoryRepository(MiniShopDbContext _context) : base(_context)
        {

        }
        MiniShopDbContext Context
        {
            get { return _dbContext as MiniShopDbContext; }
        }
        public List<Category> GetCategoriesWithProducts()
        {
            throw new NotImplementedException();
        } 
    }
}