using ECommerce_WebApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_WebApp.Services
{
    public class ProductRepository : IProductService
    {
        private DataContext _prodDbContext;
        public ProductRepository(DataContext context) 
        {
            _prodDbContext = context;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _prodDbContext.Products.ToList();
        }
        public IEnumerable<Product> SearchProductsByName(string prodName)
        {
            if (string.IsNullOrWhiteSpace(prodName))
            {
                return Enumerable.Empty<Product>();
            }
            var keywords = prodName.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var query = _prodDbContext.Products.AsQueryable();

            foreach (var keyword in keywords)
            {
                query = query.Where(p => p.ProdName.Contains(keyword, StringComparison.OrdinalIgnoreCase));
            }
            
            return query.ToList();
        }

        public IEnumerable<Product> GetProductsByPriceRange(decimal minPrice, decimal maxPrice)
        {
            return _prodDbContext.Products.Where(p => p.ProdPrice >= minPrice &&  p.ProdPrice <= maxPrice).ToList();
        }
        public IEnumerable<Product> GetProductsByRating(int minRating)
        {
            return _prodDbContext.Products.Where(p => p.ProdRating >= minRating).ToList();
        }
    }
}
