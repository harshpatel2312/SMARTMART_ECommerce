using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_WebApp.Entities
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [StringLength(100)]
        public string CategoryName { get; set; }

        // Foreign key referencing the parent id (Self referencing for each category to be linked to it's parent)
        public int? ParentCategoryId { get; set; }

        // Navigation Property to access details of the Parent
        [ForeignKey("ParentCategoryId")]
        public Category ParentCategory { get; set; }

        // Collection of SubCategory - self referencing
        public ICollection<Category> SubCategoryCollection { get; set; }

        // Collection of Products belonging to this Category
        public ICollection<Product> ProductCollection { get; set; }
    }
}
