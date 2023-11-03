using System.Diagnostics;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using MiniShop.MVC.Models;

namespace MiniShop.MVC.Controllers;

public class HomeController : Controller
{
    public async Task<IActionResult> Index()
    {
        Root<ProductViewModel> root = new Root<ProductViewModel>();
        using (var httpClient = new HttpClient())
        {
            var response = await httpClient.GetAsync("http://localhost:5200/product/1");
            if (response.IsSuccessStatusCode)
            {
                string contentResponse = await response.Content.ReadAsStringAsync();
                root = JsonSerializer.Deserialize<Root<ProductViewModel>>(contentResponse);
            }
            else
            {
                root = null;
            }
        }
        if (root != null)
        {
            return View(root.Data);
        }
        return View();

    }
}
