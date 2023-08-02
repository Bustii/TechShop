namespace TechShop.Web.ViewModels.Products
{
    using System.ComponentModel.DataAnnotations;

    public class ProductPreDeleteDetailsViewModel
    {
        public string Name { get; set; } = null!;

        public string Model { get; set; } = null!;

        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; } = null!;
    }
}
