using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MiniShop.MVC.Data;
using MiniShop.MVC.Models;

namespace MiniShop.MVC.Controllers
{
    public class CategoryController : Controller
    {
        public async Task<IActionResult> Index(int? id = null)
        {
            var categories = await CategoryDAL.GetAllCategories();
            var products = await ProductDAL.GetAllProducts(id);
            var productsCategories = new ProductsCategoriesViewModel
            {
                Products = products.Data,
                Categories = categories.Data
            };
            if (RouteData.Values["id"] != null)
            {
                ViewData["SelectedCategoryId"] = RouteData.Values["id"];
            }
            return View(productsCategories);
        }
    }
}