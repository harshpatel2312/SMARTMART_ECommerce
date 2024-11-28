using ECommerce_WebApp.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_WebApp.Services
{
    public class CategoryRepository : ICategoryService
    {
        private readonly DataContext _categoryDbContext;

        public CategoryRepository(DataContext categoryDbContext)
        {
            _categoryDbContext = categoryDbContext;
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await _categoryDbContext.Categories.ToListAsync();
        }

        public async Task<IEnumerable<Category>> SearchCategoriesByNameAsync(string name)
        {
            return await _categoryDbContext.Categories.Where(c => c.CategoryName.Contains(name)).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByCategoryNameAsync(string categoryName)
        {
            var category = await _categoryDbContext.Categories.FirstOrDefaultAsync(c => c.CategoryName == categoryName);

            if (category != null)
            {
                return await _categoryDbContext.Products.Where(p => p.CategoryId == category.CategoryId).ToListAsync();
            }
            else
            {
                return Enumerable.Empty<Product>();
            }
        }

        public async Task<IEnumerable<Category>> GetSubcategoriesByCategoryIdAsync(int categoryId)
        {
            return await _categoryDbContext.Categories.Where(c => c.ParentCategoryId == categoryId).ToListAsync();
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesWithSubCategoriesAsync()
        {
            return await _categoryDbContext.Categories.Include(c => c.SubCategories).Where(c => c.ParentCategoryId == null).ToListAsync();
        }

    }
}
