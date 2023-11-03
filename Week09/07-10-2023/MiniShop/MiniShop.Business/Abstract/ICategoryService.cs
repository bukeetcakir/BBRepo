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
        ResponseDto<List<CategoryDto>> GetAll(bool? isActive, bool? isDeleted);
        ResponseDto<CategoryDto> GetById(int id);
        ResponseDto<CategoryDto> Update(UpdateCategoryDto updateCategoryDto);
        void Delete(int id);
        ResponseDto<CategoryDto> SoftDelete(int id);

    }
}