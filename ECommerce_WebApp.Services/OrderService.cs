using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce_WebApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerce_WebApp.Services
{
    public class OrderService : IOrderService
    {
        private readonly DataContext _context;

        public OrderService(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<OrderDetail>> GetOrdersByUserAsync(string userId)
        {
            return await _context.OrderDetails
                .Where(o => o.UserId == userId)
                .Include(o => o.Product)
                .ToListAsync();
        }
    }
}
