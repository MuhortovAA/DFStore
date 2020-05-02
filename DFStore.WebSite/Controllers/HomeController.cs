using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DFStore.WebSite.Models;
using DFStore.WebSite.Services;

namespace DFStore.WebSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public JsonFileProductService ProductService;
        public IEnumerable<Product> Products { get; private set; }
        public HomeController(ILogger<HomeController> logger, JsonFileProductService productService)
        {
            _logger = logger;
            ProductService = productService;
        }

        public ViewResult Index()
        {
            Products = ProductService.GetProducts();
            return View(Products);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public void OnGet()
        {
            Products = ProductService.GetProducts();
        }
    }
}
