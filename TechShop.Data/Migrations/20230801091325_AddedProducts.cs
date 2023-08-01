using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechShop.Data.Migrations
{
    public partial class AddedProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 1, 9, 13, 25, 395, DateTimeKind.Utc).AddTicks(3354),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ApplicationUserId", "CategoryId", "Description", "ImageUrl", "Model", "Name", "Price" },
                values: new object[] { new Guid("592cc260-2c83-4c82-91b5-5d1fa734d848"), null, 1, "Intel Core i3-12100\r\nIntel UHD Graphics 730\r\nот 8GB до 32GB DDR4\r\nот 512GB SSD NVMe до 4TB (SSD и HDD)", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6401/6401009_sd.jpg;maxHeight=2000;maxWidth=2000", "Lenovo", "Desktop Exteme configuration", 1300.00m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ApplicationUserId", "CategoryId", "Description", "ImageUrl", "Model", "Name", "Price" },
                values: new object[] { new Guid("634a647a-b133-4f6c-b931-236f19c2b7d6"), null, 2, "Intel Core i5-1135G7\r\nIntel Iris Xe Graphics\r\nот 8GB до 40GB DDR4\r\nот 512GB SSD NVMe до 2TB SSD NVMe", "https://m.media-amazon.com/images/I/71y1msTBGAL._AC_SL1500_.jpg", "Asus", "ASUS Laptop L510 Ultra Thin Laptop", 1900.00m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ApplicationUserId", "CategoryId", "Description", "ImageUrl", "Model", "Name", "Price" },
                values: new object[] { new Guid("793aa38d-73dc-410e-8322-65ea1301dece"), null, 2, "Intel Core i7-11800H\r\nNVIDIA GeForce RTX 3050 Ti\r\nот 16GB до 64GB DDR4\r\nот 512GB SSD NVMe до 2TB SSD NVMe", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6511/6511432_rd.jpg;maxHeight=640;maxWidth=550", "Msi", "MSI Katana GF76 11UD", 1800.00m });

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("592cc260-2c83-4c82-91b5-5d1fa734d848"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("634a647a-b133-4f6c-b931-236f19c2b7d6"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("793aa38d-73dc-410e-8322-65ea1301dece"));

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Products",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Products",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 1, 9, 13, 25, 395, DateTimeKind.Utc).AddTicks(3354));

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
