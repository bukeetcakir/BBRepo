using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
            Root<List<CategoryViewModel>> rootCategories = new Root<List<CategoryViewModel>>();
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync("http://localhost:5200/categories");
                if (response.IsSuccessStatusCode)
                {
                    string contentResponse = await response.Content.ReadAsStringAsync();
                    rootCategories = JsonSerializer.Deserialize<Root<List<CategoryViewModel>>>(contentResponse);
                }
                else
                {
                    rootCategories = null;
                }
            }
            return View(rootCategories.Data);
        }
    }
}