namespace TechShop.Web.ViewModels.Category
{
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidationsConstants.Category;

    public class NewCategoryViewModel
    {
        [Required]
        [StringLength(NameMaxLength, MinimumLength =NameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        public string Image { get; set; } = null!;
    }
}
