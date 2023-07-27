namespace TechShop.Web.ViewModels.Products
{
    using Enums;
    using System.ComponentModel.DataAnnotations;
    using static TechShop.Common.GeneralApplicationConstans;

    public class AllProductsQueryModel
    {
        public AllProductsQueryModel()
        {
            CurrentPage = DefaultPage;
            HousesPerPage = EntitiesPerPage;

            Categories = new HashSet<string>();
            Products = new HashSet<ProductsAllViewModel>();
        }

        public string? Category { get; set; }

        [Display(Name = "Search by word")]
        public string? SearchString { get; set; }

        [Display(Name = "Sort Products By")]
        public ProductSorting ProductSorting { get; set; }

        public int CurrentPage { get; set; }

        [Display(Name = "Show Products On Page")]
        public int HousesPerPage { get; set; }

        public int TotalHouses { get; set; }

        public IEnumerable<string> Categories { get; set; }

        public IEnumerable<ProductsAllViewModel> Products { get; set; }
    }
}
