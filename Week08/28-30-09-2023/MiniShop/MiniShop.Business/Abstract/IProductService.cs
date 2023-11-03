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
        void Update(ProductDto productDto);
        void Delete(ProductDto productDto);
        ResponseDto<ProductDto> GetById(int id);
        ResponseDto<List<ProductDto>> GetAll();
        ResponseDto<List<ProductDto>> GetProductsByCategoryId(int categoryId);
    }
}