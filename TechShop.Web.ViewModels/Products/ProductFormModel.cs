namespace TechShop.Web.ViewModels.Products
{
    public class ProductFormModel
    {
        public string Name { get; set; } = null!;

        public string Model { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public decimal Price { get; set; }
    }
}
