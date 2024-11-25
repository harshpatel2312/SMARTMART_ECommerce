using ECommerce_WebApp.Entities;
using ECommerce_WebApp.Services.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ECommerce_WebApp.Operations.Controllers
{
    public class UserController : Controller
    {
        private IUserService _userService;
        public UserController(IUserService userService) {
            _userService = userService;
        }

        public List<SelectListItem> SelectRole()
        {
            List<string> roles = new List<string> { "Shopper", "Admin" };
            List<SelectListItem> selectRole = new List<SelectListItem>();
            foreach (string role in roles) {
                selectRole.Add(
                    new SelectListItem { Text = role, Value = role }
                    );
            }
            return selectRole;
        }

        [HttpPost]
        public IActionResult SignUp(User user)
        {
            ViewBag.Roles = SelectRole();
            var save = _userService.SignUpUser(user);
            if (save != null) { 
                return View(save);
            }
            return NotFound();
        }

        [HttpGet]
        public IActionResult SignUp() {
            ViewBag.Roles = SelectRole();
            return View();
        }

        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LogIn(string? email, string? password)
        {
            if (!_userService.LogInUser(email, password))
            {
                TempData["Message"] = "Invalid login credentials. Please sign up if you don't have an account.";
                return View();
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
