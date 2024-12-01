using ECommerce_WebApp.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_WebApp.Services
{
    public class CartService : ICartService
    {
        private readonly List<Product> _cartItems = new();

        public Task AddToCartAsync(Product product)
        {
            var existingItem = _cartItems.FirstOrDefault(p => p.ProdId == product.ProdId);
            if (existingItem != null)
            {
                existingItem.SalesCount += 1; // Increment quantity
            }
            else
            {
                product.SalesCount = 1; // Default quantity
                _cartItems.Add(product);
            }
            return Task.CompletedTask;
        }

        public List<Product> GetCartItems()
        {
            return _cartItems;
        }
    }
}
