namespace TechShop.Services.Data
{
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;
    using TechShop.Data;
    using TechShop.Data.Models;
    using TechShop.Services.Data.Interfaces;

    public class BuyerService : IBuyerService
    {
        private readonly TechShopDbContext dbContext;

        public BuyerService(TechShopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> BuyerExistsByUserIdAsync(string userId)
        {
            bool result = await dbContext
                .Buyers
                .AnyAsync(a => a.UserId.ToString() == userId);

            return result;
        }

        public async Task<string?> GetBuyerIdByUserIdAsync(string userId)
        {
            Buyer? buyer = await dbContext
                .Buyers
                .FirstOrDefaultAsync(a => a.UserId.ToString() == userId);
            if (buyer == null)
            {
                return null;
            }

            return buyer.Id.ToString();
        }

        public async Task<bool> HasBuyedProductsByUserIdAsync(string userId)
        {
            User? buyer = await dbContext
                .Users
                .FirstOrDefaultAsync(u => u.Id.ToString() == userId);
            if (buyer == null)
            {
                return false;
            }

            return buyer.BuyedProducts.Any();
        }
    }
}
