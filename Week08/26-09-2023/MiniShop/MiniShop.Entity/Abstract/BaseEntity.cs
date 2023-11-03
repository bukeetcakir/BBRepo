using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniShop.Entity.Abstract
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual bool IsDeleted { get; set; }
        public virtual bool IsActive { get; set; } = true;
        public virtual DateTime CreatedDate { get; set; } = DateTime.Now;
        public virtual DateTime ModifiedDate { get; set; } = DateTime.Now;

    }
}