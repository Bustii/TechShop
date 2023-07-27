namespace TechShop.Services.Data.Interfaces
{
    using TechShop.Web.ViewModels.Home;

    public interface IProductService
    {
        Task<IEnumerable<IndexViewModel>> LastFivePcsAsync();
    }
}
