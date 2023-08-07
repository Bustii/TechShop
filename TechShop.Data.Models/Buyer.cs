namespace TechShop.Data.Models
{
    public class Buyer
    {
        public Buyer()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public virtual User User { get; set; } = null!;

        public virtual ICollection<Product>? BuyedProducts { get; set; }
    }
}
