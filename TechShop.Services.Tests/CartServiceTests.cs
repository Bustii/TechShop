namespace TechShop.Services.Tests
{
    using Microsoft.EntityFrameworkCore;

    using TechShop.Services.Data.Interfaces;
    using TechShop.Services.Data;
    using TechShop.Data;

    using static DatabaseSeeder;

    public class CartServiceTests
    {
        private DbContextOptions<TechShopDbContext> dbOptionsContext;
        private TechShopDbContext dbContext;

        private ICartService cartService;

        int productId;
        string userId;
        string orderId;
        string cartId;

        [SetUp]
        public void SetUp()
        {
            dbOptionsContext = new DbContextOptionsBuilder<TechShopDbContext>()
                .UseInMemoryDatabase("TechShopInMemory" + Guid.NewGuid().ToString())
                .Options;

            dbContext = new TechShopDbContext(dbOptionsContext);

            dbContext.Database.EnsureCreated();
            SeedDatabase(dbContext);

            cartService = new CartService(dbContext);

            productId = 1;
            userId = User!.Id.ToString();
            orderId = Order!.Id.ToString();
            cartId = Cart!.Id.ToString();
        }

        [TearDown]
        public void TearDown()
        {
            dbContext.Database.EnsureDeleted();
        }

        [Test]
        public async Task GetCurrentCartByUserIdAsync_ShouldReturnLastCreatedCartOfThisUser()
        {
            var expected = await dbContext
                .Carts
                .Where(c => c.UserId.ToString() == userId)
                .LastAsync();

            var result = await cartService.GetCurrentCartByUserIdAsync(userId);

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Null);

                Assert.That(expected.Id.ToString(), Is.EqualTo(result.Id));
                Assert.That(expected.CartProducts.Count(), Is.EqualTo(result.Products.Count()));
            });

        }

        [Test]
        public async Task GetCartByOrderIdAsync_ShouldReturnRightCart()
        {
            var expected = await dbContext
                .Orders
                .Where(o => o.Id.ToString() == orderId)
                .Select(o => o.Cart)
                .FirstAsync();

            var result = await cartService.GetCartByOrderIdAsync(orderId);

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Null);

                Assert.That(expected.Id.ToString(), Is.EqualTo(result.Id));
                Assert.That(expected.CartProducts.Count(), Is.EqualTo(result.Products.Count()));
            });
        }

        [Test]
        public async Task CreateCartAsync_ShouldCreateNewCard()
        {
            var before = dbContext
                .Carts
                .Where(c=>c.UserId.ToString()==userId)
                .Count();

            await cartService.CreateCartAsync(userId);

            var result = dbContext
                .Carts
                .Where(c => c.UserId.ToString() == userId)
                .Count();

            Assert.That(result, Is.EqualTo(before + 1));
        }

        [Test]
        public async Task AddProductToCartAsync_ShouldAddProductToCurrentUserCart()
        {
            var before = dbContext
                .CartProducts
                .Where(c => c.ProductId == productId && c.CartId.ToString() == cartId)
                .Count();

            await cartService.AddProductToCartAsync(productId, cartId, userId);

            var result = dbContext
                .CartProducts
                .Where(c => c.ProductId == productId && c.CartId.ToString() == cartId)
                .Count();

            Assert.That(result, Is.EqualTo(before + 1));

        }

        [Test]
        public async Task AddProductToCartAsync_ShouldIncreaseQuantity()
        {
            await cartService.AddProductToCartAsync(productId, cartId, userId);

            int before = dbContext
                .CartProducts
                .Where(c => c.ProductId == productId && c.CartId.ToString() == cartId)
                .Select(c=>c.Quantity)
                .First();

            await cartService.AddProductToCartAsync(productId, cartId, userId);

            int result = dbContext
               .CartProducts
               .Where(c => c.ProductId == productId && c.CartId.ToString() == cartId)
               .Select(c => c.Quantity)
               .First();

            Assert.That(result, Is.EqualTo(before + 1));
        }

        [Test]
        public async Task RemoveProductFromCartAsync_ShouldRemoveProductFromCollection()
        {
            int alreadyAddedCartIProductId = 3;

            int before = dbContext
               .CartProducts
               .Where(c => c.CartId.ToString() == cartId)
               .Count();

            await cartService.RemoveProductFromCartAsync(alreadyAddedCartIProductId, cartId);

            int result = dbContext
               .CartProducts
               .Where(c => c.CartId.ToString() == cartId)
               .Count();

            Assert.That(result, Is.EqualTo(before - 1));
        }

        [Test]
        public async Task IncreaseProductCountAsync_ShouldIncreaseQuantityOfProduct()
        {
            int alreadyAddedCartProductId = 3;

            int before = dbContext
                .CartProducts
                .Where(c => c.ProductId == alreadyAddedCartProductId && c.CartId.ToString() == cartId)
                .Select(c => c.Quantity)
                .First();

            await cartService.IncreaseProductCountAsync(alreadyAddedCartProductId, cartId);

            int result = dbContext
                .CartProducts
                .Where(c => c.ProductId == alreadyAddedCartProductId && c.CartId.ToString() == cartId)
                .Select(c => c.Quantity)
                .First();

            Assert.That(result, Is.EqualTo(before + 1));
        }

        [Test]
        public async Task DecreaseProductCountAsync_ShouldDecreaseQuantityOfProduct()
        {
            int alreadyAddedCartProductId = 3;

            int before = dbContext
                .CartProducts
                .Where(c => c.ProductId == alreadyAddedCartProductId && c.CartId.ToString() == cartId)
                .Select(c => c.Quantity)
                .First();

            await cartService.DecreaseProductCountAsync(alreadyAddedCartProductId, cartId);

            int result = dbContext
                .CartProducts
                .Where(c => c.ProductId == alreadyAddedCartProductId && c.CartId.ToString() == cartId)
                .Select(c => c.Quantity)
                .First();

            Assert.That(result, Is.EqualTo(before - 1));
        }
    }
}
