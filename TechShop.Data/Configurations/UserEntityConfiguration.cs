namespace TechShop.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using TechShop.Data.Models;

    public class UserEntityConfiguration : IEntityTypeConfiguration<ApplicationUserProduct>
    {
        public void Configure(EntityTypeBuilder<ApplicationUserProduct> builder)
        {
            builder.HasKey(u => new { u.UserId, u.ProductId });
        }
    }
}
