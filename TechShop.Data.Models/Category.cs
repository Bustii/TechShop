namespace TechShop.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidationsConstants.Category;

    public class Category
    {
        public Category()
        {
            this.IsDeleted = false;
            this.Products = new HashSet<Product>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        public bool IsDeleted { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
