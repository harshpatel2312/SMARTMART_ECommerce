using ECommerce_WebApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_WebApp.Services.Users
{
    public class UserRepository : IUserService
    {
        private readonly DataContext _dataContext;
        public UserRepository(DataContext dataContext) {
            _dataContext = dataContext;
        }

        public User SignUpUser(User user)
        {
            _dataContext.Users.Add(user);
            _dataContext.SaveChanges();
            return user;
        }

        public bool LogInUser(string? email, string? password) {
            //Getting data of the user if it exists
            var userExists = _dataContext.Users.FirstOrDefault(u => u.Email == email);
            if (userExists != null) {
                bool isPasswordValid = BCrypt.Net.BCrypt.Verify(password, userExists.Password); // Checking if the password matches
                return isPasswordValid;
            }
            return false;
        }
    }
}
