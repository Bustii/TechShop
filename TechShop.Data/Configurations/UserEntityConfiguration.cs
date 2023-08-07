namespace TechShop.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using TechShop.Data.Models;

    public class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .Property(u => u.FirstName)
                .HasDefaultValue("Test");

            builder
                .Property(u => u.LastName)
                .HasDefaultValue("Testov");
        }
    }
}
