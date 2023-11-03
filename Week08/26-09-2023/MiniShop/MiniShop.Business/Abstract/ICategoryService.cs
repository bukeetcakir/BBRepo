using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MiniShop.Shared.Dtos;

namespace MiniShop.Business.Abstract
{
    public interface ICategoryService
    {
        void Create(CategoryDto categoryDto);
        List<CategoryDto> GetAll();
        CategoryDto GetById(int id);
        void Update(CategoryDto categoryDto);
        void Delete(CategoryDto categoryDto);
    }
}