using ECommerce_WebApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ECommerce_WebApp.Operations.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;

        public CategoryController(ICategoryService categoryService, IProductService productService)
        {
            _categoryService = categoryService;
            _productService = productService;
        }

        public async Task<ActionResult> GetAllCategories()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            return View(categories);
        }

        // List all subcategories or products in a specific category
        public async Task<IActionResult> CategoryDetails(int id)
        {
            var subcategories = await _categoryService.GetSubcategoriesByCategoryIdAsync(id);

            if (subcategories.Any())
            {
                return View("", subcategories);
            }
            else
            {
                var products = await _productService.GetProductsByCategoryIdAsync(id);
                return View("", products);
            }
        }
    }
}
