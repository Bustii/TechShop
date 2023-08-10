namespace TechShop.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static Common.EntityValidationsConstants.Product;

    public class Product
    {
        public Product()
        {
            IsActive = true;
            IsDeleted = false;

            CreatedOn = DateTime.Now;
            LastEdit = DateTime.Now;

            UserProducts = new HashSet<ApplicationUserProduct>();
        }

        [Key]
        public int Id { get; set; }

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

        public DateTime LastEdit { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }

        [Required]
        public virtual Category Category { get; set; } = null!;


        public virtual ICollection<ApplicationUserProduct> UserProducts { get; set; } = null!;
    }
}
