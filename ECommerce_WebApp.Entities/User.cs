using ECommerce_WebApp.Entities.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Made by Harsh
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

        [Required(ErrorMessage = "Street address is required")]
        [StringLength(100, ErrorMessage = "Address should be of max 10-100 characters")]
        public string? StreetAddress { get; set; }

        [Required(ErrorMessage = "City is required")]
        [StringLength(20, ErrorMessage = "City name should be of 2-20 characters", MinimumLength = 2)]
        public string? City { get; set; }

        [Required(ErrorMessage = "Province is required")]
        public string? Province { get; set; }

        [Required(ErrorMessage = "Postal code is required")]
        [StringLength(7, ErrorMessage = "Postal code should be of 7 characters including space")]
        [RegularExpression(@"^[A-Za-z]\d[A-Za-z] \d[A-Za-z]\d$", ErrorMessage = "Postal code should follow a format of A1A 2B3")]
        public string? PostalCode { get; set; }
    }
}
