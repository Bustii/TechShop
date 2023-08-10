namespace TechShop.Services.Data
{
    using Microsoft.EntityFrameworkCore;
    using PetShop.Web.ViewModels.User.Enums;
    using System.Collections.Generic;
    using TechShop.Data;
    using TechShop.Data.Models;
    using TechShop.Services.Data.Interfaces;
    using TechShop.Services.Data.Models.User;
    using TechShop.Web.ViewModels.User;

    public class UserService : IUserService
    {
        private readonly TechShopDbContext dbContext;

        public UserService(TechShopDbContext context)
        {
            this.dbContext = context;
        }

        public async Task<bool> UserExistsByIdAsync(string userId)
        {
            bool result = await dbContext
                .Users
                .AnyAsync(a => a.Id.ToString() == userId);

            return result;
        }

        public async Task<AllUsersFilteredServiceModel> AllUsersQueryAsync(AllUsersQueryModel queryModel)
        {
            IQueryable<ApplicationUser> userQuery = dbContext
                .Users
                .Where(u => u.IsDeleted == false)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(queryModel.SearchString))
            {
                string wildCard = $"%{queryModel.SearchString.ToLower()}%";

                userQuery = userQuery
                    .Where(c => EF.Functions.Like(c.UserName, wildCard) ||
                                EF.Functions.Like(c.Email, wildCard) ||
                                EF.Functions.Like(c.Address!, wildCard) ||
                                EF.Functions.Like(c.PhoneNumber, wildCard));
            }

            userQuery = queryModel.ItemSorting switch
            {
                UsersSorting.NameAscending => userQuery
                    .OrderBy(u => u.UserName),
                UsersSorting.NameDescending => userQuery
                    .OrderByDescending(u => u.UserName),
                UsersSorting.CreatedAscending => userQuery
                .OrderBy(u => u.CreatedOn),
                UsersSorting.CreatedDescending => userQuery
                .OrderByDescending(u => u.CreatedOn),
                _ => userQuery
                    .OrderBy(u => u.CreatedOn)
            };

            IEnumerable<UserViewModel> searchedUsers = await userQuery
                .Where(u => u.IsDeleted == false)
                .Skip((queryModel.CurrentPage - 1) * queryModel.UsersPerPage)
                .Take(queryModel.UsersPerPage)
                .Select(u => new UserViewModel()
                {
                    Id = u.Id.ToString(),
                    UserName = u.UserName,
                    Email = u.Email,
                    IsAdministrator = u.IsAdministrator,
                    CreatedOn = u.CreatedOn
                })
                .ToArrayAsync();

            int totalUsers = userQuery.Count();

            return new AllUsersFilteredServiceModel()
            {
                TotalUsersCount = totalUsers,
                Users = searchedUsers
            };
        }

        public async Task EditProfileAsync(string userId, EditUserProfileViewModel model)
        {
            var user = await dbContext
               .Users
               .Where(u => u.Id.ToString() == userId
                        && u.IsDeleted == false)
               .FirstAsync();

            if (user != null)
            {
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.Country = model.Country;
                user.City = model.City;
                user.Address = model.Address;
                user.PostCode = model.PostCode;
                user.Email = model.Email;

                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<UserViewModel>> GetAllUsersAsync()
        {
            var allUsers = await dbContext
               .Users
               .Select(u => new UserViewModel()
               {
                   Id = u.Id.ToString(),
                   UserName = u.UserName,
                   Email = u.Email,
                   IsAdministrator = u.IsAdministrator,
                   CreatedOn = u.CreatedOn,
               })
               .ToArrayAsync();

            return allUsers;
        }

        public async Task<IEnumerable<UserViewModel>> GetAllUsersExceptCurrentOneAsync(string userId)
        {
            var allUsers = await dbContext
                .Users
                .Where(u => u.Id.ToString() != userId)
                .Select(u => new UserViewModel()
                {
                    Id = u.Id.ToString(),
                    UserName = u.UserName,
                    Email = u.Email,
                    IsAdministrator = u.IsAdministrator,
                    CreatedOn = u.CreatedOn,
                })
                .ToArrayAsync();

            return allUsers;
        }

        public async Task<string> GetFullNameByEmailAsync(string email)
        {
            ApplicationUser? user = await this.dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);

            if (user == null)
            {
                return string.Empty;
            }

            return $"{user.FirstName} {user.LastName}";
        }

        public async Task<EditUserProfileViewModel> GetUserByIdAsync(string userId)
        {
            var userModel = await dbContext
                .Users
                .Where(u => u.Id.ToString() == userId
                       && u.IsDeleted == false)
                .Select(u => new EditUserProfileViewModel()
                {
                    Id = u.Id.ToString(),
                    Email = u.Email,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Country = u.Country,
                    City = u.City,
                    Address = u.Address,
                    PostCode = u.PostCode,
                })
                .FirstAsync();

            return userModel;
        }

        public async Task ReverseIsAdministratorAsync(string userId)
        {
            var user = await dbContext
                .Users
                .Where(u => u.Id.ToString() == userId
                       && u.IsDeleted == false)
                .FirstAsync();

            user.IsAdministrator = !user.IsAdministrator;

            await dbContext.SaveChangesAsync();
        }

        public async Task SoftDeleteUserAsync(string userId)
        {
            var user = await dbContext
            .Users
            .Where(u => u.Id.ToString() == userId
            && u.IsDeleted == false)
            .FirstAsync();

            user.FirstName = null;
            user.LastName = null;
            user.Country = null;
            user.City = null;
            user.Address = null;
            user.PostCode = null;
            user.IsDeleted = true;

            await dbContext.SaveChangesAsync();
        }
    }
}
