using ECommerce_WebApp.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_WebApp.Services
{
    public class ProductRepository : IProductService
    {
        private readonly DataContext _prodDbContext;

        public ProductRepository(DataContext context)
        {
            _prodDbContext = context;
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _prodDbContext.Products.FirstOrDefaultAsync(p => p.ProdId == id);
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _prodDbContext.Products.ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByCategoryIdAsync(int categoryId)
        {
            return await _prodDbContext.Products.Where(p => p.CategoryId == categoryId).ToListAsync();
        }

        public async Task<IEnumerable<Product>> SearchProductsByNameAsync(string prodName)
        {
            if (string.IsNullOrWhiteSpace(prodName))
            {
                return Enumerable.Empty<Product>();
            }

            var keywords = prodName.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var query = _prodDbContext.Products.AsQueryable();

            foreach (var keyword in keywords)
            {
                query = query.Where(p => EF.Functions.Like(p.ProdName, $"%{keyword}%"));
            }

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByPriceRangeAsync(decimal minPrice, decimal maxPrice)
        {
            return await _prodDbContext.Products.Where(p => p.ProdPrice >= minPrice && p.ProdPrice <= maxPrice).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByRatingAsync(int minRating)
        {
            return await _prodDbContext.Products.Where(p => p.ProdRating >= minRating).ToListAsync();
        }
    }
}
