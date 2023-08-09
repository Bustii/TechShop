namespace TechShop.Web.ViewModels.Category
{
    using System.ComponentModel.DataAnnotations;
    using TechShop.Web.ViewModels.Enums;

    using static TechShop.Common.GeneralApplicationConstans;

    public class AllCategoriesQueryModel
    {
        public AllCategoriesQueryModel()
        {
            CurrentPage = DefaultPage;
            CategoriesPerPage = EntitiesPerPage;

            Categories = new HashSet<CategoryDetailsViewModel>();
        }

        [Display(Name = "Search by word")]
        public string? SearchString { get; set; }

        [Display(Name = "Sort Categories By")]
        public CategorySorting CategorySorting { get; set; }

        public int CurrentPage { get; set; }

        [Display(Name = "Products On Page")]
        public int CategoriesPerPage { get; set; }

        public int TotalCategories { get; set; }

        public IEnumerable<CategoryDetailsViewModel> Categories { get; set; }
    }
}
