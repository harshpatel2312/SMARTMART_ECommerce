using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ECommerce_WebApp.Entities
{
    //Made by Keron
    public class UserCart
    {
        [Key]
        public int CartId { get; set; }

        [Required]
        public string UserId { get; set; } // To associate a cart with a user

        [Required]
        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        [Required]
        public int Quantity { get; set; }

        public DateTime AddedDate { get; set; } = DateTime.UtcNow;
    }
}
