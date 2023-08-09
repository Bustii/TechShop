namespace TechShop.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using TechShop.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using System.Reflection;

    public class TechShopDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public TechShopDbContext(DbContextOptions<TechShopDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; } = null!;

        public DbSet<Product> Products { get; set; } = null!;

        public DbSet<ApplicationUserProduct> UserProducts { get; set; } = null!;

        public DbSet<Cart> Carts { get; set; } = null!;

        public DbSet<CartItem> CartProducts { get; set; } = null!;

        public DbSet<Order> Orders { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder builder)
        {
            var configAssembly = Assembly.GetAssembly(typeof(TechShopDbContext));
                                      Assembly.GetExecutingAssembly();

            builder.ApplyConfigurationsFromAssembly(configAssembly!);

            base.OnModelCreating(builder);
        }
    }
}