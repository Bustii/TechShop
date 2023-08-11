namespace TechShop.Services.Tests
{
    using Microsoft.EntityFrameworkCore;
    using TechShop.Data;
    using TechShop.Services.Data;
    using TechShop.Services.Data.Interfaces;
    using TechShop.Web.ViewModels.User;

    using static DatabaseSeeder;

    public class UserServiceTests
    {
        private DbContextOptions<TechShopDbContext> dbOptions;
        private TechShopDbContext dbContext;

        private IUserService userService;


        [SetUp]
        public void SetUp()
        {
            dbOptions = new DbContextOptionsBuilder<TechShopDbContext>()
                .UseInMemoryDatabase("TechShopInMemory" + Guid.NewGuid().ToString())
                .Options;

            dbContext = new TechShopDbContext(dbOptions);

            dbContext.Database.EnsureCreated();
            SeedDatabase(dbContext);

            userService = new UserService(dbContext);
        }

        [TearDown]
        public void TearDown()
        {
            dbContext.Database.EnsureDeleted();
        }


        [Test]
        public async Task GetAllUsersAsync_ShouldReturnListOfAllUsers()
        {
            var allUsers = await dbContext.Users.ToListAsync();

            var resultUser = await userService.GetAllUsersAsync();
            var usersCount = resultUser.Count();

            Assert.That(usersCount, Is.EqualTo(allUsers.Count()));
        }

        [Test]
        public async Task GetUserByIdAsync_ShouldReturnNotNull()
        {
            var userId = User!.Id;

            var user = await userService.GetUserByIdAsync(userId.ToString());
            Assert.Multiple(() =>
            {
                Assert.That(user, Is.Not.Null);

                Assert.That(User.FirstName, Is.EqualTo(user.FirstName));
                Assert.That(User.LastName, Is.EqualTo(user.LastName));
                Assert.That(User.Country, Is.EqualTo(user.Country));
                Assert.That(User.City, Is.EqualTo(user.City));
                Assert.That(User.Address, Is.EqualTo(user.Address));
                Assert.That(User.PostCode, Is.EqualTo(user.PostCode));
                Assert.That(User.Email, Is.EqualTo(user.Email));
            });
        }

        [Test]
        public async Task GetAllUsersExceptCurrOneAsync_ShouldReturnAllUsersMinusOne()
        {
            var currentUser = User;

            var allUsers = dbContext.Users.Count();
            var users = await userService.GetAllUsersExceptCurrentOneAsync(currentUser!.Id.ToString());

            Assert.That(users.Count(), Is.EqualTo(allUsers - 1));
        }

        [Test]
        public async Task EditProfileAsync_ShouldReturnEditedUser()
        {
            var user = await dbContext.Users.FirstOrDefaultAsync();

            var model = new EditUserProfileViewModel()
            {
                FirstName = "Georgi",
                LastName = "Georgiev",
                Country = "Bulgaria",
                City = "Sofia",
                Address = "NqkudeTam",
                PostCode = "2344",
                Email = "georgi@abv.bg"
            };

            await userService.EditProfileAsync(user!.Id.ToString(), model);

            Assert.Multiple(() =>
            {
                Assert.That(user, Is.Not.Null);

                Assert.That(User.FirstName, Is.EqualTo(user.FirstName));
                Assert.That(User.LastName, Is.EqualTo(user.LastName));
                Assert.That(User.Country, Is.EqualTo(user.Country));
                Assert.That(User.City, Is.EqualTo(user.City));
                Assert.That(User.Address, Is.EqualTo(user.Address));
                Assert.That(User.PostCode, Is.EqualTo(user.PostCode));
                Assert.That(User.Email, Is.EqualTo(user.Email));
            });
        }

        [Test]
        public async Task SoftDeleteUserAsync_ShouldIsDeleteGoTrue()
        {
            string userId = User!.Id.ToString();

            await userService.SoftDeleteUserAsync(userId);

            Assert.Multiple(() =>
            {
                Assert.That(User.IsDeleted, Is.True);

                Assert.That(User.FirstName, Is.Null);
                Assert.That(User.LastName, Is.Null);
                Assert.That(User.Country, Is.Null);
                Assert.That(User.City, Is.Null);
                Assert.That(User.Address, Is.Null);
                Assert.That(User.PostCode, Is.Null);
            });
        }

        [Test]
        public async Task ReverseIsAdministratorAsync_ShouldReturnOposite()
        {
            string userId = User!.Id.ToString();

            bool isAdministratorBefore = User.IsAdministrator;

            await userService.ReverseIsAdministratorAsync(userId);

            Assert.That(User.IsAdministrator, Is.Not.EqualTo(isAdministratorBefore));
        }

    }
}