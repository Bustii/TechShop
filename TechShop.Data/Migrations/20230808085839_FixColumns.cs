using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechShop.Data.Migrations
{
    public partial class FixColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Buyers_BuyerId2",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_BuyerId2",
                table: "Products");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("05ba4165-7488-475d-a229-b62d444c30e4"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("12c81ac6-07ce-4da5-be03-1b9d3aa01fa3"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("179fd5cd-80b6-4ab4-a645-ad07ddb7b776"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f05a7c70-8d6a-44c3-8afb-767e431c4ae7"));

            migrationBuilder.DropColumn(
                name: "BuyerId2",
                table: "Products");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 8, 8, 58, 38, 594, DateTimeKind.Utc).AddTicks(3685),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 7, 13, 59, 47, 179, DateTimeKind.Utc).AddTicks(4675));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BuyerId", "CategoryId", "Description", "ImageUrl", "Model", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("5fdf38b5-5f89-468f-89e2-14a967a44e8e"), null, 2, "AMD Ryzen™ 7 4800H\r\nNVIDIA GeForce RTX 3050\r\nот 16GB до 64GB DDR4\r\nот 512GB SSD NVMe до 2512GB SSD NVMe", "https://laptop.bg/system/images/293133/normal/asus_rog_strix_g15_g513ichn004.jpg", "Asus", "ROG Strix G15 G513IC-HN004", 1900.00m },
                    { new Guid("666125fb-72c5-49d6-bb1a-6f09e3d03eeb"), new Guid("3561c2dc-ec6f-4f8e-90eb-f0a37c776e50"), 3, "Intel Core i7-13700F\r\nNVIDIA GeForce RTX 4070 Ti\r\n32GB DDR5\r\nот 1TB SSD NVMe до 4TB (SSD NVMe и HDD)", "https://laptop.bg/system/images/413287/normal/Predator_Orion_7000_PO5_650.png", "Acer", "Predator Orion 5000 PO5-650", 2300.00m },
                    { new Guid("7cfb5e2b-7943-4b16-be13-0f3945b42210"), null, 1, "от Intel Core i9-13900K\r\nFull Water Loop\r\nGeForce RTX 4090\r\n64GB DDR5\r\nот 2TB Gen4 PCIe NVMe SSD", "https://laptop.bg/system/images/409277/normal/grigs_hyperion_by_alexma3x.png", "Asus", "ROG Hyperion", 5000.00m },
                    { new Guid("d76e90e9-d244-43d2-934b-e471e2191acb"), null, 2, "Intel Core i9-13980HX\r\nNVIDIA GeForce RTX 4090\r\n64GB DDR5\r\nот 2TB SSD NVMe до 4TB SSD NVMe", "https://laptop.bg/system/images/378257/normal/msi_titan_gt77_hx_13vi_9S717Q211055.png", "MSI", "Titan GT77 HX 13VI", 2800.00m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("5fdf38b5-5f89-468f-89e2-14a967a44e8e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("666125fb-72c5-49d6-bb1a-6f09e3d03eeb"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7cfb5e2b-7943-4b16-be13-0f3945b42210"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d76e90e9-d244-43d2-934b-e471e2191acb"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 7, 13, 59, 47, 179, DateTimeKind.Utc).AddTicks(4675),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 8, 8, 58, 38, 594, DateTimeKind.Utc).AddTicks(3685));

            migrationBuilder.AddColumn<Guid>(
                name: "BuyerId2",
                table: "Products",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BuyerId", "BuyerId2", "CategoryId", "CreatedOn", "Description", "ImageUrl", "IsActive", "Model", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("05ba4165-7488-475d-a229-b62d444c30e4"), null, null, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Intel Core i9-13980HX\r\nNVIDIA GeForce RTX 4090\r\n64GB DDR5\r\nот 2TB SSD NVMe до 4TB SSD NVMe", "https://laptop.bg/system/images/378257/normal/msi_titan_gt77_hx_13vi_9S717Q211055.png", false, "MSI", "Titan GT77 HX 13VI", 2800.00m },
                    { new Guid("12c81ac6-07ce-4da5-be03-1b9d3aa01fa3"), null, null, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "от Intel Core i9-13900K\r\nFull Water Loop\r\nGeForce RTX 4090\r\n64GB DDR5\r\nот 2TB Gen4 PCIe NVMe SSD", "https://laptop.bg/system/images/409277/normal/grigs_hyperion_by_alexma3x.png", false, "Asus", "ROG Hyperion", 5000.00m },
                    { new Guid("179fd5cd-80b6-4ab4-a645-ad07ddb7b776"), null, null, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AMD Ryzen™ 7 4800H\r\nNVIDIA GeForce RTX 3050\r\nот 16GB до 64GB DDR4\r\nот 512GB SSD NVMe до 2512GB SSD NVMe", "https://laptop.bg/system/images/293133/normal/asus_rog_strix_g15_g513ichn004.jpg", false, "Asus", "ROG Strix G15 G513IC-HN004", 1900.00m },
                    { new Guid("f05a7c70-8d6a-44c3-8afb-767e431c4ae7"), new Guid("3561c2dc-ec6f-4f8e-90eb-f0a37c776e50"), null, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Intel Core i7-13700F\r\nNVIDIA GeForce RTX 4070 Ti\r\n32GB DDR5\r\nот 1TB SSD NVMe до 4TB (SSD NVMe и HDD)", "https://laptop.bg/system/images/413287/normal/Predator_Orion_7000_PO5_650.png", false, "Acer", "Predator Orion 5000 PO5-650", 2300.00m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_BuyerId2",
                table: "Products",
                column: "BuyerId2");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Buyers_BuyerId2",
                table: "Products",
                column: "BuyerId2",
                principalTable: "Buyers",
                principalColumn: "Id");
        }
    }
}
