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
           }
    }
}
