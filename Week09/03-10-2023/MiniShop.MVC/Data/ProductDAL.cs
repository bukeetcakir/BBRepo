using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using MiniShop.MVC.Models;

namespace MiniShop.MVC.Data
{
    public static class ProductDAL
    {
        public static async Task<Root<List<ProductViewModel>>> GetAllProducts(int? id=null){
            Root<List<ProductViewModel>> rootProducts = new Root<List<ProductViewModel>>();
            using (var httpClient = new HttpClient())
            {
                var response = id == null ?
                    await httpClient.GetAsync("http://localhost:5200/products") :
                    await httpClient.GetAsync($"http://localhost:5200/products/{id}");
                if (response.IsSuccessStatusCode)
                {
                    string contentResponse = await response.Content.ReadAsStringAsync();
                    rootProducts = JsonSerializer.Deserialize<Root<List<ProductViewModel>>>(contentResponse);
                }
                else
                {
                    rootProducts = null;
                }
            }
            return rootProducts;
        }
    }
}