namespace TechShop.Services.Data.Interfaces
{
    using TechShop.Web.ViewModels.Cart;

    public interface ICartService
    {
        Task<CartFormViewModel?> GetCurrentCartByUserIdAsync(string userId);

        Task<CartFormViewModel> GetCartByOrderIdAsync(string orderId);

        Task CreateCartAsync(string userId);

        Task AddProductToCartAsync(int productId, string cartId, string userId);

        Task RemoveItemFromCartAsync(int cartProductId, string cartId);

        Task IncreaseItemCountAsync(int productId, string cartId);

        Task DecreaseItemCountAsync(int productId, string cartId);
    }
}
