using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;


namespace ECommerce_WebApp.Operations.Filters
{
    //Made by Harsh
    public class SessionDataFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // Logic to execute before the action method runs
            var controller = context.Controller as Controller;
            if (controller != null)
            {
                var httpContext = controller.HttpContext;

                // Populate ViewBag
                controller.ViewBag.UserId = httpContext.Session.GetString("UserId");
                controller.ViewBag.Username = httpContext.Session.GetString("Username");
                controller.ViewBag.Email = httpContext.Session.GetString("Email");
                controller.ViewBag.Password = httpContext.Session.GetString("Password");
                controller.ViewBag.StreetAddress = httpContext.Session.GetString("StreetAddress");
                controller.ViewBag.City = httpContext.Session.GetString("City");
                controller.ViewBag.Province = httpContext.Session.GetString("Province");
                controller.ViewBag.PostalCode = httpContext.Session.GetString("PostalCode");
            }

            base.OnActionExecuting(context);
        }
    }
}
