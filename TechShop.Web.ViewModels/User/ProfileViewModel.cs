namespace TechShop.Web.ViewModels.User
{
    using System.ComponentModel.DataAnnotations;


    public class ProfileViewModel
    {
        [Required]
        public string UserName { get; set; } = null!;

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Country { get; set; }

        public string? City { get; set; }

        public string? Address { get; set; }

        public string? PostCode { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
    }
}
