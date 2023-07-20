namespace TechShop.Services.Data
{
    using TechShop.Data;
    using TechShop.Services.Data.Interfaces;

    public class SellerService : ISellerService
    {
        private readonly TechShopDbContext dbContext;

        public SellerService(TechShopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
