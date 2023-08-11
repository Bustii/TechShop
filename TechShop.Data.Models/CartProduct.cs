namespace TechShop.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;

    public class CartProduct
    {
        public CartProduct()
        {
            Quantity = 1;
        }

        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }

        [Required]
        public Product Product { get; set; } = null!;

        [ForeignKey(nameof(Cart))]
        public Guid CartId { get; set; }

        [Required]
        public Cart Cart { get; set; } = null!;

        public int Quantity { get; set; }
    }
}
