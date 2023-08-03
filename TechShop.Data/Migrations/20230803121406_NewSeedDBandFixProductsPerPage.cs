using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechShop.Data.Migrations
{
    public partial class NewSeedDBandFixProductsPerPage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("48ecaec5-d64b-4d80-ab6c-690e7ea5b31d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("69bb41d2-a27c-49de-8734-f181ca1fba81"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9af2cd8b-f065-4644-b0a6-a49fe5f3d34e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e4e92d81-1fac-4c78-8926-8fffeaa30877"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 3, 12, 14, 5, 593, DateTimeKind.Utc).AddTicks(4674),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 3, 11, 40, 14, 236, DateTimeKind.Utc).AddTicks(8180));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ApplicationUserId", "CategoryId", "Description", "ImageUrl", "Model", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("6003c8c9-4120-4809-9661-d388596edd84"), null, 3, "Intel Core i7-13700F\r\nNVIDIA GeForce RTX 4070 Ti\r\n32GB DDR5\r\nот 1TB SSD NVMe до 4TB (SSD NVMe и HDD)", "https://laptop.bg/system/images/413287/normal/Predator_Orion_7000_PO5_650.png", "Acer", "Predator Orion 5000 PO5-650", 2300.00m },
                    { new Guid("ac5d2ad0-5cb5-4aa0-ae6a-5180a3ccfcd3"), null, 1, "от Intel Core i9-13900K\r\nFull Water Loop\r\nGeForce RTX 4090\r\n64GB DDR5\r\nот 2TB Gen4 PCIe NVMe SSD", "https://laptop.bg/system/images/409277/normal/grigs_hyperion_by_alexma3x.png", "Asus", "ROG Hyperion", 5000.00m },
                    { new Guid("efe8eaad-2289-44aa-90a2-484728b952c0"), null, 2, "AMD Ryzen™ 7 4800H\r\nNVIDIA GeForce RTX 3050\r\nот 16GB до 64GB DDR4\r\nот 512GB SSD NVMe до 2512GB SSD NVMe", "https://laptop.bg/system/images/293133/normal/asus_rog_strix_g15_g513ichn004.jpg", "Asus", "ROG Strix G15 G513IC-HN004", 1900.00m },
                    { new Guid("f076f075-52e2-4779-8b64-9ae10991b118"), null, 2, "Intel Core i9-13980HX\r\nNVIDIA GeForce RTX 4090\r\n64GB DDR5\r\nот 2TB SSD NVMe до 4TB SSD NVMe", "https://laptop.bg/system/images/378257/normal/msi_titan_gt77_hx_13vi_9S717Q211055.png", "MSI", "Titan GT77 HX 13VI", 2800.00m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6003c8c9-4120-4809-9661-d388596edd84"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ac5d2ad0-5cb5-4aa0-ae6a-5180a3ccfcd3"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("efe8eaad-2289-44aa-90a2-484728b952c0"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f076f075-52e2-4779-8b64-9ae10991b118"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 3, 11, 40, 14, 236, DateTimeKind.Utc).AddTicks(8180),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 3, 12, 14, 5, 593, DateTimeKind.Utc).AddTicks(4674));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ApplicationUserId", "CategoryId", "CreatedOn", "Description", "ImageUrl", "IsActive", "Model", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("48ecaec5-d64b-4d80-ab6c-690e7ea5b31d"), null, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Intel Core i7-10750H\r\nNVIDIA GeForce RTX 2070\r\nот 8GB до 32GB DDR5\r\nот 512GB SSD NVMe до 2TB SSD NVMe", "https://laptopmedia.com/wp-content/uploads/2022/01/2-44.jpg", false, "Asus", "ASUS ROG Strix G15", 2500.00m },
                    { new Guid("69bb41d2-a27c-49de-8734-f181ca1fba81"), null, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Intel Core i5-1135G7\r\nIntel Iris Xe Graphics\r\nот 8GB до 40GB DDR4\r\nот 512GB SSD NVMe до 2TB SSD NVMe", "https://m.media-amazon.com/images/I/71ehzrGUO7L.jpg", false, "Asus", "ASUS Laptop L510 Ultra Thin Laptop", 1900.00m },
                    { new Guid("9af2cd8b-f065-4644-b0a6-a49fe5f3d34e"), null, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Intel Core i7-11800H\r\nNVIDIA GeForce RTX 3050 Ti\r\nот 16GB до 64GB DDR4\r\nот 512GB SSD NVMe до 2TB SSD NVMe", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6511/6511432_rd.jpg;maxHeight=640;maxWidth=550", false, "Msi", "MSI Katana GF76 11UD", 1800.00m },
                    { new Guid("e4e92d81-1fac-4c78-8926-8fffeaa30877"), null, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Intel Core i3-12100\r\nIntel UHD Graphics 730\r\nот 8GB до 32GB DDR4\r\nот 512GB SSD NVMe до 4TB (SSD и HDD)", "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6401/6401009_sd.jpg", false, "Lenovo", "Desktop Exteme configuration", 1300.00m }
                });
        }
    }
}
