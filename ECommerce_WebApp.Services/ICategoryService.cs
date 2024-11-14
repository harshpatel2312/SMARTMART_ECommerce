using ECommerce_WebApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_WebApp.Services
{
    public interface ICategoryService
    {
        Category GetCategoryById(int id);
        IEnumerable<Category> GetAllCategories();
        IEnumerable<Product> GetProductByCategoryId(int categoryId);
    }
}
