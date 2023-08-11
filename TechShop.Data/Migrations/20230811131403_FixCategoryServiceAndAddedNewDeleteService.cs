using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechShop.Data.Migrations
{
    public partial class FixCategoryServiceAndAddedNewDeleteService : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 11, 13, 14, 2, 640, DateTimeKind.Utc).AddTicks(5372),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 11, 11, 38, 7, 471, DateTimeKind.Utc).AddTicks(243));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "LastEdit" },
                values: new object[] { new DateTime(2023, 8, 11, 16, 14, 2, 640, DateTimeKind.Local).AddTicks(6748), new DateTime(2023, 8, 11, 16, 14, 2, 640, DateTimeKind.Local).AddTicks(6836) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "LastEdit" },
                values: new object[] { new DateTime(2023, 8, 11, 16, 14, 2, 640, DateTimeKind.Local).AddTicks(6858), new DateTime(2023, 8, 11, 16, 14, 2, 640, DateTimeKind.Local).AddTicks(6861) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "LastEdit" },
                values: new object[] { new DateTime(2023, 8, 11, 16, 14, 2, 640, DateTimeKind.Local).AddTicks(6868), new DateTime(2023, 8, 11, 16, 14, 2, 640, DateTimeKind.Local).AddTicks(6870) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "LastEdit" },
                values: new object[] { new DateTime(2023, 8, 11, 16, 14, 2, 640, DateTimeKind.Local).AddTicks(6880), new DateTime(2023, 8, 11, 16, 14, 2, 640, DateTimeKind.Local).AddTicks(6882) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 11, 11, 38, 7, 471, DateTimeKind.Utc).AddTicks(243),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 11, 13, 14, 2, 640, DateTimeKind.Utc).AddTicks(5372));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "LastEdit" },
                values: new object[] { new DateTime(2023, 8, 11, 14, 38, 7, 471, DateTimeKind.Local).AddTicks(1826), new DateTime(2023, 8, 11, 14, 38, 7, 471, DateTimeKind.Local).AddTicks(1873) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "LastEdit" },
                values: new object[] { new DateTime(2023, 8, 11, 14, 38, 7, 471, DateTimeKind.Local).AddTicks(1891), new DateTime(2023, 8, 11, 14, 38, 7, 471, DateTimeKind.Local).AddTicks(1893) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "LastEdit" },
                values: new object[] { new DateTime(2023, 8, 11, 14, 38, 7, 471, DateTimeKind.Local).AddTicks(1898), new DateTime(2023, 8, 11, 14, 38, 7, 471, DateTimeKind.Local).AddTicks(1901) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "LastEdit" },
                values: new object[] { new DateTime(2023, 8, 11, 14, 38, 7, 471, DateTimeKind.Local).AddTicks(1905), new DateTime(2023, 8, 11, 14, 38, 7, 471, DateTimeKind.Local).AddTicks(1908) });
        }
    }
}
