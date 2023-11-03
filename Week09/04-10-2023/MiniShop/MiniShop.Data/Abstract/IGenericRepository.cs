using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniShop.Data.Abstract
{
    public interface IGenericRepository<TEntity>
    {
        TEntity Create(TEntity entity);
        List<TEntity> GetAll();
        TEntity GetById(int id);
        TEntity Update(TEntity entity);
        void Delete(TEntity entity);
    }
}