using Microsoft.AspNetCore.Mvc;
using ECommerce_WebApp.Services;
using System.Threading.Tasks;
using ECommerce_WebApp.Operations.Filters;

namespace ECommerce_WebApp.Controllers
{
    //Made by Keron
    [SessionDataFilter]
    public class OrdersController : Controller
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<IActionResult> Index()
        {
            var userId = ViewBag.UserId as string;

            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Login", "Account"); // Redirect if the user is not logged in
            }

            var orders = await _orderService.GetOrdersByUserAsync(userId);
            return View("~/Views/Order/Index.cshtml",orders);
        }
    }
}
