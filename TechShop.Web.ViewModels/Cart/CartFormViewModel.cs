namespace TechShop.Web.ViewModels.Cart
{
    using System.ComponentModel.DataAnnotations;

    using static Common.EntityValidationsConstants.CartValidations;
    public class CartFormViewModel
    {
        public CartFormViewModel()
        {
            Products = new HashSet<CartProductViewModel>();
            TotalPrice = 0;
        }
        public string Id { get; set; } = null!;

        [Range(typeof(decimal), TotalPriceMinValue, TotalPriceMaxValue)]
        public decimal TotalPrice { get; set; }

        public IEnumerable<CartProductViewModel> Products { get; set; }
    }
}
