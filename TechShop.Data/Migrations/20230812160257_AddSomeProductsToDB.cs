using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechShop.Data.Migrations
{
    public partial class AddSomeProductsToDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 12, 16, 2, 56, 846, DateTimeKind.Utc).AddTicks(4727),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 12, 15, 58, 34, 496, DateTimeKind.Utc).AddTicks(7376));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "LastEdit" },
                values: new object[] { new DateTime(2023, 8, 12, 19, 2, 56, 846, DateTimeKind.Local).AddTicks(5495), new DateTime(2023, 8, 12, 19, 2, 56, 846, DateTimeKind.Local).AddTicks(5531) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "LastEdit" },
                values: new object[] { new DateTime(2023, 8, 12, 19, 2, 56, 846, DateTimeKind.Local).AddTicks(5543), new DateTime(2023, 8, 12, 19, 2, 56, 846, DateTimeKind.Local).AddTicks(5544) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "LastEdit" },
                values: new object[] { new DateTime(2023, 8, 12, 19, 2, 56, 846, DateTimeKind.Local).AddTicks(5547), new DateTime(2023, 8, 12, 19, 2, 56, 846, DateTimeKind.Local).AddTicks(5549) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "LastEdit" },
                values: new object[] { new DateTime(2023, 8, 12, 19, 2, 56, 846, DateTimeKind.Local).AddTicks(5551), new DateTime(2023, 8, 12, 19, 2, 56, 846, DateTimeKind.Local).AddTicks(5553) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "LastEdit" },
                values: new object[] { new DateTime(2023, 8, 12, 19, 2, 56, 846, DateTimeKind.Local).AddTicks(5558), new DateTime(2023, 8, 12, 19, 2, 56, 846, DateTimeKind.Local).AddTicks(5560) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "LastEdit" },
                values: new object[] { new DateTime(2023, 8, 12, 19, 2, 56, 846, DateTimeKind.Local).AddTicks(5562), new DateTime(2023, 8, 12, 19, 2, 56, 846, DateTimeKind.Local).AddTicks(5564) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedOn", "LastEdit" },
                values: new object[] { new DateTime(2023, 8, 12, 19, 2, 56, 846, DateTimeKind.Local).AddTicks(5566), new DateTime(2023, 8, 12, 19, 2, 56, 846, DateTimeKind.Local).AddTicks(5568) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedOn", "LastEdit" },
                values: new object[] { new DateTime(2023, 8, 12, 19, 2, 56, 846, DateTimeKind.Local).AddTicks(5596), new DateTime(2023, 8, 12, 19, 2, 56, 846, DateTimeKind.Local).AddTicks(5598) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedOn", "LastEdit" },
                values: new object[] { new DateTime(2023, 8, 12, 19, 2, 56, 846, DateTimeKind.Local).AddTicks(5603), new DateTime(2023, 8, 12, 19, 2, 56, 846, DateTimeKind.Local).AddTicks(5604) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedOn", "LastEdit" },
                values: new object[] { new DateTime(2023, 8, 12, 19, 2, 56, 846, DateTimeKind.Local).AddTicks(5607), new DateTime(2023, 8, 12, 19, 2, 56, 846, DateTimeKind.Local).AddTicks(5608) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedOn", "LastEdit" },
                values: new object[] { new DateTime(2023, 8, 12, 19, 2, 56, 846, DateTimeKind.Local).AddTicks(5611), new DateTime(2023, 8, 12, 19, 2, 56, 846, DateTimeKind.Local).AddTicks(5612) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedOn", "LastEdit" },
                values: new object[] { new DateTime(2023, 8, 12, 19, 2, 56, 846, DateTimeKind.Local).AddTicks(5615), new DateTime(2023, 8, 12, 19, 2, 56, 846, DateTimeKind.Local).AddTicks(5616) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedOn", "LastEdit" },
                values: new object[] { new DateTime(2023, 8, 12, 19, 2, 56, 846, DateTimeKind.Local).AddTicks(5619), new DateTime(2023, 8, 12, 19, 2, 56, 846, DateTimeKind.Local).AddTicks(5620) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedOn", "LastEdit" },
                values: new object[] { new DateTime(2023, 8, 12, 19, 2, 56, 846, DateTimeKind.Local).AddTicks(5623), new DateTime(2023, 8, 12, 19, 2, 56, 846, DateTimeKind.Local).AddTicks(5624) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedOn", "LastEdit" },
                values: new object[] { new DateTime(2023, 8, 12, 19, 2, 56, 846, DateTimeKind.Local).AddTicks(5627), new DateTime(2023, 8, 12, 19, 2, 56, 846, DateTimeKind.Local).AddTicks(5628) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedOn", "LastEdit" },
                values: new object[] { new DateTime(2023, 8, 12, 19, 2, 56, 846, DateTimeKind.Local).AddTicks(5631), new DateTime(2023, 8, 12, 19, 2, 56, 846, DateTimeKind.Local).AddTicks(5632) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedOn", "LastEdit" },
                values: new object[] { new DateTime(2023, 8, 12, 19, 2, 56, 846, DateTimeKind.Local).AddTicks(5635), new DateTime(2023, 8, 12, 19, 2, 56, 846, DateTimeKind.Local).AddTicks(5636) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedOn", "LastEdit" },
                values: new object[] { new DateTime(2023, 8, 12, 19, 2, 56, 846, DateTimeKind.Local).AddTicks(5639), new DateTime(2023, 8, 12, 19, 2, 56, 846, DateTimeKind.Local).AddTicks(5641) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedOn", "LastEdit" },
                values: new object[] { new DateTime(2023, 8, 12, 19, 2, 56, 846, DateTimeKind.Local).AddTicks(5645), new DateTime(2023, 8, 12, 19, 2, 56, 846, DateTimeKind.Local).AddTicks(5647) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedOn", "LastEdit" },
                values: new object[] { new DateTime(2023, 8, 12, 19, 2, 56, 846, DateTimeKind.Local).AddTicks(5650), new DateTime(2023, 8, 12, 19, 2, 56, 846, DateTimeKind.Local).AddTicks(5651) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedOn", "LastEdit" },
                values: new object[] { new DateTime(2023, 8, 12, 19, 2, 56, 846, DateTimeKind.Local).AddTicks(5653), new DateTime(2023, 8, 12, 19, 2, 56, 846, DateTimeKind.Local).AddTicks(5655) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 12, 15, 58, 34, 496, DateTimeKind.Utc).AddTicks(7376),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 12, 16, 2, 56, 846, DateTimeKind.Utc).AddTicks(4727));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "LastEdit" },
                values: new object[] { new DateTime(2023, 8, 12, 18, 58, 34, 496, DateTimeKind.Local).AddTicks(8523), new DateTime(2023, 8, 12, 18, 58, 34, 496, DateTimeKind.Local).AddTicks(8559) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "LastEdit" },
                values: new object[] { new DateTime(2023, 8, 12, 18, 58, 34, 496, DateTimeKind.Local).AddTicks(8571), new DateTime(2023, 8, 12, 18, 58, 34, 496, DateTimeKind.Local).AddTicks(8573) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "LastEdit" },
                values: new object[] { new DateTime(2023, 8, 12, 18, 58, 34, 496, DateTimeKind.Local).AddTicks(8576), new DateTime(2023, 8, 12, 18, 58, 34, 496, DateTimeKind.Local).AddTicks(8578) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "LastEdit" },
                values: new object[] { new DateTime(2023, 8, 12, 18, 58, 34, 496, DateTimeKind.Local).AddTicks(8580), new DateTime(2023, 8, 12, 18, 58, 34, 496, DateTimeKind.Local).AddTicks(8582) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedOn", "LastEdit" },
                values: new object[] { new DateTime(2023, 8, 12, 18, 58, 34, 496, DateTimeKind.Local).AddTicks(8588), new DateTime(2023, 8, 12, 18, 58, 34, 496, DateTimeKind.Local).AddTicks(8590) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedOn", "LastEdit" },
                values: new object[] { new DateTime(2023, 8, 12, 18, 58, 34, 496, DateTimeKind.Local).AddTicks(8593), new DateTime(2023, 8, 12, 18, 58, 34, 496, DateTimeKind.Local).AddTicks(8594) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedOn", "LastEdit" },
                values: new object[] { new DateTime(2023, 8, 12, 18, 58, 34, 496, DateTimeKind.Local).AddTicks(8597), new DateTime(2023, 8, 12, 18, 58, 34, 496, DateTimeKind.Local).AddTicks(8598) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedOn", "LastEdit" },
                values: new object[] { new DateTime(2023, 8, 12, 18, 58, 34, 496, DateTimeKind.Local).AddTicks(8601), new DateTime(2023, 8, 12, 18, 58, 34, 496, DateTimeKind.Local).AddTicks(8602) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedOn", "LastEdit" },
                values: new object[] { new DateTime(2023, 8, 12, 18, 58, 34, 496, DateTimeKind.Local).AddTicks(8606), new DateTime(2023, 8, 12, 18, 58, 34, 496, DateTimeKind.Local).AddTicks(8607) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedOn", "LastEdit" },
                values: new object[] { new DateTime(2023, 8, 12, 18, 58, 34, 496, DateTimeKind.Local).AddTicks(8610), new DateTime(2023, 8, 12, 18, 58, 34, 496, DateTimeKind.Local).AddTicks(8611) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedOn", "LastEdit" },
                values: new object[] { new DateTime(2023, 8, 12, 18, 58, 34, 496, DateTimeKind.Local).AddTicks(8614), new DateTime(2023, 8, 12, 18, 58, 34, 496, DateTimeKind.Local).AddTicks(8615) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedOn", "LastEdit" },
                values: new object[] { new DateTime(2023, 8, 12, 18, 58, 34, 496, DateTimeKind.Local).AddTicks(8618), new DateTime(2023, 8, 12, 18, 58, 34, 496, DateTimeKind.Local).AddTicks(8619) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedOn", "LastEdit" },
                values: new object[] { new DateTime(2023, 8, 12, 18, 58, 34, 496, DateTimeKind.Local).AddTicks(8622), new DateTime(2023, 8, 12, 18, 58, 34, 496, DateTimeKind.Local).AddTicks(8623) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedOn", "LastEdit" },
                values: new object[] { new DateTime(2023, 8, 12, 18, 58, 34, 496, DateTimeKind.Local).AddTicks(8627), new DateTime(2023, 8, 12, 18, 58, 34, 496, DateTimeKind.Local).AddTicks(8628) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedOn", "LastEdit" },
                values: new object[] { new DateTime(2023, 8, 12, 18, 58, 34, 496, DateTimeKind.Local).AddTicks(8631), new DateTime(2023, 8, 12, 18, 58, 34, 496, DateTimeKind.Local).AddTicks(8632) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedOn", "LastEdit" },
                values: new object[] { new DateTime(2023, 8, 12, 18, 58, 34, 496, DateTimeKind.Local).AddTicks(8635), new DateTime(2023, 8, 12, 18, 58, 34, 496, DateTimeKind.Local).AddTicks(8636) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedOn", "LastEdit" },
                values: new object[] { new DateTime(2023, 8, 12, 18, 58, 34, 496, DateTimeKind.Local).AddTicks(8639), new DateTime(2023, 8, 12, 18, 58, 34, 496, DateTimeKind.Local).AddTicks(8641) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedOn", "LastEdit" },
                values: new object[] { new DateTime(2023, 8, 12, 18, 58, 34, 496, DateTimeKind.Local).AddTicks(8644), new DateTime(2023, 8, 12, 18, 58, 34, 496, DateTimeKind.Local).AddTicks(8645) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedOn", "LastEdit" },
                values: new object[] { new DateTime(2023, 8, 12, 18, 58, 34, 496, DateTimeKind.Local).AddTicks(8649), new DateTime(2023, 8, 12, 18, 58, 34, 496, DateTimeKind.Local).AddTicks(8651) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedOn", "LastEdit" },
                values: new object[] { new DateTime(2023, 8, 12, 18, 58, 34, 496, DateTimeKind.Local).AddTicks(8653), new DateTime(2023, 8, 12, 18, 58, 34, 496, DateTimeKind.Local).AddTicks(8655) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedOn", "LastEdit" },
                values: new object[] { new DateTime(2023, 8, 12, 18, 58, 34, 496, DateTimeKind.Local).AddTicks(8657), new DateTime(2023, 8, 12, 18, 58, 34, 496, DateTimeKind.Local).AddTicks(8658) });
        }
    }
}
