using ECommerce_WebApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ECommerce_WebApp.Components
{
    public class SideBarViewComponent : ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public SideBarViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await _categoryService.GetAllCategoriesWithSubCategoriesAsync();
            return View(categories);
        }

    }
}
