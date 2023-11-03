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
            var newProduct = _mapper.Map<Product>(updateProductDto);
            if (updateProductDto.CategoryIds.Count() > 0)
            {
                var product = _productRepository.GetProductByIdWithCategories(updateProductDto.Id);
                product.Name = newProduct.Name;
                product.Properties = newProduct.Properties;
                product.Price = newProduct.Price;
                product.IsActive = newProduct.IsActive;
                product.ImageUrl = newProduct.ImageUrl;
                product.Note = newProduct.Note;
                product.ModifiedDate = DateTime.Now;
                product.ProductCategories = updateProductDto
                    .CategoryIds
                    .Select(categoryId => new ProductCategory
                    {
                        ProductId = newProduct.Id,
                        CategoryId = categoryId
                    }).ToList();
                var updatedProduct = _productRepository.Update(product);
                var resultProductDto = _mapper.Map<ProductDto>(_productRepository.GetProductByIdWithCategories(updatedProduct.Id));
                return new ResponseDto<ProductDto>
                {
                    Data = resultProductDto,
                    Error = null
                };
            }
            return new ResponseDto<ProductDto>
            {
                Data = null,
                Error = "En az bir kategori bilgisine ihtiyaç vardır, yeniden deneyiniz."
            };

        }
    }
}