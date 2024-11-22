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

            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Electronics", ParentCategoryId = null },
                new Category { CategoryId = 2, CategoryName = "Laptops", ParentCategoryId = 1 },
                new Category { CategoryId = 3, CategoryName = "Mobile Phones", ParentCategoryId = 1 },
                new Category { CategoryId = 4, CategoryName = "Furniture", ParentCategoryId = null },
                new Category { CategoryId = 5, CategoryName = "Chairs", ParentCategoryId = 4 }
            );

            // Add seed data for Product
            modelBuilder.Entity<Product>().HasData(
                new Product { ProdId = 1, ProdName = "Dell XPS 13", CategoryId = 2, ProdPrice = 1200 },
                new Product { ProdId = 2, ProdName = "iPhone 14", CategoryId = 3, ProdPrice = 999 },
                new Product { ProdId = 3, ProdName = "Office Chair", CategoryId = 5, ProdPrice = 150 },
                new Product { ProdId = 4, ProdName = "Samsung Galaxy S23", CategoryId = 3, ProdPrice = 799 },
                new Product { ProdId = 5, ProdName = "Gaming Laptop", CategoryId = 2, ProdPrice = 1800 }
            );
        }
    }
}
