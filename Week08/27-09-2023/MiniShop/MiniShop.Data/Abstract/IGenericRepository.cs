using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniShop.Data.Abstract
{
    public interface IGenericRepository<TEntity>
    {
        //CRUD Create-Read-Update-Delete
        //1-New diyerek yeni nesne yaratılamaz.
        //2-İçerisinde property ya da metot gibi class memberlar bulunabilir. Ancak, metotların erişim belirteci ve gövdesi olmamalıdır!
        void Create(TEntity entity);
        List<TEntity> GetAll();
        TEntity GetById(int id);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}