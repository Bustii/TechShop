namespace TechShop.Web.ViewModels.Order
{
    using System.ComponentModel.DataAnnotations;
    using TechShop.Web.ViewModels.Cart;

    public class OrderHistoryViewModel
    {
        public OrderHistoryViewModel()
        {
            CartProducts = new HashSet<CartProductViewModel>();    
        }

        [Required]
        public string Id { get; set; } = null!;

        public DateTime CreatedOn { get; set; }

        public decimal TotalPrice { get; set; }

        public IEnumerable<CartProductViewModel> CartProducts { get; set; }

    }
}
