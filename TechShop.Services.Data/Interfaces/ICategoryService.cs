namespace TechShop.Services.Data.Interfaces
{
    using TechShop.Services.Data.Models;
    using TechShop.Web.ViewModels.Products;
    using Web.ViewModels.Category;

    public interface ICategoryService
    {
        Task<IEnumerable<ProductSelectCategoryFormModel>> AllCategoriesAsync();

        Task<IEnumerable<AllCategoriesViewModel>> AllCategoriesForListAsync();

        Task<bool> ExistsByIdAsync(int id);

        Task<IEnumerable<string>> AllCategoryNamesAsync();

        Task<CategoryDetailsViewModel> GetDetailsByIdAsync(int id);

        Task<bool> IsCategoryExistByNameAsync(string categoryName);

        Task<AllCategoriesFilteredServiceModel> AllCategoriesQueryAsync(AllCategoriesQueryModel queryModel);

        Task EditCategoryAsync(int cateogryId, NewCategoryViewModel categoryModel);

        Task CreateNewCategoryAsync(NewCategoryViewModel categoryModel);

        Task<NewCategoryViewModel> GetCategoryByIdAsync(int categoryId);

        Task SoftDeleteCategoryAsync(int categoryId);

        Task DeleteCategoryByIdAsync(int categoryId);
    }
}
