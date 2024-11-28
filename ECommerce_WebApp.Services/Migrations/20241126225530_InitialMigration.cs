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
                    ParentCategoryId = table.Column<int>(type: "INTEGER", nullable: true)
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
                    ProdRating = table.Column<decimal>(type: "TEXT", nullable: true)
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
                columns: new[] { "CategoryId", "CategoryName", "ParentCategoryId" },
                values: new object[,]
                {
                    { 1, "Electronics", null },
                    { 4, "Home Appliances", null },
                    { 2, "Computers & Accessories", 1 },
                    { 3, "Smartphones", 1 },
                    { 5, "Kitchen Appliances", 4 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProdId", "CategoryId", "ProdDescription", "ProdImage", "ProdName", "ProdPrice", "ProdRating" },
                values: new object[,]
                {
                    { 5, 1, "Large-screen TV with 4K resolution for ultimate entertainment.", "4k_tv.jpg", "4K Ultra HD TV", 799.99m, 4.6m },
                    { 6, 1, "Wireless headphones with noise cancellation and high-fidelity sound.", "bluetooth_headphones.jpg", "Bluetooth Headphones", 199.99m, 4.3m },
                    { 11, 4, "Compact microwave with multiple cooking modes.", "microwave_oven.jpg", "Microwave Oven", 129.99m, 4.5m },
                    { 12, 4, "HEPA air purifier for clean and fresh indoor air.", "air_purifier.jpg", "Air Purifier", 149.99m, 4.6m },
                    { 15, 1, "Control your smart home devices with a single hub.", "smart_home_hub.jpg", "Smart Home Hub", 99.99m, 4.3m },
                    { 7, 2, "RGB backlit mechanical keyboard for gaming and productivity.", "mechanical_keyboard.jpg", "Mechanical Keyboard", 89.99m, 4.7m },
                    { 8, 2, "2TB portable external hard drive for data backup and storage.", "external_hard_drive.jpg", "External Hard Drive", 59.99m, 4.4m },
                    { 9, 3, "Budget smartphone with excellent performance and camera quality.", "smartphone_abc.jpg", "Smartphone ABC", 299.99m, 4.1m },
                    { 10, 3, "Includes phone case, screen protector, and charging cable.", "smartphone_accessories.jpg", "Smartphone Accessories Pack", 49.99m, 4.0m },
                    { 13, 5, "Two-slice toaster with adjustable browning levels.", "toaster.jpg", "Toaster", 24.99m, 4.2m },
                    { 14, 5, "Automatic coffee maker with programmable brewing.", "coffee_maker.jpg", "Coffee Maker", 79.99m, 4.4m },
                    { 16, 2, "Ergonomic gaming chair with adjustable height and lumbar support.", "gaming_chair.jpg", "Gaming Chair", 199.99m, 4.5m }
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
