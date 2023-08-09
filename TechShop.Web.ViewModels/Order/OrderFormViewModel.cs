namespace TechShop.Web.ViewModels.Order
{
    using System.ComponentModel.DataAnnotations;

    using static TechShop.Common.EntityValidationsConstants.User;
    public class OrderFormViewModel
    {
        public string? Id { get; set; }

        [Required]
        [StringLength(FirstNameMaxLength, MinimumLength = FirstNameMinLength)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(LastNameMaxLength, MinimumLength = LastNameMinLength)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = null!;

        [Required]
        [StringLength(CountryMaxLength, MinimumLength = CountryMinLength)]
        public string Country { get; set; } = null!;

        [Required]
        [StringLength(CityMaxLength, MinimumLength = CityMinLength)]
        public string City { get; set; } = null!;

        [Required]
        [StringLength(AddressMaxLength, MinimumLength = AddressMinLength)]
        public string Address { get; set; } = null!;

        [Required]
        [StringLength(PostCodeMaxLength, MinimumLength = PostCodeMinLength)]
        public string PostCode { get; set; } = null!;

        [StringLength(DescriptionMaxLength)]
        public string? Description { get; set; }

        public string? UserId { get; set; }

        public string? CartId { get; set; } 

        public decimal TotalPrice { get; set; }
    }
}
