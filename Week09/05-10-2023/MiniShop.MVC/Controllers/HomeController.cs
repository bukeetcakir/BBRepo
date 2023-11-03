using System.Diagnostics;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using MiniShop.MVC.Data;
using MiniShop.MVC.Models;

namespace MiniShop.MVC.Controllers;

public class HomeController : Controller
{
    public async Task<IActionResult> Index(int? id = null)
    {
        //Productları getirecek metod. Bu metodu çağırırken id'yi yollayacağız
        var products = await ProductDAL.GetAllProducts(id);
        return View(products.Data);
    }
}
