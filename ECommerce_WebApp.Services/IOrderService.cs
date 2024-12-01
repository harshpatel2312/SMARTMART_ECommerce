using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerce_WebApp.Entities;

namespace ECommerce_WebApp.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderDetail>> GetOrdersByUserAsync(string UserId);
    }
}
