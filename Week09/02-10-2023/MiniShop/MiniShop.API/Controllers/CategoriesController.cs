using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MiniShop.Business.Abstract;
using MiniShop.Data.Abstract;
using MiniShop.Data.Concrete.EfCore.Contexts;
using MiniShop.Data.Concrete.EfCore.Repositories;
using MiniShop.Entity.Concrete;
using MiniShop.Shared.Dtos;

namespace MiniShop.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryManager;

        public CategoriesController(ICategoryService categoryManager)
        {
            _categoryManager = categoryManager;
        }

        [HttpGet("/categories")]
        public IActionResult GetAll()
        {
            var response = _categoryManager.GetAll();
            var jsonResponse = JsonSerializer.Serialize(response);
            return Ok(jsonResponse);
        }

        [HttpGet("/category/{id}")]
        public IActionResult GetById(int id)
        {
            var response = _categoryManager.GetById(id);
            var jsonResponse = JsonSerializer.Serialize(response);
            return Ok(jsonResponse);
        }
        [HttpPost("/addcategory")]
        public IActionResult Create(AddCategoryDto addCategoryDto)
        {
            var response = _categoryManager.Create(addCategoryDto);
            var jsonResponse = JsonSerializer.Serialize(response);
            return Ok(jsonResponse);
        }
        [HttpDelete("/remove/{id}")]
        public IActionResult Delete(int id)
        {
            _categoryManager.Delete(id);
            return Ok();
        }
        [HttpDelete("/softremove/{id}")]
        public IActionResult SoftDelete(int id)
        {
            var response = _categoryManager.SoftDelete(id);
            var jsonResponse = JsonSerializer.Serialize(response);
            return Ok(jsonResponse);
        }
        [HttpGet("/allcategories")]
        public IActionResult GetAllFilter(bool? isActive, bool? isDeleted)
        {
            var response = _categoryManager.GetAll(isActive, isDeleted);
            var jsonResponse = JsonSerializer.Serialize(response);
            return Ok(jsonResponse);
        }
        [HttpPut("/updatecategory")]
        public IActionResult Update(UpdateCategoryDto updateCategoryDto)
        {
            var response = _categoryManager.Update(updateCategoryDto);
            var jsonResponse = JsonSerializer.Serialize(response);
            return Ok(jsonResponse);
        }
    }
}