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
                Id = Guid.Parse("BEF01BD8-5D5F-4087-9AA9-35A43E44F314"),
                UserName = "venncy961@abv.bg",
                NormalizedUserName = "VENNCY961@ABV.BG",
                Email = "venncy961@abv.bg",
                NormalizedEmail = "VENNCY961@ABV.BG",
                PasswordHash = "AQAAAAEAACcQAAAAEJ3wq0Qq48K4cAh7V4WSfAQWCOaxA6JSKNlWcaH7ke3eptu77olqAm21ImufxLgu0g==",
                ConcurrencyStamp = "88da720d-b6b6-4dc1-8114-cf7c5c238843",
                SecurityStamp = "J6ACAXB4OIGUHBB5OOUZIDWDAOZZSEGJ",
                FirstName = "Ventsislav",
                LastName = "Minev"
            };

            dbContext.Users.Add(User);

            Cart = new Cart()
            {
                Id = Guid.Parse("92df01a9-640b-4c42-bcaa-44ee936421d9"),
                UserId = Guid.Parse("be8bc990-6051-4570-9d54-30e0639d09c5"),
                CreatedOn = DateTime.Parse("2023-08-11 10:51:22.2284039")
            };

            CartProduct = new CartProduct()
            {
                CartId = Guid.Parse("6b4f7387-48d3-49cc-b031-492b4a580e03"),
                ProductId = 1,
                Quantity = 3
            };

            Cart.CartProducts.Add(CartProduct);

            dbContext.CartProducts.Add(CartProduct);
            dbContext.Carts.Add(Cart);

            Order = new Order()
            {
                Id = Guid.Parse("18279d70-fc5b-4f63-8793-9a27215f52f6"),
                FirstName = "Ventsislav",
                LastName = "Minev",
                Country = "Bulgaria",
                City = "Sofia",
                Address = "Lulin",
                PostCode = "1329",
                CreatedOn = DateTime.Parse("2023-08-11 09:52:51.9627022"),
                UserId = Guid.Parse("a78e3e26-d852-4dd4-a1b6-76451d2f5d71"),
                CartId = Guid.Parse("6b4f7387-48d3-49cc-b031-492b4a580e03"),
                TotalPrice = 5000.00M
            };

            dbContext.Orders.Add(Order);

            dbContext.SaveChanges();
        }
    }
}
