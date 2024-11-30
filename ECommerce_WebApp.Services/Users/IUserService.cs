using ECommerce_WebApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_WebApp.Services.Users
{
    public interface IUserService
    {
        User SignUpUser(User user);

        bool LogInUser(string? email, string? password);
    }
}
