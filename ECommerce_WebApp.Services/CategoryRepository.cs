using ECommerce_WebApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_WebApp.Services
{
    public class CategoryRepository : ICategoryService
    {
        private DataContext _categoryDbContext;

        public CategoryRepository(DataContext category) 
        {
            _categoryDbContext = category;
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _categoryDbContext.Categories.ToList();
        }

        public IEnumerable<Category> SearchCategoriesByName(string name)
        {
            return _categoryDbContext.Categories.Where(c => c.CategoryName.Contains(name)).ToList();
        }

        public IEnumerable<Product> GetProductsByCategoryName(string categoryName)
        {
            var category = _categoryDbContext.Categories.FirstOrDefault(c => c.CategoryName == categoryName);
            if (category != null)
            {
                return _categoryDbContext.Products.Where(p => p.CategoryId == category.CategoryId).ToList();
            }
            else
            {
                return Enumerable.Empty<Product>();
            }
            
        }
    }
}
