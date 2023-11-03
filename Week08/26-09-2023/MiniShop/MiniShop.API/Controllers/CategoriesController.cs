using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MiniShop.Data.Abstract;
using MiniShop.Data.Concrete.EfCore.Contexts;
using MiniShop.Data.Concrete.EfCore.Repositories;
using MiniShop.Entity.Concrete;
using MiniShop.Shared.Dtos;

namespace MiniShop.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet("/categories")]
        public IActionResult GetAll()
        {
            List<Category> categories = _categoryRepository.GetAll();
            #region WithForeach
            // CategoryDto categoryDto;
            // List<CategoryDto> categoryDtos = new List<CategoryDto>();
            // foreach (var category in categories)
            // {
            //     categoryDto = new CategoryDto();
            //     categoryDto.Id = category.Id;
            //     categoryDto.Name = category.Name;
            //     categoryDto.Description = category.Description;
            //     categoryDtos.Add(categoryDto);
            // }
            #endregion
            List<CategoryDto> categoryDtos = categories.
                Select(x => new CategoryDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description
                }).ToList();
            var jsonResult = JsonSerializer.Serialize(categoryDtos);
            return Ok(jsonResult);
        }

        [HttpGet("/getcategory/{id}")]
        public IActionResult GetById(int id)
        {
            var category = _categoryRepository.GetById(id);
            if (category == null)
            {
                // return NotFound();
                var errorDto = new ErrorDto{
                    StatusCode=201,
                    ErrorMessage=$"Id'si {id} olan kategori bulunamadı"
                };
                var errorJsonResult = JsonSerializer.Serialize(errorDto);
                return NotFound(errorJsonResult);
            }
            var categoryDto = new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description
            };
            var jsonResult = JsonSerializer.Serialize(categoryDto);
            return Ok(jsonResult);
        }
    }
}