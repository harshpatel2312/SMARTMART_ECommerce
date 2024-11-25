using ECommerce_WebApp.Entities.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_WebApp.Entities
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "User name is required.")]
        [StringLength(10, ErrorMessage = "User name should be 2-10 characters in length.", MinimumLength = 2)]
        [RegularExpression(@"^[^0-9]+$", ErrorMessage = "User name should not contain digits.")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string? Email {  get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(20, ErrorMessage = "Password should be 8-20 characters long", MinimumLength = 8)]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", 
            ErrorMessage = "The password must be at least 8 characters long and must include at least one letter, one number, and one special character.")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Role is required")]
        [UserRole(ErrorMessage = "Role should be Shopper or Admin")]
        public string Role { get; set; }
    }
}
