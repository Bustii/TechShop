using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechShop.Data.Migrations
{
    public partial class UpdatedProductSize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 1, 9, 34, 24, 227, DateTimeKind.Utc).AddTicks(2659),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 1, 9, 13, 25, 395, DateTimeKind.Utc).AddTicks(3354));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ApplicationUserId", "CategoryId", "Description", "ImageUrl", "Model", "Name", "Price" },
                values: new object[] { new Guid("0ed62da5-0839-40a7-ba13-32ae61824ee2"), null, 2, "Intel Core i7-11800H\r\nNVIDIA GeForce RTX 3050 Ti\r\nот 16GB до 64GB DDR4\r\nот 512GB SSD NVMe до 2TB SSD NVMe", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6511/6511432_rd.jpg;maxHeight=640;maxWidth=550", "Msi", "MSI Katana GF76 11UD", 1800.00m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ApplicationUserId", "CategoryId", "Description", "ImageUrl", "Model", "Name", "Price" },
                values: new object[] { new Guid("c56d6e6b-921f-47fa-af2c-d56396592777"), null, 2, "Intel Core i5-1135G7\r\nIntel Iris Xe Graphics\r\nот 8GB до 40GB DDR4\r\nот 512GB SSD NVMe до 2TB SSD NVMe", "https://m.media-amazon.com/images/I/71y1msTBGAL._AC_SL1500_.jpg; maxHeight = 640; maxWidth = 550", "Asus", "ASUS Laptop L510 Ultra Thin Laptop", 1900.00m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ApplicationUserId", "CategoryId", "Description", "ImageUrl", "Model", "Name", "Price" },
                values: new object[] { new Guid("dfc5cc78-ffd9-47b0-bf66-d30d243723d6"), null, 1, "Intel Core i3-12100\r\nIntel UHD Graphics 730\r\nот 8GB до 32GB DDR4\r\nот 512GB SSD NVMe до 4TB (SSD и HDD)", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6401/6401009_sd.jpg;maxHeight=640;maxWidth=550", "Lenovo", "Desktop Exteme configuration", 1300.00m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0ed62da5-0839-40a7-ba13-32ae61824ee2"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c56d6e6b-921f-47fa-af2c-d56396592777"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("dfc5cc78-ffd9-47b0-bf66-d30d243723d6"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 1, 9, 13, 25, 395, DateTimeKind.Utc).AddTicks(3354),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 1, 9, 34, 24, 227, DateTimeKind.Utc).AddTicks(2659));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ApplicationUserId", "CategoryId", "CreatedOn", "Description", "ImageUrl", "IsActive", "Model", "Name", "Price" },
                values: new object[] { new Guid("592cc260-2c83-4c82-91b5-5d1fa734d848"), null, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Intel Core i3-12100\r\nIntel UHD Graphics 730\r\nот 8GB до 32GB DDR4\r\nот 512GB SSD NVMe до 4TB (SSD и HDD)", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6401/6401009_sd.jpg;maxHeight=2000;maxWidth=2000", false, "Lenovo", "Desktop Exteme configuration", 1300.00m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ApplicationUserId", "CategoryId", "CreatedOn", "Description", "ImageUrl", "IsActive", "Model", "Name", "Price" },
                values: new object[] { new Guid("634a647a-b133-4f6c-b931-236f19c2b7d6"), null, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Intel Core i5-1135G7\r\nIntel Iris Xe Graphics\r\nот 8GB до 40GB DDR4\r\nот 512GB SSD NVMe до 2TB SSD NVMe", "https://m.media-amazon.com/images/I/71y1msTBGAL._AC_SL1500_.jpg", false, "Asus", "ASUS Laptop L510 Ultra Thin Laptop", 1900.00m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ApplicationUserId", "CategoryId", "CreatedOn", "Description", "ImageUrl", "IsActive", "Model", "Name", "Price" },
                values: new object[] { new Guid("793aa38d-73dc-410e-8322-65ea1301dece"), null, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Intel Core i7-11800H\r\nNVIDIA GeForce RTX 3050 Ti\r\nот 16GB до 64GB DDR4\r\nот 512GB SSD NVMe до 2TB SSD NVMe", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6511/6511432_rd.jpg;maxHeight=640;maxWidth=550", false, "Msi", "MSI Katana GF76 11UD", 1800.00m });
        }
    }
}
