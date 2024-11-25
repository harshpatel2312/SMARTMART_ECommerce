using ECommerce_WebApp.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_WebApp.Services
{
    public static class ModelBuilderExtension
    {

        public static void ConfigureProdandCategory(this ModelBuilder modelBuilder)
        {

        }

        public static void UsersSeed(this ModelBuilder modelBuilder) {
            modelBuilder.Entity<User>().HasData(
                new User { UserId = 1, UserName = "Harsh", Email = "harsh@gmail.com", Password = "H@rsh123", Role = "Admin"},
                new User { UserId = 2, UserName = "Keron", Email = "keron@gmail.com", Password = "Keron@123", Role = "Shopper" },
                new User { UserId = 3, UserName = "Arjun", Email = "arjun@gmail.com", Password = "@rjun123", Role = "Admin" }
                );
        }
    }
}
