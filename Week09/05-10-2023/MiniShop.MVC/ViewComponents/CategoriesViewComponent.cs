using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MiniShop.MVC.Data;
using MiniShop.MVC.Models;

namespace MiniShop.MVC.ViewComponents
{
    public class CategoriesViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            if (RouteData.Values["id"] != null)
            {
                ViewData["SelectedCategoryId"] = RouteData.Values["id"];
                // ViewBag.SelectedCategoryId = RouteData.Values["id"];
            }
            var categories = await CategoryDAL.GetAllCategories();
            return View(categories.Data);
        }
    }
}