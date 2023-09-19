using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using P01_FirstMVCApp.Models;

namespace P01_FirstMVCApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var result = GetProductList();
            return View(result);
        }

        // http://localhost:5214/product/details/2
        public IActionResult Details(int id)
        {
            
            return View(id);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
        [NonAction]
        private List<Product> GetProductList()
        {
            // List<Product> products = new List<Product>;
            // Product product1 = new Product { Id = 1, Name = "IPhone 14 Pro", Price = 48000 };
            // Product product2 = new Product { Id = 2, Name = "IPhone 15 Pro", Price = 58000 };
            // Product product3 = new Product { Id = 3, Name = "IPhone 16 Pro", Price = 68000 };
            // Product product4 = new Product { Id = 4, Name = "IPhone 17 Pro", Price = 78000 };
            // Product product5 = new Product { Id = 5, Name = "IPhone 18 Pro", Price = 88000 };
            // products.Add(product1);
            // products.Add(product2);
            // products.Add(product3);
            // products.Add(product4);
            // products.Add(product5);
            // return products;

            return new List<Product>{
                new Product { Id = 1, Name = "IPhone 14 Pro", Price = 48000 },
                new Product { Id = 2, Name = "IPhone 15 Pro", Price = 58000 },
                new Product { Id = 3, Name = "IPhone 16 Pro", Price = 68000 },
                new Product { Id = 4, Name = "IPhone 17 Pro", Price = 78000 },
                new Product { Id = 5, Name = "IPhone 18 Pro", Price = 88000 }
            };
        }
    }
}