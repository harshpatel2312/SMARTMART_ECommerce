using ECommerce_WebApp.Entities;
using ECommerce_WebApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

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

        public async Task<IActionResult> ListByCategory(int categoryId, string sortOption)
        {
            var products = await _productService.GetProductsByCategoryIdAsync(categoryId);

            // Applying sorting 
            products = ApplySorting(products, sortOption);

            ViewBag.SortOption = sortOption;
            ViewBag.CategoryId = categoryId;

            return View(products);
        }  
        
        public async Task<IActionResult> Search(string query, string? sortOption)
        {
            var products = await _productService.SearchProductsByNameAsync(query);

            // Applying sorting
            products = ApplySorting(products, sortOption);

            // Pass the search query and current sort option to the view via ViewBag
            ViewBag.SearchQuery = query;
            ViewBag.SortOption = sortOption;

            return View(products);
        }

        private IEnumerable<Product> ApplySorting(IEnumerable<Product> products, string sortOption)
        {
            if (!string.IsNullOrEmpty(sortOption))
            {
                switch (sortOption)
                {
                    case "PriceLowToHigh":
                        return products.OrderBy(p => p.ProdPrice);
                    case "PriceHighToLow":
                        return products.OrderByDescending(p => p.ProdPrice);
                }
            }
            return products;
        }


        [HttpGet]
        public async Task<IActionResult> GetProductSuggestions(string term)
        {
            if (string.IsNullOrWhiteSpace(term))
            {
                return Json(new string[0]);
            }
            var suggestions = await _productService.GetProductsNameAsync(term);
            return Json(suggestions);
        }
    }
}
