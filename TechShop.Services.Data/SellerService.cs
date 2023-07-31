//namespace TechShop.Services.Data
//{
//    using Microsoft.EntityFrameworkCore;
//    using System.Threading.Tasks;
//    using TechShop.Data;
//    using TechShop.Data.Models;
//    using TechShop.Services.Data.Interfaces;
//    using TechShop.Web.ViewModels.Seller;

//    public class SellerService : ISellerService
//    {
//        private readonly TechShopDbContext dbContext;

//        public SellerService(TechShopDbContext dbContext)
//        {
//            this.dbContext = dbContext;
//        }

//        public async Task Create(string userId, BecomeSellerFormModel model)
//        {
//            Seller newSeller = new Seller()
//            {
//                PhoneNumber = model.PhoneNumber,
//                Email = model.Email,
//                UserId = Guid.Parse(userId)
//            };

//            await this.dbContext.Sellers.AddAsync(newSeller);
//            await this.dbContext.SaveChangesAsync();
//        }

//        public async Task<bool> HasSoldProductsByUserIdAsync(string userId)
//        {
//            ApplicationUser? user = await this.dbContext
//                .Users
//                .FirstOrDefaultAsync(u => u.Id.ToString() == userId);
//            if (user == null)
//            {
//                return false;
//            }

//            return user.BuyedProducts.Any();
//        }

//        public async Task<bool> SellerExistsByPhoneNumberAsync(string phoneNumber)
//        {
//            bool result = await this.dbContext
//                .Sellers
//                .AnyAsync(a => a.PhoneNumber == phoneNumber);

//            return result;
//        }

//        public async Task<bool> SellerExistsByUserIdAsync(string userId)
//        {
//            bool result = await this.dbContext
//                .Sellers
//                .AnyAsync(a => a.UserId.ToString() == userId);

//            return result;
//        }
//    }
//}
