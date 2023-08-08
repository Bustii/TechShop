namespace TechShop.Services.Data
{
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TechShop.Data;
    using TechShop.Services.Data.Interfaces;
    using TechShop.Web.ViewModels.BuyedProducts;

    public class BuyedProductsService : IBuyedProductsService
    {
        private readonly TechShopDbContext dbContext;

        public BuyedProductsService(TechShopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<IEnumerable<BuyedProductsViewModel>> AllBuyedProductsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
