namespace TechShop.Web.ViewModels.Products
{
    using Seller;

    public class ProductsDetailsViewModel : ProductsAllViewModel
    {
        public string Description { get; set; } = null!;

        public string Category { get; set; } = null!;

        public SellerInfoOnProductViewModel Seller { get; set; } = null!;
    }
}
}
