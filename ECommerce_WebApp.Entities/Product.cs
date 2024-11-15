using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_WebApp.Entities
{
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

        [ForeignKey("CategoryId")]
        public Category ProdCategory { get; set; }
        public decimal? ProdRating { get; set; }

    }
}
