namespace TechShop.Services.Data.Models
{
    using TechShop.Web.ViewModels.Category;

    public class AllCategoriesFilteredServiceModel
    {
        public AllCategoriesFilteredServiceModel()
        {
            Categories = new HashSet<CategoryDetailsViewModel>();
        }

        public int TotalCategoriesCount { get; set; }

        public IEnumerable<CategoryDetailsViewModel> Categories { get; set; }
    }
}
