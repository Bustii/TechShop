namespace TechShop.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidationsConstants.Seller;

    public class Seller
    {
        public Seller()
        {
            this.Id = Guid.NewGuid();
            this.SelledProducts = new HashSet<Product>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        [MaxLength(PhoneNumberMaxLength)]
        public string PhoneNumber { get; set; } = null!;

        public Guid UserId { get; set; }

        public virtual ApplicationUser User { get; set; } = null!;

        public virtual ICollection<Product> SelledProducts { get; set; }
    }
}
