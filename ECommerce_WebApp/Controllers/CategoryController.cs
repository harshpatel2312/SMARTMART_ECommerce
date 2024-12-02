using ECommerce_WebApp.Operations.Filters;
using ECommerce_WebApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;


namespace ECommerce_WebApp.Operations.Controllers
{
    //Made by Arjun
    [SessionDataFilter]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly DataContext _dataContext;

        public CategoryController(DataContext datacontext, ICategoryService categoryService, IProductService productService)
        {
            _categoryService = categoryService;
            _productService = productService;
            _dataContext = datacontext;
        }

        public async Task<ActionResult> GetAllCategories()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            return View(categories);
        }

       

    }
}
