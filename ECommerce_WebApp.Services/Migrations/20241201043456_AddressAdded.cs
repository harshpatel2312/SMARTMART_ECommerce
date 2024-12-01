using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce_WebApp.Services.Migrations
{
    /// <inheritdoc />
    public partial class AddressAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Role",
                table: "Users",
                newName: "Province");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Users",
                type: "TEXT",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "Users",
                type: "TEXT",
                maxLength: 7,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StreetAddress",
                table: "Users",
                type: "TEXT",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProdId",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 1, 4, 34, 54, 254, DateTimeKind.Utc).AddTicks(2206));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProdId",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 11, 4, 34, 54, 254, DateTimeKind.Utc).AddTicks(3391));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProdId",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 6, 4, 34, 54, 254, DateTimeKind.Utc).AddTicks(3430));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProdId",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 16, 4, 34, 54, 254, DateTimeKind.Utc).AddTicks(3433));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProdId",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 21, 4, 34, 54, 254, DateTimeKind.Utc).AddTicks(3435));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProdId",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 26, 4, 34, 54, 254, DateTimeKind.Utc).AddTicks(3438));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProdId",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 13, 4, 34, 54, 254, DateTimeKind.Utc).AddTicks(3440));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProdId",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 19, 4, 34, 54, 254, DateTimeKind.Utc).AddTicks(3443));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProdId",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 23, 4, 34, 54, 254, DateTimeKind.Utc).AddTicks(3445));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProdId",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 28, 4, 34, 54, 254, DateTimeKind.Utc).AddTicks(3448));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "City", "PostalCode", "Province", "StreetAddress" },
                values: new object[] { "Mississauga", "L5N 4C6", "ON", "1234 Clairview St" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "City", "PostalCode", "Province", "StreetAddress" },
                values: new object[] { "Oakville", "B2M 3F4", "BC", "5642 Winston Park" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "City", "PostalCode", "Province", "StreetAddress" },
                values: new object[] { "Brampton", "C5B 7M8", "AB", "6640 Boulevard Ave" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "StreetAddress",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Province",
                table: "Users",
                newName: "Role");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProdId",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 10, 31, 2, 57, 35, 890, DateTimeKind.Utc).AddTicks(6430));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProdId",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 10, 2, 57, 35, 890, DateTimeKind.Utc).AddTicks(8198));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProdId",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 5, 2, 57, 35, 890, DateTimeKind.Utc).AddTicks(8212));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProdId",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 15, 2, 57, 35, 890, DateTimeKind.Utc).AddTicks(8217));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProdId",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 20, 2, 57, 35, 890, DateTimeKind.Utc).AddTicks(8222));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProdId",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 25, 2, 57, 35, 890, DateTimeKind.Utc).AddTicks(8226));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProdId",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 12, 2, 57, 35, 890, DateTimeKind.Utc).AddTicks(8230));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProdId",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 18, 2, 57, 35, 890, DateTimeKind.Utc).AddTicks(8234));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProdId",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 22, 2, 57, 35, 890, DateTimeKind.Utc).AddTicks(8238));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProdId",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 27, 2, 57, 35, 890, DateTimeKind.Utc).AddTicks(8242));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Role",
                value: "Admin");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "Role",
                value: "Shopper");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "Role",
                value: "Admin");
        }
    }
}
