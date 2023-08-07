using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechShop.Data.Migrations
{
    public partial class AddedCustomUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_AspNetUsers_ApplicationUserId",
                table: "Products");

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

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "Products",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_ApplicationUserId",
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
                oldDefaultValue: new DateTime(2023, 8, 3, 12, 14, 5, 593, DateTimeKind.Utc).AddTicks(4674));

            migrationBuilder.AddColumn<Guid>(
                name: "BuyerId",
                table: "Products",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "Test");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "Testov");

            migrationBuilder.CreateTable(
                name: "Buyers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buyers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Buyers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BuyerId", "CategoryId", "Description", "ImageUrl", "Model", "Name", "Price", "UserId" },
                values: new object[,]
                {
                    { new Guid("09b4c815-ed5a-4428-a461-b7b6497eac9f"), null, 2, "Intel Core i9-13980HX\r\nNVIDIA GeForce RTX 4090\r\n64GB DDR5\r\nот 2TB SSD NVMe до 4TB SSD NVMe", "https://laptop.bg/system/images/378257/normal/msi_titan_gt77_hx_13vi_9S717Q211055.png", "MSI", "Titan GT77 HX 13VI", 2800.00m, null },
                    { new Guid("1856c81f-d0f1-4f40-af8a-2dd6e9ce7ca9"), null, 1, "от Intel Core i9-13900K\r\nFull Water Loop\r\nGeForce RTX 4090\r\n64GB DDR5\r\nот 2TB Gen4 PCIe NVMe SSD", "https://laptop.bg/system/images/409277/normal/grigs_hyperion_by_alexma3x.png", "Asus", "ROG Hyperion", 5000.00m, null },
                    { new Guid("3369a01c-e5b9-463b-a140-caa60771c7b1"), null, 3, "Intel Core i7-13700F\r\nNVIDIA GeForce RTX 4070 Ti\r\n32GB DDR5\r\nот 1TB SSD NVMe до 4TB (SSD NVMe и HDD)", "https://laptop.bg/system/images/413287/normal/Predator_Orion_7000_PO5_650.png", "Acer", "Predator Orion 5000 PO5-650", 2300.00m, null },
                    { new Guid("b3648538-6521-4f35-8f24-24bfc5351d0c"), null, 2, "AMD Ryzen™ 7 4800H\r\nNVIDIA GeForce RTX 3050\r\nот 16GB до 64GB DDR4\r\nот 512GB SSD NVMe до 2512GB SSD NVMe", "https://laptop.bg/system/images/293133/normal/asus_rog_strix_g15_g513ichn004.jpg", "Asus", "ROG Strix G15 G513IC-HN004", 1900.00m, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_BuyerId",
                table: "Products",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_Buyers_UserId",
                table: "Buyers",
                column: "UserId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_AspNetUsers_UserId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Buyers_BuyerId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Buyers");

            migrationBuilder.DropIndex(
                name: "IX_Products_BuyerId",
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

            migrationBuilder.DropColumn(
                name: "BuyerId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Products",
                newName: "ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_UserId",
                table: "Products",
                newName: "IX_Products_ApplicationUserId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 3, 12, 14, 5, 593, DateTimeKind.Utc).AddTicks(4674),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 7, 13, 5, 6, 910, DateTimeKind.Utc).AddTicks(3162));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ApplicationUserId", "CategoryId", "CreatedOn", "Description", "ImageUrl", "IsActive", "Model", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("6003c8c9-4120-4809-9661-d388596edd84"), null, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Intel Core i7-13700F\r\nNVIDIA GeForce RTX 4070 Ti\r\n32GB DDR5\r\nот 1TB SSD NVMe до 4TB (SSD NVMe и HDD)", "https://laptop.bg/system/images/413287/normal/Predator_Orion_7000_PO5_650.png", false, "Acer", "Predator Orion 5000 PO5-650", 2300.00m },
                    { new Guid("ac5d2ad0-5cb5-4aa0-ae6a-5180a3ccfcd3"), null, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "от Intel Core i9-13900K\r\nFull Water Loop\r\nGeForce RTX 4090\r\n64GB DDR5\r\nот 2TB Gen4 PCIe NVMe SSD", "https://laptop.bg/system/images/409277/normal/grigs_hyperion_by_alexma3x.png", false, "Asus", "ROG Hyperion", 5000.00m },
                    { new Guid("efe8eaad-2289-44aa-90a2-484728b952c0"), null, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AMD Ryzen™ 7 4800H\r\nNVIDIA GeForce RTX 3050\r\nот 16GB до 64GB DDR4\r\nот 512GB SSD NVMe до 2512GB SSD NVMe", "https://laptop.bg/system/images/293133/normal/asus_rog_strix_g15_g513ichn004.jpg", false, "Asus", "ROG Strix G15 G513IC-HN004", 1900.00m },
                    { new Guid("f076f075-52e2-4779-8b64-9ae10991b118"), null, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Intel Core i9-13980HX\r\nNVIDIA GeForce RTX 4090\r\n64GB DDR5\r\nот 2TB SSD NVMe до 4TB SSD NVMe", "https://laptop.bg/system/images/378257/normal/msi_titan_gt77_hx_13vi_9S717Q211055.png", false, "MSI", "Titan GT77 HX 13VI", 2800.00m }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Products_AspNetUsers_ApplicationUserId",
                table: "Products",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
