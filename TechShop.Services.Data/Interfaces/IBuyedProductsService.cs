namespace TechShop.Services.Data.Interfaces
{
    using TechShop.Web.ViewModels.BuyedProducts;

    public interface IBuyedProductsService
    {
        Task<IEnumerable<BuyedProductsViewModel>> AllBuyedProductsAsync();
    }
}
