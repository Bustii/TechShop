namespace TechShop.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;

    public  class Cart
    {
        public Cart()
        {
            Id = Guid.NewGuid();
            CreatedOn = DateTime.UtcNow;

            CartProducts = new HashSet<CartItem>();
        }

        [Key]
        public Guid Id { get; set; }

        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }

        [Required]
        public virtual ApplicationUser User { get; set; } = null!;

        public DateTime CreatedOn { get; set; }

        public virtual ICollection<CartItem> CartProducts { get; set; }
    }
}
