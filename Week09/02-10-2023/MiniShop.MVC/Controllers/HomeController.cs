using System.Diagnostics;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using MiniShop.MVC.Models;

namespace MiniShop.MVC.Controllers;

public class HomeController : Controller
{
    public async Task<IActionResult> Index(int? id = null)
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
        return View(rootProducts.Data);
    }
}
