using ECommerce_WebApp.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerce_WebApp.Services
{
    //Made by Arjun
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task<IEnumerable<Product>> GetProductsByCategoryIdAsync(int categoryId);
        Task<IEnumerable<Product>> SearchProductsByNameAsync(string prodName);
        //Task<IEnumerable<Product>> GetProductsByPriceRangeAsync(decimal minPrice, decimal maxPrice);
        //Task<IEnumerable<Product>> GetProductsByRatingAsync(int minRating);
        Task<IEnumerable<Product>> GetFeaturedProductsAsync();
        Task<IEnumerable<Product>> GetBestSellersAsync();
        Task<IEnumerable<Product>> GetRecommendationsAsync(string username);
        // Below method is functionality for implementing dynamic search suggestion 
        Task<IEnumerable<string>> GetProductsNameAsync(string searchTerm);
    }
}
