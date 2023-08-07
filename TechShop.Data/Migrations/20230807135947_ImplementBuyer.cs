using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechShop.Data.Migrations
{
    public partial class ImplementBuyer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_AspNetUsers_UserId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Buyers_BuyerId",
                table: "Products");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("09b4c815-ed5a-4428-a461-b7b6497eac9f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("1856c81f-d0f1-4f40-af8a-2dd6e9ce7ca9"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3369a01c-e5b9-463b-a140-caa60771c7b1"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b3648538-6521-4f35-8f24-24bfc5351d0c"));

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Products",
                newName: "BuyerId2");

            migrationBuilder.RenameIndex(
                name: "IX_Products_UserId",
                table: "Products",
                newName: "IX_Products_BuyerId2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 7, 13, 59, 47, 179, DateTimeKind.Utc).AddTicks(4675),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 7, 13, 5, 6, 910, DateTimeKind.Utc).AddTicks(3162));

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "Minev",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldDefaultValue: "Testov");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "Ventsislav",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldDefaultValue: "Test");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BuyerId", "BuyerId2", "CategoryId", "Description", "ImageUrl", "Model", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("05ba4165-7488-475d-a229-b62d444c30e4"), null, null, 2, "Intel Core i9-13980HX\r\nNVIDIA GeForce RTX 4090\r\n64GB DDR5\r\nот 2TB SSD NVMe до 4TB SSD NVMe", "https://laptop.bg/system/images/378257/normal/msi_titan_gt77_hx_13vi_9S717Q211055.png", "MSI", "Titan GT77 HX 13VI", 2800.00m },
                    { new Guid("12c81ac6-07ce-4da5-be03-1b9d3aa01fa3"), null, null, 1, "от Intel Core i9-13900K\r\nFull Water Loop\r\nGeForce RTX 4090\r\n64GB DDR5\r\nот 2TB Gen4 PCIe NVMe SSD", "https://laptop.bg/system/images/409277/normal/grigs_hyperion_by_alexma3x.png", "Asus", "ROG Hyperion", 5000.00m },
                    { new Guid("179fd5cd-80b6-4ab4-a645-ad07ddb7b776"), null, null, 2, "AMD Ryzen™ 7 4800H\r\nNVIDIA GeForce RTX 3050\r\nот 16GB до 64GB DDR4\r\nот 512GB SSD NVMe до 2512GB SSD NVMe", "https://laptop.bg/system/images/293133/normal/asus_rog_strix_g15_g513ichn004.jpg", "Asus", "ROG Strix G15 G513IC-HN004", 1900.00m },
                    { new Guid("f05a7c70-8d6a-44c3-8afb-767e431c4ae7"), new Guid("3561c2dc-ec6f-4f8e-90eb-f0a37c776e50"), null, 3, "Intel Core i7-13700F\r\nNVIDIA GeForce RTX 4070 Ti\r\n32GB DDR5\r\nот 1TB SSD NVMe до 4TB (SSD NVMe и HDD)", "https://laptop.bg/system/images/413287/normal/Predator_Orion_7000_PO5_650.png", "Acer", "Predator Orion 5000 PO5-650", 2300.00m }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Products_AspNetUsers_BuyerId",
                table: "Products",
                column: "BuyerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Buyers_BuyerId2",
                table: "Products",
                column: "BuyerId2",
                principalTable: "Buyers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_AspNetUsers_BuyerId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Buyers_BuyerId2",
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

            migrationBuilder.RenameColumn(
                name: "BuyerId2",
                table: "Products",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_BuyerId2",
                table: "Products",
                newName: "IX_Products_UserId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 7, 13, 5, 6, 910, DateTimeKind.Utc).AddTicks(3162),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 7, 13, 59, 47, 179, DateTimeKind.Utc).AddTicks(4675));

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "Testov",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldDefaultValue: "Minev");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "Test",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldDefaultValue: "Ventsislav");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BuyerId", "CategoryId", "CreatedOn", "Description", "ImageUrl", "IsActive", "Model", "Name", "Price", "UserId" },
                values: new object[,]
                {
                    { new Guid("09b4c815-ed5a-4428-a461-b7b6497eac9f"), null, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Intel Core i9-13980HX\r\nNVIDIA GeForce RTX 4090\r\n64GB DDR5\r\nот 2TB SSD NVMe до 4TB SSD NVMe", "https://laptop.bg/system/images/378257/normal/msi_titan_gt77_hx_13vi_9S717Q211055.png", false, "MSI", "Titan GT77 HX 13VI", 2800.00m, null },
                    { new Guid("1856c81f-d0f1-4f40-af8a-2dd6e9ce7ca9"), null, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "от Intel Core i9-13900K\r\nFull Water Loop\r\nGeForce RTX 4090\r\n64GB DDR5\r\nот 2TB Gen4 PCIe NVMe SSD", "https://laptop.bg/system/images/409277/normal/grigs_hyperion_by_alexma3x.png", false, "Asus", "ROG Hyperion", 5000.00m, null },
                    { new Guid("3369a01c-e5b9-463b-a140-caa60771c7b1"), null, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Intel Core i7-13700F\r\nNVIDIA GeForce RTX 4070 Ti\r\n32GB DDR5\r\nот 1TB SSD NVMe до 4TB (SSD NVMe и HDD)", "https://laptop.bg/system/images/413287/normal/Predator_Orion_7000_PO5_650.png", false, "Acer", "Predator Orion 5000 PO5-650", 2300.00m, null },
                    { new Guid("b3648538-6521-4f35-8f24-24bfc5351d0c"), null, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AMD Ryzen™ 7 4800H\r\nNVIDIA GeForce RTX 3050\r\nот 16GB до 64GB DDR4\r\nот 512GB SSD NVMe до 2512GB SSD NVMe", "https://laptop.bg/system/images/293133/normal/asus_rog_strix_g15_g513ichn004.jpg", false, "Asus", "ROG Strix G15 G513IC-HN004", 1900.00m, null }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Products_AspNetUsers_UserId",
                table: "Products",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Buyers_BuyerId",
                table: "Products",
                column: "BuyerId",
                principalTable: "Buyers",
                principalColumn: "Id");
        }
    }
}
