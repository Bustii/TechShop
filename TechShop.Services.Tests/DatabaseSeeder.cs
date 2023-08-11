namespace TechShop.Services.Tests
{
    using TechShop.Data.Models;
    using TechShop.Data;

    public static class DatabaseSeeder
    {
        public static ApplicationUser? User;

        public static Product? Product;
        public static Order? Order;
        public static Cart? Cart;
        public static CartProduct? CartProduct;


        public static void SeedDatabase(TechShopDbContext dbContext)
        {
            User = new ApplicationUser()
            {
                Id = Guid.Parse("A7497549-8106-4BCA-ADD8-7F755878BC67"),
                FirstName = "Ventsislav",
                LastName = "Minev",
                UserName = "venncy961@abv.bg",
                NormalizedUserName = "VENNCY961@ABV.BG",
                Email = "venncy961@abv.bg",
                NormalizedEmail = "VENNCY961@ABV.BG",
                PasswordHash = "AQAAAAEAACcQAAAAEDFwfm2AXNjc/h3rywLqkNNBNidoN1kcsZXQvWZ3q8BFyPm6yslD+GNXAmCsSSnj9A==",
                ConcurrencyStamp = "d8cd2173-7735-4725-9367-93d9daf2306e",
                SecurityStamp = "UVLJSFX2M6AAPV3GVKFXOG5R24EWRVE4",
                
            };

            dbContext.Users.Add(User);

            Cart = new Cart()
            {
                Id = Guid.Parse("673AA22A-681F-4CD5-8754-383DAACA8832"),
                UserId = Guid.Parse("A7497549-8106-4BCA-ADD8-7F755878BC67"),
                CreatedOn = DateTime.Parse("2023-08-09 11:06:49.7782787")
            };

            CartProduct = new CartProduct()
            {
                CartId = Guid.Parse("673AA22A-681F-4CD5-8754-383DAACA8832"),
                ProductId = 3,
                Quantity = 10
            };

            Cart.CartProducts.Add(CartProduct);

            dbContext.CartProducts.Add(CartProduct);
            dbContext.Carts.Add(Cart);

            Order = new Order()
            {
                Id = Guid.Parse("21F67AB9-4E89-4DC0-9E6A-42A2C77CFB6B"),
                FirstName = "Ventsislav",
                LastName = "sdfsdf",
                Country = "sdfsdf",
                City = "sdfsdf",
                Address = "sdfsdf",
                PostCode = "1412",
                CreatedOn = DateTime.Parse("2023-08-10 18:55:51.5381902"),
                UserId = Guid.Parse("A7497549-8106-4BCA-ADD8-7F755878BC67"),
                CartId = Guid.Parse("673AA22A-681F-4CD5-8754-383DAACA8832"),
                TotalPrice = 1900.00M
            };

            dbContext.Orders.Add(Order);

            dbContext.SaveChanges();
        }
    }
}
