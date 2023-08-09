namespace TechShop.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class ApplicationUserProduct
    {
        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }

        public virtual ApplicationUser User { get; set; } = null!;

        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }

        public virtual Product Product { get; set; } = null!;
    }
}
