using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechShop.Data.Migrations
{
    public partial class addedNewColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 9, 10, 43, 0, 490, DateTimeKind.Utc).AddTicks(3287),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 9, 8, 3, 3, 890, DateTimeKind.Utc).AddTicks(2384));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Categories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 9, 8, 3, 3, 890, DateTimeKind.Utc).AddTicks(2384),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 9, 10, 43, 0, 490, DateTimeKind.Utc).AddTicks(3287));

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
    }
}
