namespace TechShop.Web.ViewModels.Products
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Linq;

    public class ProductsAllViewModel
    {     
            public string Id { get; set; } = null!;

            public string Name { get; set; } = null!;

            public string Model { get; set; } = null!;

            public string Description { get; set; } = null!;

            [Display(Name = "Image Link")]
            public string ImageUrl { get; set; } = null!;

            [Display(Name = "Price")]
            public decimal Price { get; set; }       
    }
}
