using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechShop.Data.Migrations
{
    public partial class AddedRolesAndAdminPanel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 10, 7, 3, 23, 575, DateTimeKind.Utc).AddTicks(7752),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 9, 11, 4, 43, 506, DateTimeKind.Utc).AddTicks(1880));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "LastEdit" },
                values: new object[] { new DateTime(2023, 8, 10, 10, 3, 23, 575, DateTimeKind.Local).AddTicks(9068), new DateTime(2023, 8, 10, 10, 3, 23, 575, DateTimeKind.Local).AddTicks(9132) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "LastEdit" },
                values: new object[] { new DateTime(2023, 8, 10, 10, 3, 23, 575, DateTimeKind.Local).AddTicks(9148), new DateTime(2023, 8, 10, 10, 3, 23, 575, DateTimeKind.Local).AddTicks(9150) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "LastEdit" },
                values: new object[] { new DateTime(2023, 8, 10, 10, 3, 23, 575, DateTimeKind.Local).AddTicks(9155), new DateTime(2023, 8, 10, 10, 3, 23, 575, DateTimeKind.Local).AddTicks(9157) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "LastEdit" },
                values: new object[] { new DateTime(2023, 8, 10, 10, 3, 23, 575, DateTimeKind.Local).AddTicks(9161), new DateTime(2023, 8, 10, 10, 3, 23, 575, DateTimeKind.Local).AddTicks(9163) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Products");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 9, 11, 4, 43, 506, DateTimeKind.Utc).AddTicks(1880),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 10, 7, 3, 23, 575, DateTimeKind.Utc).AddTicks(7752));

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
    }
}
