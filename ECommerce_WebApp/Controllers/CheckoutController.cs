using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ECommerce_WebApp.Entities;
using System.Linq;
using System.Threading.Tasks;
using ECommerce_WebApp.Services;
using ECommerce_WebApp.Operations.Filters;


namespace ECommerce_WebApp.Operations.Controllers
{
    //Made by Keron
    [SessionDataFilter]
    public class CheckoutController : Controller
    {
        private readonly DataContext _context;

        public CheckoutController(DataContext context)
        {
            _context = context;
        }

        // GET: Checkout page with cart items
        [HttpPost]
        public async Task<IActionResult> Index()
        {
            var userId = ViewBag.UserId as string;

            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Login", "Account"); // Redirect if the user is not logged in
            }

            // Get cart items for the current user
            var cartItems = await _context.UserCarts
                .Include(c => c.Product)
                .Where(c => c.UserId == userId)
                .ToListAsync();

            return View("~/Views/Order/Checkout.cshtml", cartItems);
        }

        // POST: Submit the order and store in orderDetails table
        [HttpPost]
        public async Task<IActionResult> SubmitOrder(string name, string shippingAddress, string paymentType)
        {
            var userId = ViewBag.UserId as string;

            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Login", "Account"); // Redirect if the user is not logged in
            }

            // Get cart items for the user
            var cartItems = await _context.UserCarts
                .Include(c => c.Product)
                .Where(c => c.UserId == userId)
                .ToListAsync();

            if (!cartItems.Any())
            {
                return RedirectToAction("Index", "Home"); // Redirect if no items in the cart
            }

            // Add items to the OrderDetails table
            var orderDate = DateTime.Now; // Use order date for grouping
            foreach (var item in cartItems)
            {
                var orderDetail = new OrderDetail
                {
                    UserId = userId,
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    TotalPrice = item.Product.ProdPrice * item.Quantity,
                    OrderDate = orderDate,
                    ShippingAddress = shippingAddress,
                    PaymentType = paymentType,
                    CustomerName = name
                };

                _context.OrderDetails.Add(orderDetail);
            }

            // Remove items from the cart after order placement
            _context.UserCarts.RemoveRange(cartItems);

            await _context.SaveChangesAsync();

            // Redirect to the confirmation page with the specific order date
            return RedirectToAction("OrderConfirmation", new { orderDate = orderDate.ToString("o") });
        }


        // Confirmation page (after placing the order)
        public IActionResult OrderConfirmation(string orderDate)
        {
            var userId = ViewBag.UserId as string;

            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Login", "Account"); // Redirect if the user is not logged in
            }

            // Parse the order date from the query string
            if (!DateTime.TryParse(orderDate, out var parsedOrderDate))
            {
                return RedirectToAction("Index", "Home"); // Redirect if the order date is invalid
            }

            // Get order details for the specific order date
            var orderDetails = _context.OrderDetails
                .Where(o => o.UserId == userId && o.OrderDate == parsedOrderDate)
                .Include(o => o.Product)
                .ToList();

            // Calculate total amount
            var totalAmount = orderDetails.Sum(o => o.TotalPrice);

            // Pass necessary data to the view
            ViewData["OrderDetails"] = orderDetails;
            ViewData["CustomerName"] = orderDetails.FirstOrDefault()?.CustomerName;
            ViewData["ShippingAddress"] = orderDetails.FirstOrDefault()?.ShippingAddress;
            ViewData["PaymentType"] = orderDetails.FirstOrDefault()?.PaymentType;
            ViewData["TotalAmount"] = totalAmount;
            return View("~/Views/Order/OrderConfirmation.cshtml");
        }

    }
}