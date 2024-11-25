using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_WebApp.Entities.Utilities
{
    public class UserRoleAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(value is string userRole && (userRole == "Shopper" || userRole == "Admin"))
            {
                return ValidationResult.Success;
            }
            return new ValidationResult(ErrorMessage ?? "Invalid Role.");
        }
    }
}
