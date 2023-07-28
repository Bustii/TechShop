namespace TechShop.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidationsConstants.Product;

    public class Product
    {
        public Product()
        {
            this.Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(ModelMaxLength)]
        public string Model { get; set; } = null!;

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required]
        [MaxLength(ImageUrlMaxLength)]
        public string ImageUrl { get; set; } = null!;

        [Required]
        public decimal Price { get; set; }

        public DateTime CreatedOn { get; set; }
        public bool IsActive { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; } = null!;

        public Guid SellerId { get; set; }

        public virtual Seller Seller { get; set; } = null!;

        //public Guid? BuyerId { get; set; }

        //public virtual ApplicationUser? Buyer { get; set; }

    }
}
