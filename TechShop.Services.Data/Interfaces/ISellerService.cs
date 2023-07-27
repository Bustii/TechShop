namespace TechShop.Services.Data.Interfaces
{
    using TechShop.Web.ViewModels.Seller;

    public interface ISellerService
    {
        Task<bool> SellerExistsByUserIdAsync(string userId);

        Task<bool> SellerExistsByPhoneNumberAsync(string phoneNumber);

        Task<bool> HasSoldProductsByUserIdAsync(string userId);

        Task Create(string userId, BecomeSellerFormModel model);
    }
}
