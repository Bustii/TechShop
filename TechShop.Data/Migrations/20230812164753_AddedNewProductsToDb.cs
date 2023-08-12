using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechShop.Data.Migrations
{
    public partial class AddedNewProductsToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 12, 16, 47, 53, 197, DateTimeKind.Utc).AddTicks(2611),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 12, 16, 46, 32, 693, DateTimeKind.Utc).AddTicks(425));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "LastEdit" },
                values: new object[] { new DateTime(2023, 8, 12, 19, 47, 53, 197, DateTimeKind.Local).AddTicks(3650), new DateTime(2023, 8, 12, 19, 47, 53, 197, DateTimeKind.Local).AddTicks(3696) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "LastEdit" },
                values: new object[] { new DateTime(2023, 8, 12, 19, 47, 53, 197, DateTimeKind.Local).AddTicks(3711), new DateTime(2023, 8, 12, 19, 47, 53, 197, DateTimeKind.Local).AddTicks(3714) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "LastEdit" },
                values: new object[] { new DateTime(2023, 8, 12, 19, 47, 53, 197, DateTimeKind.Local).AddTicks(3719), new DateTime(2023, 8, 12, 19, 47, 53, 197, DateTimeKind.Local).AddTicks(3721) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "LastEdit" },
                values: new object[] { new DateTime(2023, 8, 12, 19, 47, 53, 197, DateTimeKind.Local).AddTicks(3724), new DateTime(2023, 8, 12, 19, 47, 53, 197, DateTimeKind.Local).AddTicks(3726) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedOn", "Description", "ImageUrl", "IsActive", "IsDeleted", "LastEdit", "Model", "Name", "Price" },
                values: new object[,]
                {
                    { 5, 1, new DateTime(2023, 8, 12, 19, 47, 53, 197, DateTimeKind.Local).AddTicks(3735), "от Intel Core i5-12400F\nот Radeon RX 6650 XT до RTX 4070 Ti\nот 16GB DDR4\nот 1TB PCIe Gen3 NVMe SSD", "https://laptop.bg/system/images/415856/normal/grigs_arena_intel_gen12.png", true, false, new DateTime(2023, 8, 12, 19, 47, 53, 197, DateTimeKind.Local).AddTicks(3737), "MSI", "Arena", 1999.00m },
                    { 6, 1, new DateTime(2023, 8, 12, 19, 47, 53, 197, DateTimeKind.Local).AddTicks(3740), "от AMD Ryzen 5 5600\nот Radeon RX 6650 XT до RTX 4070\nот 16GB DDR4\nот 1TB Gen3 PCIe NVMe SSD", "https://laptop.bg/system/images/317025/normal/grigs_twister_white_amd.jpg", true, false, new DateTime(2023, 8, 12, 19, 47, 53, 197, DateTimeKind.Local).AddTicks(3742), "Asus", "Twister White", 2039.00m },
                    { 7, 2, new DateTime(2023, 8, 12, 19, 47, 53, 197, DateTimeKind.Local).AddTicks(3746), "AMD Ryzen™ 9 7945HX\nNVIDIA GeForce RTX 4080\nот 32GB до 64GB DDR5\nот 1TB SSD NVMe до 3TB SSD NVMe", "https://laptop.bg/system/images/395279/normal/asus_rog_zephyrus_duo_16_gx650pznm014x.jpg", true, false, new DateTime(2023, 8, 12, 19, 47, 53, 197, DateTimeKind.Local).AddTicks(3748), "Asus", "ROG Zephyrus Duo 16", 8499.00m },
                    { 8, 3, new DateTime(2023, 8, 12, 19, 47, 53, 197, DateTimeKind.Local).AddTicks(3751), "от AMD Ryzen 7 7800X3D\nот GeForce RTX 4070 Ti до RTX 4090\nот 32GB DDR5\nот 1TB Gen4 PCIe NVMe SSD", "https://laptop.bg/system/images/410555/normal/grigs_athena_icue_amd_zen4.jpg", true, false, new DateTime(2023, 8, 12, 19, 47, 53, 197, DateTimeKind.Local).AddTicks(3752), "Acer", "Athena iCue", 5639.00m },
                    { 9, 3, new DateTime(2023, 8, 12, 19, 47, 53, 197, DateTimeKind.Local).AddTicks(3758), "от AMD Ryzen 7 5800X3D\nот GeForce RTX 4070 Ti до RTX 4090\nот 32GB DDR4\nот 1TB Gen4 PCIe NVMe SSD", "https://laptop.bg/system/images/347415/normal/grigs_apolo_icue_amd.jpg", true, false, new DateTime(2023, 8, 12, 19, 47, 53, 197, DateTimeKind.Local).AddTicks(3760), "Asus", "Apollo iCue", 4889.00m },
                    { 10, 4, new DateTime(2023, 8, 12, 19, 47, 53, 197, DateTimeKind.Local).AddTicks(3763), "31.5\" OLED\r\n3840x2160 (4K UHD)\r\n99% DCI-P3\r\n99% Adobe RGB\r\nUSB Type-C", "https://laptop.bg/system/images/309623/normal/lg_32ep950b.jpg", true, false, new DateTime(2023, 8, 12, 19, 47, 53, 197, DateTimeKind.Local).AddTicks(3765), "LG", "32EP950-B", 7559.00m },
                    { 11, 4, new DateTime(2023, 8, 12, 19, 47, 53, 197, DateTimeKind.Local).AddTicks(3768), "27” IPS\r\n3840x2160 (4K Ultra HD)\r\nUSB Type-C\r\nHDR10\r\nCalman Ready", "https://laptop.bg/system/images/354936/normal/asus_proart_pa27ucxk.jpg", true, false, new DateTime(2023, 8, 12, 19, 47, 53, 197, DateTimeKind.Local).AddTicks(3770), "Asus", "ProArt PA27UCX-K", 5949.00m },
                    { 12, 4, new DateTime(2023, 8, 12, 19, 47, 53, 197, DateTimeKind.Local).AddTicks(3774), "55\" VA 165Hz Извит\r\n3840x2160 (4K Ultra HD)\r\nAMD FreeSync™ Premium Pro\r\nQuantum Matrix технология\r\nTizen™", "https://laptop.bg/system/images/413122/normal/samsung_odyssey_ark_ls55bg970nuxen.png", true, false, new DateTime(2023, 8, 12, 19, 47, 53, 197, DateTimeKind.Local).AddTicks(3775), "Samsung", "Odysseu Ark LS55BG97ONUXEN", 3999.00m },
                    { 13, 5, new DateTime(2023, 8, 12, 19, 47, 53, 197, DateTimeKind.Local).AddTicks(3779), "безжична гейминг клавиатура\r\nултра тънък дизайн\r\nнископрофилни GL Clicky суичове\r\nрегулируема LIGHTSYNC RGB подсветка", "https://laptop.bg/system/images/334363/normal/logitech_g915_tkl_lightspeed_wireless_rgb_mechanical_gaming_keyboard_gl_clicky_carbon_us_intl_intnl.jpg", true, false, new DateTime(2023, 8, 12, 19, 47, 53, 197, DateTimeKind.Local).AddTicks(3781), "Logitech", "G915 TKL", 459.00m },
                    { 14, 5, new DateTime(2023, 8, 12, 19, 47, 53, 197, DateTimeKind.Local).AddTicks(3785), "геймърска клавиатура\r\nRazer™ HyperSpeed Wireless (2.4 Ghz)/ Bluetooth/Type-C свързаност\r\nN-key roll over\r\nбордова памет и съхранение в облака - до 5 профила", "https://laptop.bg/system/images/393664/normal/RZ0304370100R3M1.jpg", true, false, new DateTime(2023, 8, 12, 19, 47, 53, 197, DateTimeKind.Local).AddTicks(3787), "Razer", "DeathStalker V2 Pro tenkeyless", 389.00m },
                    { 15, 5, new DateTime(2023, 8, 12, 19, 47, 53, 197, DateTimeKind.Local).AddTicks(3791), "механични Cherry MX суитчове\r\nRGB подсветка\r\nпрограмируеми клавиши\r\nаудио контрол", "https://laptop.bg/system/images/231437/normal/545BBCL.jpg", true, false, new DateTime(2023, 8, 12, 19, 47, 53, 197, DateTimeKind.Local).AddTicks(3794), "Alienware", "AW510K", 364.00m },
                    { 16, 6, new DateTime(2023, 8, 12, 19, 47, 53, 197, DateTimeKind.Local).AddTicks(3797), "Razer™ HyperSpeed Wireless\r\n3 сменяеми странични плочи\r\nдо 19+1 програмируеми бутона\r\nживот на батерията до 150 часа", "https://laptop.bg/system/images/308636/normal/RZ0103420100R3G1.png", true, false, new DateTime(2023, 8, 12, 19, 47, 53, 197, DateTimeKind.Local).AddTicks(3800), "Razer", "Naga Pro", 329.00m },
                    { 17, 6, new DateTime(2023, 8, 12, 19, 47, 53, 197, DateTimeKind.Local).AddTicks(3804), "Hero сензор с 25 600 DPI (след firmware update в G HUB)\r\n1ms LIGHTSPEED безжична технология\r\nсъвместимост с POWERPLAY\r\n114гр. тегло\r\nвъзможност за Hyper-scrolling", "https://laptop.bg/system/images/247224/normal/910005567.jpg", true, false, new DateTime(2023, 8, 12, 19, 47, 53, 197, DateTimeKind.Local).AddTicks(3806), "Logitech", "G502 Lightspeed", 309.00m },
                    { 18, 6, new DateTime(2023, 8, 12, 19, 47, 53, 197, DateTimeKind.Local).AddTicks(3810), "жичен /безжичен режим\r\n8 програмируеми бутона\r\nAlienFX осветяване подсветка\r\nдо 420 часа живот на батерията", "https://laptop.bg/system/images/393464/normal/545BBDN14.jpg", true, false, new DateTime(2023, 8, 12, 19, 47, 53, 197, DateTimeKind.Local).AddTicks(3812), "Alienware", "Tri-Mode Wireless", 306.00m },
                    { 19, 7, new DateTime(2023, 8, 12, 19, 47, 53, 197, DateTimeKind.Local).AddTicks(3818), "гумена основа\r\nподсветка\r\nсинхронизация на цветовете\r\nв черно", "https://laptop.bg/system/images/206283/normal/RZ0202500300R3M1.jpg", true, false, new DateTime(2023, 8, 12, 19, 47, 53, 197, DateTimeKind.Local).AddTicks(3821), "Razer", "Goliathus Extended Chroma", 149.00m },
                    { 20, 7, new DateTime(2023, 8, 12, 19, 47, 53, 197, DateTimeKind.Local).AddTicks(3824), "уеб камера Full HD 1080p\r\nкорекция на светлината\r\nавтоматично кадриране\r\nрежим на показване", "https://laptop.bg/system/images/373676/normal/960001422.png", true, false, new DateTime(2023, 8, 12, 19, 47, 53, 197, DateTimeKind.Local).AddTicks(3826), "Logitech", "Brio 500", 259.00m },
                    { 21, 7, new DateTime(2023, 8, 12, 19, 47, 53, 197, DateTimeKind.Local).AddTicks(3862), "USB Type-C\r\nDisplayPort\r\nHDMI\r\nRJ-45", "https://laptop.bg/system/images/331442/normal/lenovo_thinkpad_hybrid_usbc_with_usba_dock.jpg", true, false, new DateTime(2023, 8, 12, 19, 47, 53, 197, DateTimeKind.Local).AddTicks(3865), "Lenovo", "ThinkPad Hybrid", 589.00m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 12, 16, 46, 32, 693, DateTimeKind.Utc).AddTicks(425),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 8, 12, 16, 47, 53, 197, DateTimeKind.Utc).AddTicks(2611));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "LastEdit" },
                values: new object[] { new DateTime(2023, 8, 12, 19, 46, 32, 693, DateTimeKind.Local).AddTicks(1418), new DateTime(2023, 8, 12, 19, 46, 32, 693, DateTimeKind.Local).AddTicks(1458) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "LastEdit" },
                values: new object[] { new DateTime(2023, 8, 12, 19, 46, 32, 693, DateTimeKind.Local).AddTicks(1471), new DateTime(2023, 8, 12, 19, 46, 32, 693, DateTimeKind.Local).AddTicks(1473) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "LastEdit" },
                values: new object[] { new DateTime(2023, 8, 12, 19, 46, 32, 693, DateTimeKind.Local).AddTicks(1476), new DateTime(2023, 8, 12, 19, 46, 32, 693, DateTimeKind.Local).AddTicks(1478) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "LastEdit" },
                values: new object[] { new DateTime(2023, 8, 12, 19, 46, 32, 693, DateTimeKind.Local).AddTicks(1480), new DateTime(2023, 8, 12, 19, 46, 32, 693, DateTimeKind.Local).AddTicks(1482) });
        }
    }
}
