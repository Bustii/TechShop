namespace TechShop.Services.Tests
{
    using Microsoft.EntityFrameworkCore;
    using TechShop.Data;
    using TechShop.Services.Data.Interfaces;
    using TechShop.Web.ViewModels.Products;
    using static DatabaseSeeder;

    public class ProductServiceTests
    {
        private DbContextOptions<TechShopDbContext> dbOptions;
        private TechShopDbContext dbContext;

        private IProductService productService;

        int productId;
        int categoryId;
        string userId;

        [SetUp]
        public void SetUp()
        {
            dbOptions = new DbContextOptionsBuilder<TechShopDbContext>()
                .UseInMemoryDatabase("TechShopInMemory" + Guid.NewGuid().ToString())
                .Options;

            dbContext = new TechShopDbContext(dbOptions);

            dbContext.Database.EnsureCreated();
            SeedDatabase(dbContext);

            productId = 2;
            categoryId = 2;
            userId = User!.Id.ToString();
        }

        [TearDown]
        public void TearDown()
        {
            dbContext.Database.EnsureDeleted();
        }

        [Test]
        public async Task GetAllIActiveProductsAsync_ShouldReturnListOfAllEnabledProducts()
        {
            var products = await dbContext
                .Products
                .Where(i => i.IsActive)
                .ToListAsync();

            var result = await productService.GetAllIActiveProductsAsync();

            Assert.That(products, Has.Count.EqualTo(result.Count()));
        }

        [Test]
        public async Task CreateProductAsync_ShouldAddProductToCollection()
        {
            var before = await dbContext
                .Products
                .ToListAsync();

            var model = new ProductFormModel()
            {
                Name = "Name",
                Model = "Model",
                Description = "Description",
                ImageUrl = "https://laptop.bg/system/images/361140/normal/dell_g5_15_5520_SIF15_ADLP_2301_1800_UBU.png",
                Price = 2.33M,
                CategoryId = 2,
                IsActive = true,
            };

            await productService.CreateAndReturnIdAsync(model);

            var result = await dbContext
                .Products
                .ToListAsync();

            Assert.That(result, Has.Count.EqualTo(before.Count() + 1));
        }

        [Test]
        public async Task GetProductByIdAsync_ShouldReturnCorrectProduct()
        {
            var expected = await dbContext
                .Products
                .Where(c => c.Id == productId)
                .FirstAsync();

            var result = await productService.GetProductByIdAsync(productId);

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Null);

                Assert.That(expected.Name, Is.EqualTo(result.Name));
                Assert.That(expected.Model, Is.EqualTo(result.Model));
                Assert.That(expected.Description, Is.EqualTo(result.Description));
                Assert.That(expected.Price, Is.EqualTo(result.Price));
                Assert.That(expected.Name, Is.EqualTo(result.ImageUrl));
                Assert.That(expected.CategoryId, Is.EqualTo(result.CategoryId));
                Assert.That(expected.IsActive, Is.EqualTo(result.IsActive));
            });

        }

        [Test]
        public async Task EditProductAsync_ShouldReturnModifiedItem()
        {
            var model = new ProductFormModel()
            {
                Name = "Name",
                Model = "Model",
                Description = "Description",
                ImageUrl = "https://laptop.bg/system/images/361140/normal/dell_g5_15_5520_SIF15_ADLP_2301_1800_UBU.png",
                Price = 2.33M,
                CategoryId = 2,
                IsActive = true,
            };

            await productService.EditProductAsync(productId, model);

            var result = await dbContext
                .Products
                .Where(i => i.Id == productId)
                .FirstAsync();

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Null);

                Assert.That(result.Name, Is.EqualTo(model.Name));
                Assert.That(result.Model, Is.EqualTo(model.Model));
                Assert.That(result.Description, Is.EqualTo(model.Description));
                Assert.That(result.Price, Is.EqualTo(model.Price));
                Assert.That(result.ImageUrl, Is.EqualTo(model.ImageUrl));
                Assert.That(result.CategoryId, Is.EqualTo(model.CategoryId));
                Assert.That(result.IsActive, Is.EqualTo(model.IsActive));
            });

        }

        [Test]
        public async Task GetDetailsByIdAsync_ShouldReturnRightItem()
        {
            var expected = await dbContext
                .Products
                .Where(i=>i.Id == productId)
                .FirstAsync();

            var result = await productService.GetDetailsByIdAsync(productId.ToString());

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Null);

                Assert.That(expected.Id.ToString(), Is.EqualTo(result.Id));
                Assert.That(expected.Name, Is.EqualTo(result.Name));
                Assert.That(expected.Model, Is.EqualTo(result.Model));
                Assert.That(expected.Description, Is.EqualTo(result.Description));
                Assert.That(expected.Price, Is.EqualTo(result.Price));
                Assert.That(expected.Category.Name, Is.EqualTo(result.Category));
                Assert.That(expected.ImageUrl, Is.EqualTo(result.ImageUrl));
            });
        }

        [Test]
        public async Task SoftDeleteProductAsync_ShouldTurnIsDeleteToTrue()
        {
            var product = await dbContext
                .Products
                .Where(i=>i.Id == productId)
                .FirstAsync();

            Assert.That(product.IsDeleted, Is.False);

            await productService.SoftDeleteProductAsync(productId);

            Assert.That(product.IsDeleted, Is.True);
        }

        [Test]
        public async Task TurnActivityAsync_ShouldReturnOposite()
        {
            var item = await dbContext
                .Products
                .Where(i=>i.Id == productId)
                .FirstAsync();

            item.IsActive = false;

            await productService.TurnActivityAsync(productId);

            Assert.That(item.IsActive, Is.True);
        }

        [Test]
        public async Task AllItemsByChoosenCategoryAsync_ShouldReturnArrayOfProducts()
        {
            var expected = await dbContext
                .Products
                .Where(i => i.CategoryId == categoryId)
                .ToListAsync();

            var result = await productService.AllProductsByChoosenCategoryAsync(categoryId.ToString());

            Assert.That(expected, Has.Count.EqualTo(result.Count()));
        }
    }
}
