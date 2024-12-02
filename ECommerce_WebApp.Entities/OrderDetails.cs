using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Made by Keron
namespace ECommerce_WebApp.Entities
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public string UserId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public string ShippingAddress { get; set; }
        public string PaymentType { get; set; }
        public string CustomerName { get; set; }

        // Navigation properties
        public virtual Product Product { get; set; }
    }
}