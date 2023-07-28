namespace TechShop.Web.ViewModels.Products
{
    using System.ComponentModel.DataAnnotations;
    using TechShop.Web.ViewModels.Category;
    using static TechShop.Common.EntityValidationsConstants.Product;

    public class ProductFormModel
    {
        public ProductFormModel()
        {
            Categories = new HashSet<ProductSelectCategoryFormModel>();
        }

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(ModelMaxLength, MinimumLength = ModelMinLength)]
        public string Model { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Required]
        [StringLength(ImageUrlMaxLength)]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [Range(typeof(decimal),PriceMinValue, PriceMaxValue)]
        public decimal Price { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public IEnumerable<ProductSelectCategoryFormModel> Categories { get; set; }

    }
}
