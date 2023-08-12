namespace TechShop.Data.Configurations
{
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.EntityFrameworkCore;
    using TechShop.Data.Models;

    public class ProductEntityConfigurations : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
                .Property(h => h.CreatedOn)
                .HasDefaultValue(DateTime.UtcNow);


            builder
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(h => h.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
            
            builder
                .Property(h => h.Price)
                .HasPrecision(18, 2);
            builder
                .Property(h => h.IsActive)
                .HasDefaultValue(true);


            builder.HasData(this.GenerateProduct());
        }

        private Product[] GenerateProduct()
        {
            ICollection<Product> products = new HashSet<Product>();

            Product product;

            product = new Product()
            {
                Id = 1,
                Name = "Predator Orion 5000 PO5-650",
                Model = "Acer",
                Description = "Intel Core i7-13700F\r\nNVIDIA GeForce RTX 4070 Ti\r\n32GB DDR5\r\nот 1TB SSD NVMe до 4TB (SSD NVMe и HDD)",
                ImageUrl = "https://laptop.bg/system/images/413287/normal/Predator_Orion_7000_PO5_650.png",
                Price = 2300.00M,
                CategoryId = 3
            };
            products.Add(product);

            product = new Product()
            {
                Id = 2,
                Name = "Titan GT77 HX 13VI",
                Model = "MSI",
                Description = "Intel Core i9-13980HX\r\nNVIDIA GeForce RTX 4090\r\n64GB DDR5\r\nот 2TB SSD NVMe до 4TB SSD NVMe",
                ImageUrl = "https://laptop.bg/system/images/378257/normal/msi_titan_gt77_hx_13vi_9S717Q211055.png",
                Price = 2800.00M,
                CategoryId = 2
            };
            products.Add(product);

            product = new Product()
            {
                Id = 3,
                Name = "ROG Strix G15 G513IC-HN004",
                Model = "Asus",
                Description = "AMD Ryzen™ 7 4800H\r\nNVIDIA GeForce RTX 3050\r\nот 16GB до 64GB DDR4\r\nот 512GB SSD NVMe до 2512GB SSD NVMe",
                ImageUrl = "https://laptop.bg/system/images/293133/normal/asus_rog_strix_g15_g513ichn004.jpg",
                Price = 1900.00M,
                CategoryId = 2
            };
            products.Add(product);

            product = new Product()
            {
                Id = 4,
                Name = "ROG Hyperion",
                Model = "Asus",
                Description = "от Intel Core i9-13900K\r\nFull Water Loop\r\nGeForce RTX 4090\r\n64GB DDR5\r\nот 2TB Gen4 PCIe NVMe SSD",
                ImageUrl = "https://laptop.bg/system/images/409277/normal/grigs_hyperion_by_alexma3x.png",
                Price = 5000.00M,
                CategoryId = 1
            };
            products.Add(product);

            product = new Product()
            {
                Id = 5,
                Name = "Arena",
                Model = "MSI",
                Description = "от Intel Core i5-12400F\nот Radeon RX 6650 XT до RTX 4070 Ti\nот 16GB DDR4\nот 1TB PCIe Gen3 NVMe SSD",
                ImageUrl = "https://laptop.bg/system/images/415856/normal/grigs_arena_intel_gen12.png",
                Price = 1999.00M,
                CategoryId = 1
            };
            products.Add(product);

            product = new Product()
            {
                Id = 6,
                Name = "Twister White",
                Model = "Asus",
                Description = "от AMD Ryzen 5 5600\nот Radeon RX 6650 XT до RTX 4070\nот 16GB DDR4\nот 1TB Gen3 PCIe NVMe SSD",
                ImageUrl = "https://laptop.bg/system/images/317025/normal/grigs_twister_white_amd.jpg",
                Price = 2039.00M,
                CategoryId = 1
            };
            products.Add(product);

            product = new Product()
            {
                Id = 7,
                Name = "ROG Zephyrus Duo 16",
                Model = "Asus",
                Description = "AMD Ryzen™ 9 7945HX\nNVIDIA GeForce RTX 4080\nот 32GB до 64GB DDR5\nот 1TB SSD NVMe до 3TB SSD NVMe",
                ImageUrl = "https://laptop.bg/system/images/395279/normal/asus_rog_zephyrus_duo_16_gx650pznm014x.jpg",
                Price = 8499.00M,
                CategoryId = 2
            };
            products.Add(product);

            product = new Product()
            {
                Id = 8,
                Name = "Athena iCue",
                Model = "Acer",
                Description = "от AMD Ryzen 7 7800X3D\nот GeForce RTX 4070 Ti до RTX 4090\nот 32GB DDR5\nот 1TB Gen4 PCIe NVMe SSD",
                ImageUrl = "https://laptop.bg/system/images/410555/normal/grigs_athena_icue_amd_zen4.jpg",
                Price = 5639.00M,
                CategoryId = 3
            };
            products.Add(product);

            product = new Product()
            {
                Id = 9,
                Name = "Apollo iCue",
                Model = "Asus",
                Description = "от AMD Ryzen 7 5800X3D\nот GeForce RTX 4070 Ti до RTX 4090\nот 32GB DDR4\nот 1TB Gen4 PCIe NVMe SSD",
                ImageUrl = "https://laptop.bg/system/images/347415/normal/grigs_apolo_icue_amd.jpg",
                Price = 4889.00M,
                CategoryId = 3
            };
            products.Add(product);

            product = new Product()
            {
                Id = 10,
                Name = "32EP950-B",
                Model = "LG",
                Description = "31.5\" OLED\r\n3840x2160 (4K UHD)\r\n99% DCI-P3\r\n99% Adobe RGB\r\nUSB Type-C",
                ImageUrl = "https://laptop.bg/system/images/309623/normal/lg_32ep950b.jpg",
                Price = 7559.00M,
                CategoryId = 4
            };
            products.Add(product);

            product = new Product()
            {
                Id = 11,
                Name = "ProArt PA27UCX-K",
                Model = "Asus",
                Description = "27” IPS\r\n3840x2160 (4K Ultra HD)\r\nUSB Type-C\r\nHDR10\r\nCalman Ready",
                ImageUrl = "https://laptop.bg/system/images/354936/normal/asus_proart_pa27ucxk.jpg",
                Price = 5949.00M,
                CategoryId = 4
            };
            products.Add(product);

            product = new Product()
            {
                Id = 12,
                Name = "Odysseu Ark LS55BG97ONUXEN",
                Model = "Samsung",
                Description = "55\" VA 165Hz Извит\r\n3840x2160 (4K Ultra HD)\r\nAMD FreeSync™ Premium Pro\r\nQuantum Matrix технология\r\nTizen™",
                ImageUrl = "https://laptop.bg/system/images/413122/normal/samsung_odyssey_ark_ls55bg970nuxen.png",
                Price = 3999.00M,
                CategoryId = 4
            };
            products.Add(product);

            product = new Product()
            {
                Id = 13,
                Name = "G915 TKL",
                Model = "Logitech",
                Description = "безжична гейминг клавиатура\r\nултра тънък дизайн\r\nнископрофилни GL Clicky суичове\r\nрегулируема LIGHTSYNC RGB подсветка",
                ImageUrl = "https://laptop.bg/system/images/334363/normal/logitech_g915_tkl_lightspeed_wireless_rgb_mechanical_gaming_keyboard_gl_clicky_carbon_us_intl_intnl.jpg",
                Price = 459.00M,
                CategoryId = 5
            };
            products.Add(product);

            product = new Product()
            {
                Id = 14,
                Name = "DeathStalker V2 Pro tenkeyless",
                Model = "Razer",
                Description = "геймърска клавиатура\r\nRazer™ HyperSpeed Wireless (2.4 Ghz)/ Bluetooth/Type-C свързаност\r\nN-key roll over\r\nбордова памет и съхранение в облака - до 5 профила",
                ImageUrl = "https://laptop.bg/system/images/393664/normal/RZ0304370100R3M1.jpg",
                Price = 389.00M,
                CategoryId = 5
            };
            products.Add(product);

            product = new Product()
            {
                Id = 15,
                Name = "AW510K",
                Model = "Alienware",
                Description = "механични Cherry MX суитчове\r\nRGB подсветка\r\nпрограмируеми клавиши\r\nаудио контрол",
                ImageUrl = "https://laptop.bg/system/images/231437/normal/545BBCL.jpg",
                Price = 364.00M,
                CategoryId = 5
            };
            products.Add(product);

            product = new Product()
            {
                Id = 16,
                Name = "Naga Pro",
                Model = "Razer",
                Description = "Razer™ HyperSpeed Wireless\r\n3 сменяеми странични плочи\r\nдо 19+1 програмируеми бутона\r\nживот на батерията до 150 часа",
                ImageUrl = "https://laptop.bg/system/images/308636/normal/RZ0103420100R3G1.png",
                Price = 329.00M,
                CategoryId = 6
            };
            products.Add(product);

            product = new Product()
            {
                Id = 17,
                Name = "G502 Lightspeed",
                Model = "Logitech",
                Description = "Hero сензор с 25 600 DPI (след firmware update в G HUB)\r\n1ms LIGHTSPEED безжична технология\r\nсъвместимост с POWERPLAY\r\n114гр. тегло\r\nвъзможност за Hyper-scrolling",
                ImageUrl = "https://laptop.bg/system/images/247224/normal/910005567.jpg",
                Price = 309.00M,
                CategoryId = 6
            };
            products.Add(product);

            product = new Product()
            {
                Id = 18,
                Name = "Tri-Mode Wireless",
                Model = "Alienware",
                Description = "жичен /безжичен режим\r\n8 програмируеми бутона\r\nAlienFX осветяване подсветка\r\nдо 420 часа живот на батерията",
                ImageUrl = "https://laptop.bg/system/images/393464/normal/545BBDN14.jpg",
                Price = 306.00M,
                CategoryId = 6
            };
            products.Add(product);

            product = new Product()
            {
                Id = 19,
                Name = "Goliathus Extended Chroma",
                Model = "Razer",
                Description = "гумена основа\r\nподсветка\r\nсинхронизация на цветовете\r\nв черно",
                ImageUrl = "https://laptop.bg/system/images/206283/normal/RZ0202500300R3M1.jpg",
                Price = 149.00M,
                CategoryId = 7
            };
            products.Add(product);

            product = new Product()
            {
                Id = 20,
                Name = "Brio 500",
                Model = "Logitech",
                Description = "уеб камера Full HD 1080p\r\nкорекция на светлината\r\nавтоматично кадриране\r\nрежим на показване",
                ImageUrl = "https://laptop.bg/system/images/373676/normal/960001422.png",
                Price = 259.00M,
                CategoryId = 7
            };
            products.Add(product);

            product = new Product()
            {
                Id = 21,
                Name = "ThinkPad Hybrid",
                Model = "Lenovo",
                Description = "USB Type-C\r\nDisplayPort\r\nHDMI\r\nRJ-45",
                ImageUrl = "https://laptop.bg/system/images/331442/normal/lenovo_thinkpad_hybrid_usbc_with_usba_dock.jpg",
                Price = 589.00M,
                CategoryId = 7
            };
            products.Add(product);

            return products.ToArray();
        }
    }
}
