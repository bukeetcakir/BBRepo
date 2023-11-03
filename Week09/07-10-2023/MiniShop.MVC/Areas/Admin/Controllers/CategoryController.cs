using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MiniShop.MVC.Data;

namespace MiniShop.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var response = await CategoryDAL.GetAllCategories();
            return View(response.Data);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(string Name, string Description)
        {
            var response = await CategoryDAL.CreateCategory(Name, Description);
            return RedirectToAction("Index");
        }
        //Ödev: HardDelete yani veri tabanından kalıcı bir şekilde silme işlemini yapın.
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await CategoryDAL.DeleteCategory(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var response = await CategoryDAL.GetCategoryById(id);
            return !response.Data.IsDeleted ?
                View(response.Data) :
                RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Edit(string Name, string Description, int Id, bool IsActive)
        {
            var response = await CategoryDAL.UpdateCategory(Name, Description, Id, IsActive);
            return RedirectToAction("Index");
        }
    }
}