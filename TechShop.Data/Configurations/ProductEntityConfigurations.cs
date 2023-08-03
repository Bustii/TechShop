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
                .Property(h => h.IsActive)
                .HasDefaultValue(true);

            builder
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(h => h.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
          

           builder.HasData(this.GenerateProduct());
        }

        private Product[] GenerateProduct()
        {
            ICollection<Product> products = new HashSet<Product>();

            Product product;

            product = new Product()
            {
                Name = "Predator Orion 5000 PO5-650",
                Model = "Acer",
                Description = "Intel Core i7-13700F\r\nNVIDIA GeForce RTX 4070 Ti\r\n32GB DDR5\r\nот 1TB SSD NVMe до 4TB (SSD NVMe и HDD)",
                ImageUrl = "https://laptop.bg/system/images/413287/normal/Predator_Orion_7000_PO5_650.png",
                Price = 2300.00M,
                CategoryId = 3
                //BuyerId = Guid.Parse("079F3635-F031-4C1E-9750-08DB740AA10F") //BuyerId
            };
            products.Add(product);

            product = new Product()
            {
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
                Name = "ROG Hyperion",
                Model = "Asus",
                Description = "от Intel Core i9-13900K\r\nFull Water Loop\r\nGeForce RTX 4090\r\n64GB DDR5\r\nот 2TB Gen4 PCIe NVMe SSD",
                ImageUrl = "https://laptop.bg/system/images/409277/normal/grigs_hyperion_by_alexma3x.png",
                Price = 5000.00M,
                CategoryId = 1
            };
            products.Add(product);

            return products.ToArray();
        }
    }
}
