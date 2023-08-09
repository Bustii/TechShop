using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechShop.Data.Migrations
{
    public partial class InitialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                defaultValue: new DateTime(2023, 8, 9, 8, 3, 3, 890, DateTimeKind.Utc).AddTicks(2384),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "LastEdit" },
                values: new object[] { new DateTime(2023, 8, 9, 11, 3, 3, 890, DateTimeKind.Local).AddTicks(3602), new DateTime(2023, 8, 9, 11, 3, 3, 890, DateTimeKind.Local).AddTicks(3650) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "LastEdit" },
                values: new object[] { new DateTime(2023, 8, 9, 11, 3, 3, 890, DateTimeKind.Local).AddTicks(3667), new DateTime(2023, 8, 9, 11, 3, 3, 890, DateTimeKind.Local).AddTicks(3669) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "LastEdit" },
                values: new object[] { new DateTime(2023, 8, 9, 11, 3, 3, 890, DateTimeKind.Local).AddTicks(3675), new DateTime(2023, 8, 9, 11, 3, 3, 890, DateTimeKind.Local).AddTicks(3677) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "LastEdit" },
                values: new object[] { new DateTime(2023, 8, 9, 11, 3, 3, 890, DateTimeKind.Local).AddTicks(3682), new DateTime(2023, 8, 9, 11, 3, 3, 890, DateTimeKind.Local).AddTicks(3685) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                oldDefaultValue: new DateTime(2023, 8, 9, 8, 3, 3, 890, DateTimeKind.Utc).AddTicks(2384));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "LastEdit" },
                values: new object[] { new DateTime(2023, 8, 9, 10, 49, 25, 472, DateTimeKind.Local).AddTicks(7210), new DateTime(2023, 8, 9, 10, 49, 25, 472, DateTimeKind.Local).AddTicks(7249) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "LastEdit" },
                values: new object[] { new DateTime(2023, 8, 9, 10, 49, 25, 472, DateTimeKind.Local).AddTicks(7262), new DateTime(2023, 8, 9, 10, 49, 25, 472, DateTimeKind.Local).AddTicks(7264) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "LastEdit" },
                values: new object[] { new DateTime(2023, 8, 9, 10, 49, 25, 472, DateTimeKind.Local).AddTicks(7267), new DateTime(2023, 8, 9, 10, 49, 25, 472, DateTimeKind.Local).AddTicks(7269) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "LastEdit" },
                values: new object[] { new DateTime(2023, 8, 9, 10, 49, 25, 472, DateTimeKind.Local).AddTicks(7271), new DateTime(2023, 8, 9, 10, 49, 25, 472, DateTimeKind.Local).AddTicks(7273) });
        }
    }
}
