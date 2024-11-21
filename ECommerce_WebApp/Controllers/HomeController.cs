using ECommerce_WebApp.Models;
using ECommerce_WebApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ECommerce_WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService; 
        public HomeController(ILogger<HomeController> logger, ICategoryService categoryService, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            ViewBag.Categories = _categoryService.GetAllCategories();
            return View();
        }

        public IActionResult SearchProduct(string query)
        {
            var products = _productService.SearchProductsByName(query);
            return View(products);
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
    }
}
