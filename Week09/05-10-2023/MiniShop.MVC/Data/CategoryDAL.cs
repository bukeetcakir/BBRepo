using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using MiniShop.MVC.Models;

namespace MiniShop.MVC.Data
{
    public static class CategoryDAL
    {
        public static async Task<Root<List<CategoryViewModel>>> GetAllCategories()
        {
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
            return rootCategories;
        }
    }
}