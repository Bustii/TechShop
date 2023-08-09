namespace Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using TechShop.Data.Models;

    public class CategoryEntityConfigurations : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder
                .HasMany(c => c.Products)
                .WithOne(i => i.Category)
                .HasForeignKey(i => i.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(this.GenerateCategories());
        }

        private Category[] GenerateCategories()
        {
            ICollection<Category> categories = new HashSet<Category>();

            Category category;

            category = new Category()
            {
                Id = 1,
                Name = "Desktop Computers"
            };
            categories.Add(category);

            category = new Category()
            {
                Id = 2,
                Name = "Laptops"
            };
            categories.Add(category);

            category = new Category()
            {
                Id = 3,
                Name = "Gaming Computers"
            };
            categories.Add(category);

            category = new Category()
            {
                Id = 4,
                Name = "Monitors"
            };
            categories.Add(category);

            category = new Category()
            {
                Id = 5,
                Name = "Keyboards"
            };
            categories.Add(category);

            category = new Category()
            {
                Id = 6,
                Name = "Mouses"
            };
            categories.Add(category);

            category = new Category()
            {
                Id = 7,
                Name = "Gaming Peripherals"
            };
            categories.Add(category);

            return categories.ToArray();

        }
    }
}
