namespace TechShop.Services.Data.Interfaces
{
    public interface IBuyerService
    {
        Task<bool> BuyerExistsByUserIdAsync(string userId);

        Task<bool> HasBuyedProductsByUserIdAsync(string userId);

        Task<string?> GetBuyerIdByUserIdAsync(string userId);
    }
}
