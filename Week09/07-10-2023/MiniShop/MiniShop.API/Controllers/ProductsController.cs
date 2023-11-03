using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MiniShop.Business.Abstract;
using MiniShop.Shared.Dtos;

namespace MiniShop.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productManager;

        public ProductsController(IProductService productManager)
        {
            _productManager = productManager;
        }
        [HttpGet("/products")]
        public IActionResult GetAll()
        {
            var response = _productManager.GetAll();
            var jsonResponse = JsonSerializer.Serialize(response);
            return Ok(jsonResponse);
        }
        [HttpGet("/product/{id}")]
        public IActionResult GetById(int id)
        {
            var response = _productManager.GetById(id);
            var jsonResponse = JsonSerializer.Serialize(response);
            return Ok(jsonResponse);
        }
        [HttpGet("/products/{categoryId}")]
        public IActionResult GetProductsByCategoryId(int categoryId)
        {
            var response = _productManager.GetProductsByCategoryId(categoryId);
            var jsonResponse = JsonSerializer.Serialize(response);
            return Ok(jsonResponse);
        }
        [HttpPost("/addproduct")]
        public IActionResult Create(AddProductDto addProductDto)
        {
            var response = _productManager.Create(addProductDto);
            var jsonResponse = JsonSerializer.Serialize(response);
            return Ok(jsonResponse);
        }
        [HttpGet("/allproducts")]
        public IActionResult GetAllFilter(bool? isActive, bool? isDeleted)
        {
            var response = _productManager.GetAll(isActive, isDeleted);
            var jsonResponse = JsonSerializer.Serialize(response);
            return Ok(jsonResponse);
        }
        //Product Update işlemi yapacak bir endpoint hazırlayın.
        //Not: Şimdilik Productların kategorileri ile ilgili güncelleme yapmayacağınızı varsayın.

        [HttpPut("/updateproduct")]
        public IActionResult Update(UpdateProductDto updateProductDto)
        {
            var response = _productManager.Update(updateProductDto);
            var jsonResponse = JsonSerializer.Serialize(response);
            return Ok(jsonResponse);
        }
    }
}