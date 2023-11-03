using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using MiniShop.MVC.Areas.Admin.Models;
using MiniShop.MVC.Models;

namespace MiniShop.MVC.Data
{
    public static class ProductDAL
    {
        public static async Task<Root<List<ProductViewModel>>> GetAllProducts(int? id = null)
        {
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

        public static async Task<Root<ProductViewModel>> GetProductById(int id)
        {
            Root<ProductViewModel> rootProduct = new Root<ProductViewModel>();
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync($"http://localhost:5200/product/{id}");
                if (response.IsSuccessStatusCode)
                {
                    string contentResponse = await response.Content.ReadAsStringAsync();
                    rootProduct = JsonSerializer.Deserialize<Root<ProductViewModel>>(contentResponse);
                }
                else
                {
                    rootProduct = null;
                }
            }
            return rootProduct;
        }


        public static async Task<Root<ProductViewModel>> CreateProduct(AddProductViewModel product)
        {
            Root<ProductViewModel> rootProduct = new Root<ProductViewModel>();
            using (var httpClient = new HttpClient())
            {
                var serializeProduct = JsonSerializer.Serialize(product);
                StringContent stringContent = new StringContent(serializeProduct, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync("http://localhost:5200/addproduct", stringContent);
                if (response.IsSuccessStatusCode)
                {
                    string contentResponse = await response.Content.ReadAsStringAsync();
                    rootProduct = JsonSerializer.Deserialize<Root<ProductViewModel>>(contentResponse);
                }
                else
                {
                    rootProduct = null;
                }
            }
            return rootProduct;
        }

        public static async Task<Root<ProductViewModel>> UpdateProduct(UpdateProductViewModel product)
        {
            Root<ProductViewModel> rootProduct = new Root<ProductViewModel>();
            using (var httpClient = new HttpClient())
            {
                var serializeProduct = JsonSerializer.Serialize(product);
                StringContent stringContent = new StringContent(serializeProduct, Encoding.UTF8, "application/json");
                var response = await httpClient.PutAsync("http://localhost:5200/updateproduct", stringContent);
                if (response.IsSuccessStatusCode)
                {
                    string contentResponse = await response.Content.ReadAsStringAsync();
                    rootProduct = JsonSerializer.Deserialize<Root<ProductViewModel>>(contentResponse);
                }
                else
                {
                    rootProduct = null;
                }
            }
            return rootProduct;
        }

    }
}