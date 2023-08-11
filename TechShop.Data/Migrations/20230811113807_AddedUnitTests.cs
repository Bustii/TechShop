using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechShop.Data.Migrations
{
    public partial class AddedUnitTests : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 11, 11, 38, 7, 471, DateTimeKind.Utc).AddTicks(243),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 10, 14, 18, 34, 329, DateTimeKind.Utc).AddTicks(2178));

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 10, 14, 18, 34, 329, DateTimeKind.Utc).AddTicks(2178),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 11, 11, 38, 7, 471, DateTimeKind.Utc).AddTicks(243));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "LastEdit" },
                values: new object[] { new DateTime(2023, 8, 10, 17, 18, 34, 329, DateTimeKind.Local).AddTicks(3425), new DateTime(2023, 8, 10, 17, 18, 34, 329, DateTimeKind.Local).AddTicks(3458) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "LastEdit" },
                values: new object[] { new DateTime(2023, 8, 10, 17, 18, 34, 329, DateTimeKind.Local).AddTicks(3476), new DateTime(2023, 8, 10, 17, 18, 34, 329, DateTimeKind.Local).AddTicks(3477) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "LastEdit" },
                values: new object[] { new DateTime(2023, 8, 10, 17, 18, 34, 329, DateTimeKind.Local).AddTicks(3481), new DateTime(2023, 8, 10, 17, 18, 34, 329, DateTimeKind.Local).AddTicks(3482) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "LastEdit" },
                values: new object[] { new DateTime(2023, 8, 10, 17, 18, 34, 329, DateTimeKind.Local).AddTicks(3485), new DateTime(2023, 8, 10, 17, 18, 34, 329, DateTimeKind.Local).AddTicks(3486) });
        }
    }
}
