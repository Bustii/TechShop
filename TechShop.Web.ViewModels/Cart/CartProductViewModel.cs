namespace TechShop.Web.ViewModels.Cart
{
    using System.ComponentModel.DataAnnotations;

    using static Common.EntityValidationsConstants.CartValidations;
    public class CartProductViewModel
    {
        public CartProductViewModel()
        {
            Quantity = 0;
            TotalPrice = Price * Quantity;
        }
        public int ProductId { get; set; }

        public string Name { get; set; } = null!;

        public string Model { get; set; } = null!;

        public string? Image { get; set; }

        public decimal Price { get; set; }

        [Range(typeof(int), QuantityMinValue, QuantityMaxValue)]
        public int Quantity { get; set; }

        [Range(typeof(decimal), TotalPriceMinValue, TotalPriceMaxValue)]
        public decimal TotalPrice { get; set; }
    }
}
