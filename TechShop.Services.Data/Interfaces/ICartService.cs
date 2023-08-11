namespace TechShop.Services.Data.Interfaces
{
    using TechShop.Web.ViewModels.Cart;

    public interface ICartService
    {
        Task<CartFormViewModel?> GetCurrentCartByUserIdAsync(string userId);

        Task<CartFormViewModel> GetCartByOrderIdAsync(string orderId);

        Task CreateCartAsync(string userId);

        Task AddProductToCartAsync(int productId, string cartId, string userId);

        Task RemoveProductFromCartAsync(int cartProductId, string cartId);

        Task IncreaseProductCountAsync(int productId, string cartId);

        Task DecreaseProductCountAsync(int productId, string cartId);
    }
}
