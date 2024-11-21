using ECommerce_WebApp.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerce_WebApp.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task<IEnumerable<Product>> GetProductsByCategoryIdAsync(int categoryId);
        Task<IEnumerable<Product>> SearchProductsByNameAsync(string prodName);
        Task<IEnumerable<Product>> GetProductsByPriceRangeAsync(decimal minPrice, decimal maxPrice);
        Task<IEnumerable<Product>> GetProductsByRatingAsync(int minRating);
        // Additional methods can be added here
    }
}


//public IEnumerable<Product> GetRelatedProducts(int productId)
// GetProductsSortedByPrice
