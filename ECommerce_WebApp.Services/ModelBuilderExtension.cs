using ECommerce_WebApp.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace ECommerce_WebApp.Services
{
    public static class ModelBuilderExtension
    {
        public static void ConfigureProdandCategory(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.ProdId);

                // Product has one category and with many products
                entity.HasOne(e => e.Category)
                    .WithMany(c => c.Products)
                    .HasForeignKey(e => e.CategoryId);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.CategoryId);

                entity.HasOne(e => e.ParentCategory)
                    .WithMany(c => c.SubCategories)
                    .HasForeignKey(e => e.ParentCategoryId);
            });

            // Seed data for Categories
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Electronics", ParentCategoryId = null, IsFeatured = true },
                new Category { CategoryId = 2, CategoryName = "Computers & Accessories", ParentCategoryId = 1, IsFeatured = true },
                new Category { CategoryId = 3, CategoryName = "Smartphones", ParentCategoryId = 1 },
                new Category { CategoryId = 4, CategoryName = "Home Appliances", ParentCategoryId = null },
                new Category { CategoryId = 5, CategoryName = "Kitchen Appliances", ParentCategoryId = 4 }
            );

            // Seed data for Products
            modelBuilder.Entity<Product>().HasData(
                // Electronics
                new Product
                {
                    ProdId = 5,
                    ProdName = "4K Ultra HD TV",
                    ProdDescription = "Large-screen TV with 4K resolution for ultimate entertainment.",
                    ProdPrice = 799.99m,
                    ProdImage = "/images/products/4k_tv.jpg",
                    CategoryId = 1,
                    ProdRating = 4.6m,
                    SalesCount = 120,
                    IsFeatured = true,
                    CreatedDate = DateTime.UtcNow.AddDays(-30),
                    Brand = "Sony",
                    Dimensions = "48 x 30 x 3 inches",
                    Weight = "35 lbs",
                    Warranty = "2 years"
                },
                new Product
                {
                    ProdId = 6,
                    ProdName = "Bluetooth Headphones",
                    ProdDescription = "Wireless headphones with noise cancellation and high-fidelity sound.",
                    ProdPrice = 199.99m,
                    ProdImage = "/images/products/bluetooth_headphones.jpg",
                    CategoryId = 1,
                    ProdRating = 4.3m,
                    SalesCount = 80,
                    IsFeatured = false,
                    CreatedDate = DateTime.UtcNow.AddDays(-20),
                    Brand = "Bose",
                    Dimensions = "7 x 6 x 3 inches",
                    Weight = "1.5 lbs",
                    Warranty = "1 year"
                },

                // Computers & Accessories
                new Product
                {
                    ProdId = 7,
                    ProdName = "Mechanical Keyboard",
                    ProdDescription = "RGB backlit mechanical keyboard for gaming and productivity.",
                    ProdPrice = 89.99m,
                    ProdImage = "/images/products/mechanical_keyboard.jpg",
                    CategoryId = 2,
                    ProdRating = 4.7m,
                    SalesCount = 150,
                    IsFeatured = true,
                    CreatedDate = DateTime.UtcNow.AddDays(-25),
                    Brand = "Logitech",
                    Dimensions = "18 x 6 x 1 inches",
                    Weight = "2 lbs",
                    Warranty = "3 years"
                },
                new Product
                {
                    ProdId = 8,
                    ProdName = "External Hard Drive",
                    ProdDescription = "2TB portable external hard drive for data backup and storage.",
                    ProdPrice = 59.99m,
                    ProdImage = "/images/products/external_hard_drive.jpg",
                    CategoryId = 2,
                    ProdRating = 4.4m,
                    SalesCount = 60,
                    IsFeatured = false,
                    CreatedDate = DateTime.UtcNow.AddDays(-15),
                    Brand = "Seagate",
                    Dimensions = "4.6 x 3.1 x 0.8 inches",
                    Weight = "0.6 lbs",
                    Warranty = "2 years"
                },

                // Smartphones
                new Product
                {
                    ProdId = 9,
                    ProdName = "Smartphone ABC",
                    ProdDescription = "Budget smartphone with excellent performance and camera quality.",
                    ProdPrice = 299.99m,
                    ProdImage = "/images/products/smartphone_abc.jpg",
                    CategoryId = 3,
                    ProdRating = 4.1m,
                    SalesCount = 90,
                    IsFeatured = true,
                    CreatedDate = DateTime.UtcNow.AddDays(-10),
                    Brand = "Samsung",
                    Dimensions = "6 x 3 x 0.3 inches",
                    Weight = "0.4 lbs",
                    Warranty = "1 year"
                },
                new Product
                {
                    ProdId = 10,
                    ProdName = "Smartphone Accessories Pack",
                    ProdDescription = "Includes phone case, screen protector, and charging cable.",
                    ProdPrice = 49.99m,
                    ProdImage = "/images/products/smartphone_accessories.jpg",
                    CategoryId = 3,
                    ProdRating = 4.0m,
                    SalesCount = 40,
                    IsFeatured = false,
                    CreatedDate = DateTime.UtcNow.AddDays(-5),
                    Brand = "Generic",
                    Dimensions = "9 x 6 x 2 inches",
                    Weight = "1 lbs",
                    Warranty = "6 months"
                },

                // Home Appliances
                new Product
                {
                    ProdId = 11,
                    ProdName = "Microwave Oven",
                    ProdDescription = "Compact microwave with multiple cooking modes.",
                    ProdPrice = 129.99m,
                    ProdImage = "/images/products/microwave_oven.jpg",
                    CategoryId = 4,
                    ProdRating = 4.5m,
                    SalesCount = 70,
                    IsFeatured = false,
                    CreatedDate = DateTime.UtcNow.AddDays(-18),
                    Brand = "Panasonic",
                    Dimensions = "20 x 14 x 12 inches",
                    Weight = "25 lbs",
                    Warranty = "3 years"
                },
                new Product
                {
                    ProdId = 12,
                    ProdName = "Air Purifier",
                    ProdDescription = "HEPA air purifier for clean and fresh indoor air.",
                    ProdPrice = 149.99m,
                    ProdImage = "/images/products/air_purifier.jpg",
                    CategoryId = 4,
                    ProdRating = 4.6m,
                    SalesCount = 85,
                    IsFeatured = true,
                    CreatedDate = DateTime.UtcNow.AddDays(-12),
                    Brand = "Dyson",
                    Dimensions = "18 x 10 x 8 inches",
                    Weight = "12 lbs",
                    Warranty = "2 years"
                },

                // Kitchen Appliances
                new Product
                {
                    ProdId = 13,
                    ProdName = "Toaster",
                    ProdDescription = "Two-slice toaster with adjustable browning levels.",
                    ProdPrice = 24.99m,
                    ProdImage = "/images/products/toaster.jpg",
                    CategoryId = 5,
                    ProdRating = 4.2m,
                    SalesCount = 50,
                    IsFeatured = false,
                    CreatedDate = DateTime.UtcNow.AddDays(-8),
                    Brand = "Cuisinart",
                    Dimensions = "11 x 7 x 8 inches",
                    Weight = "5 lbs",
                    Warranty = "1 year"
                },
                new Product
                {
                    ProdId = 14,
                    ProdName = "Coffee Maker",
                    ProdDescription = "Automatic coffee maker with programmable brewing.",
                    ProdPrice = 79.99m,
                    ProdImage = "/images/products/coffee_maker.jpg",
                    CategoryId = 5,
                    ProdRating = 4.4m,
                    SalesCount = 65,
                    IsFeatured = true,
                    CreatedDate = DateTime.UtcNow.AddDays(-3),
                    Brand = "Keurig",
                    Dimensions = "15 x 9 x 13 inches",
                    Weight = "8 lbs",
                    Warranty = "2 years"
                }
            );
        }
    }
}
