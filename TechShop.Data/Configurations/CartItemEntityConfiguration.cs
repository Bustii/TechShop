namespace TechShop.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using TechShop.Data.Models;

    public class CartItemEntityConfiguration : IEntityTypeConfiguration<CartProduct>
    {
        public void Configure(EntityTypeBuilder<CartProduct> builder)
        {
            builder
                .HasKey(c => new { c.CartId, c.ProductId });

        }
    }
}
