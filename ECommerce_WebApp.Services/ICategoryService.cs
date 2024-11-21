using ECommerce_WebApp.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerce_WebApp.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
        Task<IEnumerable<Category>> SearchCategoriesByNameAsync(string name);
        Task<IEnumerable<Product>> GetProductsByCategoryNameAsync(string categoryName);
        Task<IEnumerable<Category>> GetSubcategoriesByCategoryIdAsync(int categoryId);
    }
}
