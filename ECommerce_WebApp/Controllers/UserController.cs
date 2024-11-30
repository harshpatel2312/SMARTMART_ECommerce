using ECommerce_WebApp.Entities;
using ECommerce_WebApp.Services.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using BCrypt.Net;
using Microsoft.AspNetCore.Authentication;

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
            
            //Hashing the password before saving
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(user.Password);
            user.Password = hashedPassword; //Overring the password with the hashed one

            var save = _userService.SignUpUser(user);
            if (save != null) { 
                return RedirectToAction("LogIn");
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
            var user = _userService.LogInUser(email, password);

            if (user == null)
            {
                TempData["Message"] = "Invalid login credentials. Please sign up if you don't have an account.";
                return View();
            }
            HttpContext.Session.SetString("Username", user.UserName); // Creating a session
            HttpContext.Session.SetInt32("currentUserId", user.UserId);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            //Clearing authentication cookies
            HttpContext.SignOutAsync();
            return RedirectToAction("LogIn", "User");
        }

        [HttpGet]
        public IActionResult Account()
        {
            //Getting userId from the current session
            var userId = HttpContext.Session.GetInt32("currentUserId");
            if(userId == null)
            {
                return RedirectToAction("LogIn", "User");
            }

            var user = _userService.GetUserById(userId.Value);
            if(user != null)
            {
                return View(user);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Account(User user)
        {
            _userService.UpdateUser(user);
            return View();
        }
    }
}
