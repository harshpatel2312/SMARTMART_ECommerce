using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECommerce_WebApp.Services.Migrations
{
    /// <inheritdoc />
    public partial class devMerge : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    ParentCategoryId = table.Column<int>(type: "INTEGER", nullable: true),
                    IsFeatured = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                    table.ForeignKey(
                        name: "FK_Categories_Categories_ParentCategoryId",
                        column: x => x.ParentCategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Role = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProdId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProdName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    ProdDescription = table.Column<string>(type: "TEXT", nullable: false),
                    ProdPrice = table.Column<decimal>(type: "TEXT", nullable: false),
                    ProdImage = table.Column<string>(type: "TEXT", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProdRating = table.Column<decimal>(type: "TEXT", nullable: true),
                    SalesCount = table.Column<int>(type: "INTEGER", nullable: false),
                    IsFeatured = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Brand = table.Column<string>(type: "TEXT", nullable: false),
                    Dimensions = table.Column<string>(type: "TEXT", nullable: false),
                    Weight = table.Column<string>(type: "TEXT", nullable: false),
                    Warranty = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProdId);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName", "IsFeatured", "ParentCategoryId" },
                values: new object[,]
                {
                    { 1, "Electronics", true, null },
                    { 4, "Home Appliances", false, null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "Password", "Role", "UserName" },
                values: new object[,]
                {
                    { 1, "harsh@gmail.com", "H@rsh123", "Admin", "Harsh" },
                    { 2, "keron@gmail.com", "Keron@123", "Shopper", "Keron" },
                    { 3, "arjun@gmail.com", "@rjun123", "Admin", "Arjun" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName", "IsFeatured", "ParentCategoryId" },
                values: new object[,]
                {
                    { 2, "Computers & Accessories", true, 1 },
                    { 3, "Smartphones", false, 1 },
                    { 5, "Kitchen Appliances", false, 4 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProdId", "Brand", "CategoryId", "CreatedDate", "Dimensions", "IsFeatured", "ProdDescription", "ProdImage", "ProdName", "ProdPrice", "ProdRating", "SalesCount", "Warranty", "Weight" },
                values: new object[,]
                {
                    { 5, "Sony", 1, new DateTime(2024, 10, 31, 2, 57, 35, 890, DateTimeKind.Utc).AddTicks(6430), "48 x 30 x 3 inches", true, "Large-screen TV with 4K resolution for ultimate entertainment.", "/images/products/4k_tv.jpg", "4K Ultra HD TV", 799.99m, 4.6m, 120, "2 years", "35 lbs" },
                    { 6, "Bose", 1, new DateTime(2024, 11, 10, 2, 57, 35, 890, DateTimeKind.Utc).AddTicks(8198), "7 x 6 x 3 inches", false, "Wireless headphones with noise cancellation and high-fidelity sound.", "/images/products/bluetooth_headphones.jpg", "Bluetooth Headphones", 199.99m, 4.3m, 80, "1 year", "1.5 lbs" },
                    { 11, "Panasonic", 4, new DateTime(2024, 11, 12, 2, 57, 35, 890, DateTimeKind.Utc).AddTicks(8230), "20 x 14 x 12 inches", false, "Compact microwave with multiple cooking modes.", "/images/products/microwave_oven.jpg", "Microwave Oven", 129.99m, 4.5m, 70, "3 years", "25 lbs" },
                    { 12, "Dyson", 4, new DateTime(2024, 11, 18, 2, 57, 35, 890, DateTimeKind.Utc).AddTicks(8234), "18 x 10 x 8 inches", true, "HEPA air purifier for clean and fresh indoor air.", "/images/products/air_purifier.jpg", "Air Purifier", 149.99m, 4.6m, 85, "2 years", "12 lbs" },
                    { 7, "Logitech", 2, new DateTime(2024, 11, 5, 2, 57, 35, 890, DateTimeKind.Utc).AddTicks(8212), "18 x 6 x 1 inches", true, "RGB backlit mechanical keyboard for gaming and productivity.", "/images/products/mechanical_keyboard.jpg", "Mechanical Keyboard", 89.99m, 4.7m, 150, "3 years", "2 lbs" },
                    { 8, "Seagate", 2, new DateTime(2024, 11, 15, 2, 57, 35, 890, DateTimeKind.Utc).AddTicks(8217), "4.6 x 3.1 x 0.8 inches", false, "2TB portable external hard drive for data backup and storage.", "/images/products/external_hard_drive.jpg", "External Hard Drive", 59.99m, 4.4m, 60, "2 years", "0.6 lbs" },
                    { 9, "Samsung", 3, new DateTime(2024, 11, 20, 2, 57, 35, 890, DateTimeKind.Utc).AddTicks(8222), "6 x 3 x 0.3 inches", true, "Budget smartphone with excellent performance and camera quality.", "/images/products/smartphone_abc.jpg", "Smartphone ABC", 299.99m, 4.1m, 90, "1 year", "0.4 lbs" },
                    { 10, "Generic", 3, new DateTime(2024, 11, 25, 2, 57, 35, 890, DateTimeKind.Utc).AddTicks(8226), "9 x 6 x 2 inches", false, "Includes phone case, screen protector, and charging cable.", "/images/products/smartphone_accessories.jpg", "Smartphone Accessories Pack", 49.99m, 4.0m, 40, "6 months", "1 lbs" },
                    { 13, "Cuisinart", 5, new DateTime(2024, 11, 22, 2, 57, 35, 890, DateTimeKind.Utc).AddTicks(8238), "11 x 7 x 8 inches", false, "Two-slice toaster with adjustable browning levels.", "/images/products/toaster.jpg", "Toaster", 24.99m, 4.2m, 50, "1 year", "5 lbs" },
                    { 14, "Keurig", 5, new DateTime(2024, 11, 27, 2, 57, 35, 890, DateTimeKind.Utc).AddTicks(8242), "15 x 9 x 13 inches", true, "Automatic coffee maker with programmable brewing.", "/images/products/coffee_maker.jpg", "Coffee Maker", 79.99m, 4.4m, 65, "2 years", "8 lbs" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ParentCategoryId",
                table: "Categories",
                column: "ParentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
