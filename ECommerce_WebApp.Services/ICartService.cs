﻿using ECommerce_WebApp.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerce_WebApp.Services
{
    public interface ICartService
    {
        Task AddToCartAsync(Product product);
        List<Product> GetCartItems();
    }
}