namespace TechShop.Services.Data.Interfaces
{
    using TechShop.Services.Data.Models;
    using TechShop.Web.ViewModels.Home;
    using TechShop.Web.ViewModels.Products;

    public interface IProductService
    {
        Task<IEnumerable<IndexViewModel>> LastFiveProductsAsync();

        Task<string> CreateAndReturnIdAsync(ProductFormModel formModel);

        Task<IEnumerable<ProductsAllViewModel>> AllProductsAsync(string productId);

        Task<AllProductsFilteredServiceModel> AllAsync(AllProductsQueryModel productModel);

        Task<bool> ExistsByIdAsync(string productId);

        Task<ProductsDetailsViewModel> GetDetailsByIdAsync(string productId);

        Task<ProductFormModel> GetProductForEditByIdAsync(string productId);

        Task EditProductByIdAndFormModelAsync(string productId, ProductFormModel productModel);

        Task<ProductPreDeleteDetailsViewModel> GetProductForDeleteByIdAsync(string productId);

        Task DeleteProductByIdAsync(string productId);
    }
}
