namespace TechShop.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Buyer
    {
        public Buyer()
        {
            Id = Guid.NewGuid();
            BuyedProducts = new HashSet<Product>();
        }
        [Key]
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public virtual User User { get; set; } = null!;

        public virtual ICollection<Product>? BuyedProducts { get; set; }
    }
}
