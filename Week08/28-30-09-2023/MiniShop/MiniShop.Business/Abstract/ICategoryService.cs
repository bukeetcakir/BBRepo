using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MiniShop.Shared.Dtos;

namespace MiniShop.Business.Abstract
{
    public interface ICategoryService
    {
        ResponseDto<CategoryDto> Create(AddCategoryDto addCategoryDto);
        ResponseDto<List<CategoryDto>> GetAll();
        ResponseDto<CategoryDto> GetById(int id);
        void Update(CategoryDto categoryDto);
        void Delete(int id);
        ResponseDto<CategoryDto> SoftDelete(int id);
    }
}