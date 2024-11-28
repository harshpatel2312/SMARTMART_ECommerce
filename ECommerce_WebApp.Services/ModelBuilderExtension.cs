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
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.ProdId);
                // Product has one category and with many products
                entity.HasOne(e => e.Category)
                    .WithMany(c => c.Products)
                    .HasForeignKey(e => e.CategoryId)
                    .OnDelete(DeleteBehavior.Cascade);
            }
                );
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.CategoryId);
                entity.HasOne(e => e.ParentCategory)
                    .WithMany(c => c.SubCategories)
                    .HasForeignKey(e => e.ParentCategoryId);
                    //.OnDelete(DeleteBehavior.Restrict); 
            }
                );

            // Seed data for Categories
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Electronics", ParentCategoryId = null },
                new Category { CategoryId = 2, CategoryName = "Computers & Accessories", ParentCategoryId = 1 },
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
                ProdImage = "4k_tv.jpg",
                CategoryId = 1,
                ProdRating = 4.6m
            },
            new Product
            {
                ProdId = 6,
                ProdName = "Bluetooth Headphones",
                ProdDescription = "Wireless headphones with noise cancellation and high-fidelity sound.",
                ProdPrice = 199.99m,
                ProdImage = "bluetooth_headphones.jpg",
                CategoryId = 1,
                ProdRating = 4.3m
            },

            // Computers & Accessories
            new Product
            {
                ProdId = 7,
                ProdName = "Mechanical Keyboard",
                ProdDescription = "RGB backlit mechanical keyboard for gaming and productivity.",
                ProdPrice = 89.99m,
                ProdImage = "mechanical_keyboard.jpg",
                CategoryId = 2,
                ProdRating = 4.7m
            },
            new Product
            {
                ProdId = 8,
                ProdName = "External Hard Drive",
                ProdDescription = "2TB portable external hard drive for data backup and storage.",
                ProdPrice = 59.99m,
                ProdImage = "external_hard_drive.jpg",
                CategoryId = 2,
                ProdRating = 4.4m
            },

            // Smartphones
            new Product
            {
                ProdId = 9,
                ProdName = "Smartphone ABC",
                ProdDescription = "Budget smartphone with excellent performance and camera quality.",
                ProdPrice = 299.99m,
                ProdImage = "smartphone_abc.jpg",
                CategoryId = 3,
                ProdRating = 4.1m
            },
            new Product
            {
                ProdId = 10,
                ProdName = "Smartphone Accessories Pack",
                ProdDescription = "Includes phone case, screen protector, and charging cable.",
                ProdPrice = 49.99m,
                ProdImage = "smartphone_accessories.jpg",
                CategoryId = 3,
                ProdRating = 4.0m
            },

            // Home Appliances
            new Product
            {
                ProdId = 11,
                ProdName = "Microwave Oven",
                ProdDescription = "Compact microwave with multiple cooking modes.",
                ProdPrice = 129.99m,
                ProdImage = "microwave_oven.jpg",
                CategoryId = 4,
                ProdRating = 4.5m
            },
            new Product
            {
                ProdId = 12,
                ProdName = "Air Purifier",
                ProdDescription = "HEPA air purifier for clean and fresh indoor air.",
                ProdPrice = 149.99m,
                ProdImage = "air_purifier.jpg",
                CategoryId = 4,
                ProdRating = 4.6m
            },

            // Kitchen Appliances
            new Product
            {
                ProdId = 13,
                ProdName = "Toaster",
                ProdDescription = "Two-slice toaster with adjustable browning levels.",
                ProdPrice = 24.99m,
                ProdImage = "toaster.jpg",
                CategoryId = 5,
                ProdRating = 4.2m
            },
            new Product
            {
                ProdId = 14,
                ProdName = "Coffee Maker",
                ProdDescription = "Automatic coffee maker with programmable brewing.",
                ProdPrice = 79.99m,
                ProdImage = "coffee_maker.jpg",
                CategoryId = 5,
                ProdRating = 4.4m
            },

            // Miscellaneous
            new Product
            {
                ProdId = 15,
                ProdName = "Smart Home Hub",
                ProdDescription = "Control your smart home devices with a single hub.",
                ProdPrice = 99.99m,
                ProdImage = "smart_home_hub.jpg",
                CategoryId = 1,
                ProdRating = 4.3m
            },
            new Product
            {
                ProdId = 16,
                ProdName = "Gaming Chair",
                ProdDescription = "Ergonomic gaming chair with adjustable height and lumbar support.",
                ProdPrice = 199.99m,
                ProdImage = "gaming_chair.jpg",
                CategoryId = 2,
                ProdRating = 4.5m
            }
        );

        }
    }
}
