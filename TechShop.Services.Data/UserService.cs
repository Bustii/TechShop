namespace TechShop.Services.Data
{
    using Microsoft.EntityFrameworkCore;
    using TechShop.Data;
    using TechShop.Data.Models;
    using TechShop.Services.Data.Interfaces;

    public class UserService : IUserService
    {
        private readonly TechShopDbContext dbContext;

        public UserService(TechShopDbContext context)
        {
            this.dbContext = context;
        }

        public async Task<string> GetFullNameByEmailAsync(string email)
        {
            User? user = await this.dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);

            if (user == null)
            {
                return string.Empty;
            }

            return $"{user.FirstName} {user.LastName}";
        }
    }
}
