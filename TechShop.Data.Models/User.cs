namespace TechShop.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidationsConstants.User;

    public class User : IdentityUser<Guid>
    {
        public User()
        {
            this.Id = Guid.NewGuid();
            this.BuyedProducts = new HashSet<Product>();
        }

        [Required]
        [MaxLength(FirstNameMaxLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(LastNameMaxLength)]
        public string LastName { get; set; } = null!;

        public virtual ICollection<Product> BuyedProducts { get; set; }
    }
}
