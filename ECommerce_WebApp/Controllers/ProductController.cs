using ECommerce_WebApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ECommerce_WebApp.Operations.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<ActionResult> ProductDetails(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product != null)
            {
                return View(product);
            }
            else
            {
                return NotFound();
            }
        }

        public async Task<IActionResult> ListByCategory(int categoryId)
        {
            var products = await _productService.GetProductsByCategoryIdAsync(categoryId);
            return View(products);
        }

        public async Task<IActionResult> Search(string query)
        {
            var products = await _productService.SearchProductsByNameAsync(query);
            return View(products);
        }
    }
}
