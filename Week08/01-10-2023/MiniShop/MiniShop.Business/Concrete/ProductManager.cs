using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MiniShop.Business.Abstract;
using MiniShop.Data.Abstract;
using MiniShop.Entity.Concrete;
using MiniShop.Shared.Dtos;

namespace MiniShop.Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductManager(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public ResponseDto<ProductDto> Create(AddProductDto addProductDto)
        {
            var addedProduct = _mapper.Map<Product>(addProductDto);
            addedProduct.CreatedDate = DateTime.Now;
            addedProduct.ModifiedDate = DateTime.Now;
            addedProduct.IsDeleted = false;
            var resultProduct = _productRepository.Create(addedProduct);
            _productRepository.SaveProductCategories(resultProduct.Id, addProductDto.CategoryIds);
            var responseProduct = _productRepository.GetProductByIdWithCategories(resultProduct.Id);
            return new ResponseDto<ProductDto>
            {
                Data = _mapper.Map<ProductDto>(responseProduct),
                Error = null
            };
        }

        public void Delete(ProductDto productDto)
        {
            throw new NotImplementedException();
        }

        public ResponseDto<List<ProductDto>> GetAll()
        {
            var products = _productRepository.GetProductsWithCategories();
            if (products.Count == 0)
            {
                return new ResponseDto<List<ProductDto>>
                {
                    Data = null,
                    Error = "Herhangi bir ürün bulunamadı."
                };
            }
            return new ResponseDto<List<ProductDto>>
            {
                Data = _mapper.Map<List<ProductDto>>(products),
                Error = null
            };
        }

        public ResponseDto<List<ProductDto>> GetAll(bool? isActive, bool? isDeleted)
        {
            var products = _productRepository.GetActiveAndUndeletedProducts(isActive, isDeleted);
            if (products.Count == 0)
            {
                return new ResponseDto<List<ProductDto>>
                {
                    Data = null,
                    Error = "Herhangi bir ürün bulunamadı."
                };
            }
            return new ResponseDto<List<ProductDto>>
            {
                Data = _mapper.Map<List<ProductDto>>(products),
                Error = null
            };
        }

        public ResponseDto<ProductDto> GetById(int id)
        {
            var product = _productRepository.GetProductByIdWithCategories(id);
            if (product == null)
            {
                return new ResponseDto<ProductDto>
                {
                    Data = null,
                    Error = "Aradığınız ürün bulunamadı."
                };
            }
            return new ResponseDto<ProductDto>
            {
                Data = _mapper.Map<ProductDto>(product),
                Error = null
            };
        }

        public ResponseDto<List<ProductDto>> GetProductsByCategoryId(int categoryId)
        {
            var products = _productRepository.GetProductsByCategoryId(categoryId);
            if (products.Count == 0)
            {
                return new ResponseDto<List<ProductDto>>
                {
                    Data = null,
                    Error = "Bu kategoride ürün bulunamamıştır."
                };
            }
            return new ResponseDto<List<ProductDto>>
            {
                Data = _mapper.Map<List<ProductDto>>(products),
                Error = null
            };

        }


        public ResponseDto<ProductDto> Update(UpdateProductDto updateProductDto)
        {
            var updatedProduct = _mapper.Map<Product>(updateProductDto);
            updatedProduct.ModifiedDate = DateTime.Now;
            var resultProduct = _productRepository.Update(updatedProduct);
            return new ResponseDto<ProductDto>
            {
                Data = _mapper.Map<ProductDto>(resultProduct),
                Error = null
            };
        }
    }
}