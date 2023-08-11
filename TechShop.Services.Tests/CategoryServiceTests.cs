namespace TechShop.Services.Tests
{
    using Microsoft.EntityFrameworkCore;

    using TechShop.Services.Data.Interfaces;
    using TechShop.Services.Data;
    using TechShop.Data;
    using TechShop.Web.ViewModels.Category;

    using static DatabaseSeeder;

    public class CategoryServiceTests
    {
        private DbContextOptions<TechShopDbContext> dbOptions;
        private TechShopDbContext dbContext;

        private ICategoryService categoryService;

        int categoryId;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this.dbOptions = new DbContextOptionsBuilder<TechShopDbContext>()
                 .UseInMemoryDatabase("TechShopInMemory" + Guid.NewGuid().ToString())
                .Options;
            dbContext = new TechShopDbContext(dbOptions);

            dbContext.Database.EnsureCreated();
            SeedDatabase(this.dbContext);

            categoryService = new CategoryService(dbContext);

            categoryId = 2;
        }

        [TearDown]
        public void TearDown()
        {
            dbContext.Database.EnsureDeleted();
        }

        [Test]
        public async Task AllCateagoriesAsync_ShouldReturnAllCategories()
        {
            var expected = await dbContext
                .Categories
                .ToListAsync();

            var result = await categoryService.AllCategoriesAsync();

            Assert.That(expected, Has.Count.EqualTo(result.Count()));
        }

        [Test]
        public async Task IsCategoryExistAsync_ShouldReturnTrue()
        {
            bool result = await categoryService.ExistsByIdAsync(categoryId);

            Assert.That(result, Is.True);
        }

        [Test]
        public async Task IsCategoryExistAsync_ShouldReturnFalse()
        {
            int notExistingCateogryId = 2332246;

            bool result = await categoryService.ExistsByIdAsync(notExistingCateogryId);

            Assert.That(result, Is.False);
        }

        [Test]
        public async Task AllCategoriesNameAsync_ShouldReturnArrayOfAllCategoryNames()
        {
            var expected = await dbContext
                .Categories
                .Where(c => c.IsDeleted == false)
                .Select(c => c.Name)
                .ToArrayAsync();

            var result = await categoryService.AllCategoryNamesAsync();

            CollectionAssert.AreEqual(expected, result);
        }

        [Test]
        public async Task IsCategoryExistByNameAsync_ShouldReturnTrue()
        {
            var categoryName = await dbContext
                .Categories
                .Where(c => c.Id == categoryId)
                .Select(c => c.Name)
                .FirstAsync();

            bool result = await categoryService.IsCategoryExistByNameAsync(categoryName);

            Assert.That(result, Is.True);
        }

        [Test]
        public async Task IsCategoryExistByNameAsync_ShouldReturnFalse()
        {
            var categoryName = "Unexisting Category";

            bool result = await categoryService.IsCategoryExistByNameAsync(categoryName);

            Assert.That(result, Is.False);
        }

        [Test]
        public async Task CreateNewCategoryAsync_ShouldIncreaseCountOfCollection()
        {
            int currCount = await dbContext
                .Categories.CountAsync();

            var model = new NewCategoryViewModel()
            {
                Name = "Test"
            };

            await categoryService.CreateNewCategoryAsync(model);

            int resultCount = await dbContext
                .Categories.CountAsync();

            Assert.That(resultCount, Is.EqualTo(currCount+1));
        }

        [Test]
        public async Task GetCategoryByIdAsync_ShouldReturnRightCateogry()
        {
            var expect = await dbContext
                .Categories
                .Where(c => c.Id == categoryId && !c.IsDeleted)
                .FirstAsync();

            var result = await categoryService.GetCategoryByIdAsync(categoryId);

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Null);

                Assert.That(expect.Name, Is.EqualTo(result.Name));
            });
        }

        [Test]
        public async Task EditCategoryAsync_ShouldReturnEditedCategory()
        {
            var model = new NewCategoryViewModel()
            {
                Name = "Edit Category Name"
            };

            await categoryService.EditCategoryAsync(categoryId, model);

            var result = await dbContext
                .Categories
                .Where(c => c.Id == categoryId && !c.IsDeleted)
                .FirstAsync();

            Assert.Multiple(() =>
            {
                Assert.That(result.Name, Is.EqualTo(model.Name));
            });


        }

        [Test]
        public async Task SoftDeleteCategoryAsync_ShouldTurnIsDeleteToTrue()
        {
            var category = await dbContext
                .Categories
                .Where(c=>c.Id == categoryId)
                .FirstAsync();

            category.IsDeleted = false;

            await categoryService.SoftDeleteCategoryAsync(categoryId);

            Assert.That(category.IsDeleted, Is.True);
        }
    }
}
