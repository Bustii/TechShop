namespace Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using TechShop.Data.Models;

    public class CategoryEntityConfigurations : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
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
                Name = "Gaming Components"
            };
            categories.Add(category);

            return categories.ToArray();
        }
    }
}
