using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECommerce_WebApp.Services.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
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
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
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
                    { 4, "Home Appliances", false, null },
                    { 2, "Computers & Accessories", true, 1 },
                    { 3, "Smartphones", false, 1 },
                    { 5, "Kitchen Appliances", false, 4 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProdId", "CategoryId", "CreatedDate", "IsFeatured", "ProdDescription", "ProdImage", "ProdName", "ProdPrice", "ProdRating", "SalesCount" },
                values: new object[,]
                {
                    { 5, 1, new DateTime(2024, 10, 29, 23, 7, 47, 37, DateTimeKind.Utc).AddTicks(7902), true, "Large-screen TV with 4K resolution for ultimate entertainment.", "4k_tv.jpg", "4K Ultra HD TV", 799.99m, 4.6m, 120 },
                    { 6, 1, new DateTime(2024, 11, 8, 23, 7, 47, 37, DateTimeKind.Utc).AddTicks(8212), false, "Wireless headphones with noise cancellation and high-fidelity sound.", "bluetooth_headphones.jpg", "Bluetooth Headphones", 199.99m, 4.3m, 80 },
                    { 11, 4, new DateTime(2024, 11, 10, 23, 7, 47, 37, DateTimeKind.Utc).AddTicks(8228), false, "Compact microwave with multiple cooking modes.", "microwave_oven.jpg", "Microwave Oven", 129.99m, 4.5m, 70 },
                    { 12, 4, new DateTime(2024, 11, 16, 23, 7, 47, 37, DateTimeKind.Utc).AddTicks(8230), true, "HEPA air purifier for clean and fresh indoor air.", "air_purifier.jpg", "Air Purifier", 149.99m, 4.6m, 85 },
                    { 15, 1, new DateTime(2024, 11, 21, 23, 7, 47, 37, DateTimeKind.Utc).AddTicks(8237), true, "Control your smart home devices with a single hub.", "smart_home_hub.jpg", "Smart Home Hub", 99.99m, 4.3m, 75 },
                    { 7, 2, new DateTime(2024, 11, 3, 23, 7, 47, 37, DateTimeKind.Utc).AddTicks(8219), true, "RGB backlit mechanical keyboard for gaming and productivity.", "mechanical_keyboard.jpg", "Mechanical Keyboard", 89.99m, 4.7m, 150 },
                    { 8, 2, new DateTime(2024, 11, 13, 23, 7, 47, 37, DateTimeKind.Utc).AddTicks(8221), false, "2TB portable external hard drive for data backup and storage.", "external_hard_drive.jpg", "External Hard Drive", 59.99m, 4.4m, 60 },
                    { 9, 3, new DateTime(2024, 11, 18, 23, 7, 47, 37, DateTimeKind.Utc).AddTicks(8223), true, "Budget smartphone with excellent performance and camera quality.", "smartphone_abc.jpg", "Smartphone ABC", 299.99m, 4.1m, 90 },
                    { 10, 3, new DateTime(2024, 11, 23, 23, 7, 47, 37, DateTimeKind.Utc).AddTicks(8226), false, "Includes phone case, screen protector, and charging cable.", "smartphone_accessories.jpg", "Smartphone Accessories Pack", 49.99m, 4.0m, 40 },
                    { 13, 5, new DateTime(2024, 11, 20, 23, 7, 47, 37, DateTimeKind.Utc).AddTicks(8232), false, "Two-slice toaster with adjustable browning levels.", "toaster.jpg", "Toaster", 24.99m, 4.2m, 50 },
                    { 14, 5, new DateTime(2024, 11, 25, 23, 7, 47, 37, DateTimeKind.Utc).AddTicks(8234), true, "Automatic coffee maker with programmable brewing.", "coffee_maker.jpg", "Coffee Maker", 79.99m, 4.4m, 65 },
                    { 16, 2, new DateTime(2024, 11, 14, 23, 7, 47, 37, DateTimeKind.Utc).AddTicks(8239), false, "Ergonomic gaming chair with adjustable height and lumbar support.", "gaming_chair.jpg", "Gaming Chair", 199.99m, 4.5m, 110 }
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
                name: "Categories");
        }
    }
}
