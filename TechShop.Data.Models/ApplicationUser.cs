namespace TechShop.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidationsConstants.User;

    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid();
            this.IsAdministrator = false;
            this.CreatedOn = DateTime.UtcNow;
            this.Orders = new HashSet<Order>();
            this.IsDeleted = false;
        }

        [Required]
        [MaxLength(FirstNameMaxLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(LastNameMaxLength)]
        public string LastName { get; set; } = null!;

        [MaxLength(CountryMaxLength)]
        public string? Country { get; set; }

        [MaxLength(CityMaxLength)]
        public string? City { get; set; }

        [MaxLength(AddressMaxLength)]
        public string? Address { get; set; }

        [MaxLength(PostCodeMaxLength)]
        public string? PostCode { get; set; }

        public bool IsAdministrator { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreatedOn { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
