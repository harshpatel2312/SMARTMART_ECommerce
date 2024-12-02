using System.Linq;
using System.Threading.Tasks;
using ECommerce_WebApp.Entities;
using ECommerce_WebApp.Operations;
using ECommerce_WebApp.Operations.Filters;
using ECommerce_WebApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace ECommerce_WebApp.Operations.Controllers
{
    [SessionDataFilter]
    public class CartController : Controller
    {
        private readonly DataContext _context;

        public CartController(DataContext context)
        {
            _context = context;
        }

        // Original AddToCart method
        [HttpPost]
        public async Task<IActionResult> AddToCart(int productId, int quantity = 1)
        {
            // Temporary hardcoded user ID for testing
            //var userId = User.Identity?.Name ?? "testUser";
            var userId = ViewBag.UserId as string;

            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Login", "Account"); // Redirect if the user is not logged in
            }

            var existingCartItem = await _context.UserCarts
                .FirstOrDefaultAsync(c => c.UserId == userId && c.ProductId == productId);

            if (existingCartItem != null)
            {
                // If item exists, just increase the quantity
                existingCartItem.Quantity += quantity;
            }
            else
            {
                // Add new cart item
                var cartItem = new UserCart
                {
                    UserId = userId,
                    ProductId = productId,
                    Quantity = quantity,
                    AddedDate = DateTime.Now  // Storing the time when the product was added
                };
                _context.UserCarts.Add(cartItem);
            }

            // Save changes to the database
            await _context.SaveChangesAsync();

            // Redirect to ViewCart to show updated cart
            return RedirectToAction("ViewCart");
        }


        // Method to manually add a test cart item for testing
        [HttpPost]
        public async Task<IActionResult> AddTestCartItem()
        {
            // UserId retrieved from session
            var userId = ViewBag.UserId; 

            var productId = 1;

            var testCartItem = new UserCart
            {
                UserId = userId,
                ProductId = productId, 
                Quantity = 2,
                AddedDate = DateTime.Now  
            };

            _context.UserCarts.Add(testCartItem);
            await _context.SaveChangesAsync();

            return RedirectToAction("ViewCart");
        }

        // ViewCart method to display cart items
        [HttpGet]
        public async Task<IActionResult> ViewCart()
        {
            var userId = ViewBag.UserId as string;

            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Login", "Account"); // Redirect if the user is not logged in
            }

            var cartItems = await _context.UserCarts
                .Include(c => c.Product)
                .Where(c => c.UserId == userId)
                .ToListAsync();

            return View("~/Views/Order/ViewCart.cshtml", cartItems);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCart(int cartId, int quantityToRemove)
        {
            var userId = ViewBag.UserId as string;

            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Login", "Account"); // Redirect if the user is not logged in
            }

            var cartItem = await _context.UserCarts
                .FirstOrDefaultAsync(c => c.UserId == userId && c.CartId == cartId);

            if (cartItem != null)
            {
                if (cartItem.Quantity > quantityToRemove)
                {
                    // Reduce the quantity
                    cartItem.Quantity -= quantityToRemove;
                }
                else
                {
                    // Remove the item if quantity is 0 or less
                    _context.UserCarts.Remove(cartItem);
                }

                await _context.SaveChangesAsync();
            }

            return RedirectToAction("ViewCart");
        }

    }
}
