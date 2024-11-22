using ECommerce_WebApp.Models;
using ECommerce_WebApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ECommerce_WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public HomeController(
            ILogger<HomeController> logger,
            ICategoryService categoryService,
            IProductService productService)
        {
            _logger = logger;
            _productService = productService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Categories = await _categoryService.GetAllCategoriesAsync();
            return View();
        }

        public async Task<IActionResult> SearchProduct(string query)
        {
            var products = await _productService.SearchProductsByNameAsync(query);
            return View(products);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
    }
}
