namespace TechShop.Services.Data.Interfaces
{
    using Web.ViewModels.Category;

    public interface ICategoryService
    {
        Task<IEnumerable<ProductSelectCategoryFormModel>> AllCategoriesAsync();

        Task<IEnumerable<AllCategoriesViewModel>> AllCategoriesForListAsync();

        Task<bool> ExistsByIdAsync(int id);

        Task<IEnumerable<string>> AllCategoryNamesAsync();

        Task<CategoryDetailsViewModel> GetDetailsByIdAsync(int id);
    }
}
