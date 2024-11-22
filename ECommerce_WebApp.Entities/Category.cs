using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce_WebApp.Entities
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [StringLength(100)]
        public string CategoryName { get; set; }

        // Foreign key referencing the parent category (self-referencing)
        public int? ParentCategoryId { get; set; }

        // Navigation property to access the parent category
        [ForeignKey("ParentCategoryId")]
        public Category ParentCategory { get; set; }

        // Collection of subcategories (self-referencing)
        public ICollection<Category> SubCategories { get; set; } = new List<Category>();

        // Collection of products belonging to this category
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
