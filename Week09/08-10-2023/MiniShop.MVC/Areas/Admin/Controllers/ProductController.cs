using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MiniShop.MVC.Areas.Admin.Models;
using MiniShop.MVC.Data;

namespace MiniShop.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var response = await ProductDAL.GetAllProducts();
            return View(response.Data);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var categories = await CategoryDAL.GetAllCategories();
            var model = new AddProductViewModel
            {
                CategoryIds = new List<int>(),
                Categories = categories.Data
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Create(AddProductViewModel product, IFormFile image)
        {
            if (ModelState.IsValid)
            {
                var response = await ProductDAL.CreateProduct(product);
                return RedirectToAction("Index");
            }
            var categories = await CategoryDAL.GetAllCategories();
            product.Categories = categories.Data;
            product.CategoryIds = product.CategoryIds ?? new List<int>();
            return View(product);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var response = await ProductDAL.GetProductById(id);
            var categories = await CategoryDAL.GetAllCategories();
            var editProduct = new UpdateProductViewModel
            {
                Id = response.Data.Id,
                Name = response.Data.Name,
                Properties = response.Data.Properties,
                Price = response.Data.Price,
                IsActive = response.Data.IsActive,
                ImageUrl = response.Data.ImageUrl,
                Note = response.Data.Note,
                Categories = categories.Data,
                CategoryIds = response.Data.Categories.Select(c => c.Id).ToList()
            };

            return View(editProduct);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateProductViewModel product)
        {
            var response = await ProductDAL.UpdateProduct(product);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateIsActive(int id)
        {
            var response = await ProductDAL.GetProductById(id);
            response.Data.IsActive = !response.Data.IsActive;
            var editProduct = new UpdateProductViewModel
            {
                Id = response.Data.Id,
                Name = response.Data.Name,
                Properties = response.Data.Properties,
                Price = response.Data.Price,
                IsActive = response.Data.IsActive,
                ImageUrl = response.Data.ImageUrl,
                Note = response.Data.Note,
                CategoryIds = response.Data.Categories.Select(c => c.Id).ToList()
            };
            await ProductDAL.UpdateProduct(editProduct);
            return RedirectToAction("Index");
        }
    }
}