using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MiniShop.Shared.Dtos;

namespace MiniShop.Business.Abstract
{
    public interface IProductService
    {
        ResponseDto<ProductDto> Create(AddProductDto addProductDto);
        ResponseDto<ProductDto> Update(UpdateProductDto updateProductDto);
        void Delete(ProductDto productDto);
        ResponseDto<ProductDto> GetById(int id);
        ResponseDto<List<ProductDto>> GetAll();
        ResponseDto<List<ProductDto>> GetAll(bool? isActive, bool? isDeleted);
        ResponseDto<List<ProductDto>> GetProductsByCategoryId(int categoryId);
    }
}