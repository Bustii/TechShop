using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechShop.Data.Migrations
{
    public partial class AddedNewLaptopProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3670665d-5fee-4a70-a8ba-3f4e7fc4d2ee"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("83ec178e-9faa-4d8b-8b70-1340b477cd84"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9cec98da-c2a3-4f64-b079-faaca9c735c5"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 1, 9, 57, 6, 548, DateTimeKind.Utc).AddTicks(5306),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 1, 9, 46, 28, 467, DateTimeKind.Utc).AddTicks(7003));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ApplicationUserId", "CategoryId", "Description", "ImageUrl", "Model", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("1b89b797-46f3-49f4-bb5b-77fc34e08215"), null, 2, "Intel Core i7-11800H\r\nNVIDIA GeForce RTX 3050 Ti\r\nот 16GB до 64GB DDR4\r\nот 512GB SSD NVMe до 2TB SSD NVMe", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6511/6511432_rd.jpg;maxHeight=640;maxWidth=550", "Msi", "MSI Katana GF76 11UD", 1800.00m },
                    { new Guid("3ea43e44-e1b5-4db8-88b5-4499692cc0e1"), null, 2, "Intel Core i7-10750H\r\nNVIDIA GeForce RTX 2070\r\nот 8GB до 32GB DDR5\r\nот 512GB SSD NVMe до 2TB SSD NVMe", "https://laptopmedia.com/wp-content/uploads/2022/01/2-44.jpg;maxHeight=640;maxWidth=550", "Asus", "ASUS ROG Strix G15", 2500.00m },
                    { new Guid("93662544-c727-422c-977c-3bdd52c0355f"), null, 1, "Intel Core i3-12100\r\nIntel UHD Graphics 730\r\nот 8GB до 32GB DDR4\r\nот 512GB SSD NVMe до 4TB (SSD и HDD)", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6401/6401009_sd.jpg;maxHeight=640;maxWidth=550", "Lenovo", "Desktop Exteme configuration", 1300.00m },
                    { new Guid("9b070acf-337c-4168-a174-e6d2c0ddef93"), null, 2, "Intel Core i5-1135G7\r\nIntel Iris Xe Graphics\r\nот 8GB до 40GB DDR4\r\nот 512GB SSD NVMe до 2TB SSD NVMe", "https://m.media-amazon.com/images/S/aplus-media/vc/ae06dc73-29de-4d12-ae66-7082d7fa3a34.__CR0,0,1464,600_PT0_SX1464_V1___.jpg;maxHeight=640;maxWidth=550", "Asus", "ASUS Laptop L510 Ultra Thin Laptop", 1900.00m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("1b89b797-46f3-49f4-bb5b-77fc34e08215"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3ea43e44-e1b5-4db8-88b5-4499692cc0e1"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("93662544-c727-422c-977c-3bdd52c0355f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9b070acf-337c-4168-a174-e6d2c0ddef93"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 1, 9, 46, 28, 467, DateTimeKind.Utc).AddTicks(7003),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 1, 9, 57, 6, 548, DateTimeKind.Utc).AddTicks(5306));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ApplicationUserId", "CategoryId", "CreatedOn", "Description", "ImageUrl", "IsActive", "Model", "Name", "Price" },
                values: new object[] { new Guid("3670665d-5fee-4a70-a8ba-3f4e7fc4d2ee"), null, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Intel Core i3-12100\r\nIntel UHD Graphics 730\r\nот 8GB до 32GB DDR4\r\nот 512GB SSD NVMe до 4TB (SSD и HDD)", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6401/6401009_sd.jpg", false, "Lenovo", "Desktop Exteme configuration", 1300.00m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ApplicationUserId", "CategoryId", "CreatedOn", "Description", "ImageUrl", "IsActive", "Model", "Name", "Price" },
                values: new object[] { new Guid("83ec178e-9faa-4d8b-8b70-1340b477cd84"), null, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Intel Core i7-11800H\r\nNVIDIA GeForce RTX 3050 Ti\r\nот 16GB до 64GB DDR4\r\nот 512GB SSD NVMe до 2TB SSD NVMe", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6511/6511432_rd.jpg;maxHeight=640;maxWidth=550", false, "Msi", "MSI Katana GF76 11UD", 1800.00m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ApplicationUserId", "CategoryId", "CreatedOn", "Description", "ImageUrl", "IsActive", "Model", "Name", "Price" },
                values: new object[] { new Guid("9cec98da-c2a3-4f64-b079-faaca9c735c5"), null, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Intel Core i5-1135G7\r\nIntel Iris Xe Graphics\r\nот 8GB до 40GB DDR4\r\nот 512GB SSD NVMe до 2TB SSD NVMe", "https://m.media-amazon.com/images/S/aplus-media/vc/ae06dc73-29de-4d12-ae66-7082d7fa3a34.__CR0,0,1464,600_PT0_SX1464_V1___.jpg", false, "Asus", "ASUS Laptop L510 Ultra Thin Laptop", 1900.00m });
        }
    }
}
