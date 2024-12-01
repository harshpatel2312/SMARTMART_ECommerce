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

        public List<SelectListItem> SelectProvince()
        {
            List<string> provinces = new List<string> { "AB", "BC", "MB", "NB", "NL", "NS", "ON", "PE", "QC", "SK", "YT" };
            List<SelectListItem> selectProvince = new List<SelectListItem>();
            foreach (string province in provinces) {
                selectProvince.Add(
                    new SelectListItem { Text = province, Value = province }
                    );
            }
            return selectProvince;
        }

        [HttpPost]
        public IActionResult SignUp(User user)
        {
            ViewBag.Province = SelectProvince();
            
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
            ViewBag.Province = SelectProvince();
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
            //Creating a session
            HttpContext.Session.SetString("UserId", user.UserId.ToString());
            HttpContext.Session.SetString("Username", user.UserName);
            HttpContext.Session.SetString("Email", user.Email);
            HttpContext.Session.SetString("StreetAddress", user.StreetAddress);
            HttpContext.Session.SetString("City", user.City);
            HttpContext.Session.SetString("Province", user.Province);
            HttpContext.Session.SetString("PostalCode", user.PostalCode);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult LogOut()
        {
            //Clear Session
            HttpContext.Session.Clear();
            //Clearing authentication cookies
            //HttpContext.SignOutAsync();
            return RedirectToAction("LogIn", "User");
        }

        public IActionResult Account()
        {
            //Getting userId from the current session
            var userId = HttpContext.Session.GetString("UserId");
            if(string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("LogIn", "User");
            }

            var username = HttpContext.Session.GetString("Username");
            var email = HttpContext.Session.GetString("Email");
            var streetaddress = HttpContext.Session.GetString("StreetAddress");
            var city = HttpContext.Session.GetString("City");
            var province = HttpContext.Session.GetString("Provicne");
            var postalCode = HttpContext.Session.GetString("PostalCode");
            
            ViewBag.UserId = userId;
            ViewBag.Username = username;
            ViewBag.Email = email;
            ViewBag.StreetAddress = streetaddress;
            ViewBag.City = city;
            ViewBag.Province = province;
            ViewBag.PostalCode = postalCode;

            return View();
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var user = _userService.GetUserById(id);

            if (user == null) { 
                return View("Error");
            }

            ViewBag.Province = SelectProvince();
            return View(user);
        }

        [HttpPost]
        public ActionResult Update(User user) { 
            var save = _userService.UpdateUser(user);
            return RedirectToAction("Account", "User");
        }
    }
}
