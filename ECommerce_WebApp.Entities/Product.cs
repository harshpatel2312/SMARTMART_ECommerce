using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ECommerce_WebApp.Entities
{
    //Made by Arjun
    public class Product
    {
        [Key]
        public int ProdId { get; set; }

        [Required]
        [MaxLength(100)]
        public string ProdName { get; set; }

        [Required]
        public string ProdDescription { get; set; }

        [Required]
        public decimal ProdPrice { get; set; }

        public string ProdImage { get; set; }

        // Foreign key to the Category table
        public int CategoryId { get; set; }

        // Navigation property to the Category
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        public decimal? ProdRating { get; set; }
        public int SalesCount { get; set; } = 0;

        public bool IsFeatured { get; set; } = false;

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        // Specifications
        public string Brand { get; set; }
        public string Dimensions { get; set; }
        public string Weight { get; set; }
        public string Warranty { get; set; }
    }
}
