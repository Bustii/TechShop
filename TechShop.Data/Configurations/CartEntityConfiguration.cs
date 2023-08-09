namespace TechShop.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using TechShop.Data.Models;

    public class CartEntityConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder
                .HasMany(c => c.CartProducts)
                .WithOne(cp => cp.Cart)
                .HasForeignKey(cp => cp.CartId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
