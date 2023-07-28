namespace TechShop.Services.Data.Models
{
    using System.Collections.Generic;
    using Web.ViewModels.Products;

    public class AllProductsFilteredServiceModel
    {
        public AllProductsFilteredServiceModel()
        {
            Products = new HashSet<ProductsAllViewModel>();
        }

        public int TotalProductsCount { get; set; }

        public IEnumerable<ProductsAllViewModel> Products { get; set; }
    }
}
