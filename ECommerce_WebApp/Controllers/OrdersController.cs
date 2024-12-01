using Microsoft.AspNetCore.Mvc;
using ECommerce_WebApp.Services;
using System.Threading.Tasks;

namespace ECommerce_WebApp.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<IActionResult> Index()
        {
            var orders = await _orderService.GetOrdersByUserAsync("testUser");
            return View("~/Views/Order/Index.cshtml",orders);
        }
    }
}
