using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechShop.Data.Migrations
{
    public partial class AddedShopCart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 9, 11, 4, 43, 506, DateTimeKind.Utc).AddTicks(1880),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 9, 10, 43, 0, 490, DateTimeKind.Utc).AddTicks(3287));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "LastEdit" },
                values: new object[] { new DateTime(2023, 8, 9, 14, 4, 43, 506, DateTimeKind.Local).AddTicks(3315), new DateTime(2023, 8, 9, 14, 4, 43, 506, DateTimeKind.Local).AddTicks(3368) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "LastEdit" },
                values: new object[] { new DateTime(2023, 8, 9, 14, 4, 43, 506, DateTimeKind.Local).AddTicks(3395), new DateTime(2023, 8, 9, 14, 4, 43, 506, DateTimeKind.Local).AddTicks(3398) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "LastEdit" },
                values: new object[] { new DateTime(2023, 8, 9, 14, 4, 43, 506, DateTimeKind.Local).AddTicks(3403), new DateTime(2023, 8, 9, 14, 4, 43, 506, DateTimeKind.Local).AddTicks(3405) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "LastEdit" },
                values: new object[] { new DateTime(2023, 8, 9, 14, 4, 43, 506, DateTimeKind.Local).AddTicks(3410), new DateTime(2023, 8, 9, 14, 4, 43, 506, DateTimeKind.Local).AddTicks(3412) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 9, 10, 43, 0, 490, DateTimeKind.Utc).AddTicks(3287),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 9, 11, 4, 43, 506, DateTimeKind.Utc).AddTicks(1880));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "LastEdit" },
                values: new object[] { new DateTime(2023, 8, 9, 13, 43, 0, 490, DateTimeKind.Local).AddTicks(4558), new DateTime(2023, 8, 9, 13, 43, 0, 490, DateTimeKind.Local).AddTicks(4605) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "LastEdit" },
                values: new object[] { new DateTime(2023, 8, 9, 13, 43, 0, 490, DateTimeKind.Local).AddTicks(4620), new DateTime(2023, 8, 9, 13, 43, 0, 490, DateTimeKind.Local).AddTicks(4621) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "LastEdit" },
                values: new object[] { new DateTime(2023, 8, 9, 13, 43, 0, 490, DateTimeKind.Local).AddTicks(4624), new DateTime(2023, 8, 9, 13, 43, 0, 490, DateTimeKind.Local).AddTicks(4626) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "LastEdit" },
                values: new object[] { new DateTime(2023, 8, 9, 13, 43, 0, 490, DateTimeKind.Local).AddTicks(4629), new DateTime(2023, 8, 9, 13, 43, 0, 490, DateTimeKind.Local).AddTicks(4630) });
        }
    }
}
