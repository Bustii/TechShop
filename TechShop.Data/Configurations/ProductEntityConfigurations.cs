namespace TechShop.Data.Configurations
{
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.EntityFrameworkCore;
    using TechShop.Data.Models;

    public class ProductEntityConfigurations
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
                .HasOne(p => p.Seller)
                .WithMany(s => s.SelledProducts)
                .HasForeignKey(p => p.SellerId)
                .OnDelete(DeleteBehavior.Restrict);

           builder.HasData(this.GenerateProduct());
        }

        private Product[] GenerateProduct()
        {
            ICollection<Product> products = new HashSet<Product>();

            Product product;

            product = new Product()
            {
                Name = "Desktop Exteme configuration",
                Model = "Lenovo",
                Description = "Intel Core i3-12100\r\nIntel UHD Graphics 730\r\nот 8GB до 32GB DDR4\r\nот 512GB SSD NVMe до 4TB (SSD и HDD)",
                ImageUrl = "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6401/6401009_sd.jpg;maxHeight=2000;maxWidth=2000",
                Price = 1300.00M,
                CategoryId = 1,
                SellerId = Guid.Parse("bef01bd8-5d5f-4087-9aa9-35a43e44f314"), //SellerId
                //BuyerId = Guid.Parse("079F3635-F031-4C1E-9750-08DB740AA10F") //BuyerId
            };
            products.Add(product);

            product = new Product()
            {
                Name = "MSI Katana GF76 11UD",
                Model = "Msi",
                Description = "Intel Core i7-11800H\r\nNVIDIA GeForce RTX 3050 Ti\r\nот 16GB до 64GB DDR4\r\nот 512GB SSD NVMe до 2TB SSD NVMe",
                ImageUrl = "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6511/6511432_rd.jpg;maxHeight=640;maxWidth=550",
                Price = 1800.00M,
                CategoryId = 2,
                SellerId = Guid.Parse("bef01bd8-5d5f-4087-9aa9-35a43e44f314"), //SellerId
            };
            products.Add(product);

            product = new Product()
            {
                Name = "ASUS Laptop L510 Ultra Thin Laptop",
                Model = "Asus",
                Description = "Intel Core i5-1135G7\r\nIntel Iris Xe Graphics\r\nот 8GB до 40GB DDR4\r\nот 512GB SSD NVMe до 2TB SSD NVMe",
                ImageUrl = "https://m.media-amazon.com/images/I/71y1msTBGAL._AC_SL1500_.jpg",
                Price = 1900.00M,
                CategoryId = 2,
                SellerId = Guid.Parse("bef01bd8-5d5f-4087-9aa9-35a43e44f314"), //SellerId
            };
            products.Add(product);

            return products.ToArray();
        }
    }
}
