using ECommerce_WebApp.Entities;

namespace ECommerce_WebApp.Operations.Models
{
    public class HomeViewModel
    {
        public IEnumerable<Category> FeaturedCategories { get; set; }
        public IEnumerable<Product> FeaturedProducts { get; set; }
        public IEnumerable<Product> BestSellers { get; set; }
        public IEnumerable<Product> Recommendations { get; set; }
    }
}
