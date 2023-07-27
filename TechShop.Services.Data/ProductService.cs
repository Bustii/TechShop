﻿namespace TechShop.Services.Data
{
    using Microsoft.EntityFrameworkCore;
       
    using TechShop.Data;
    using TechShop.Services.Data.Interfaces;
    using TechShop.Web.ViewModels.Home;

    public class ProductService : IProductService
    {
        private readonly TechShopDbContext dbContext;

        public ProductService(TechShopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<IndexViewModel>> LastFivePcsAsync()
        {
            IEnumerable<IndexViewModel> lastFiveProducts = await this.dbContext
                .Products
                .OrderByDescending(p => p.CreatedOn)
                .Take(5)
                .Select(p => new IndexViewModel()
                {
                    Id = p.Id.ToString(),
                    Name = p.Name,
                    Model = p.Model,
                    ImageUrl = p.ImageUrl
                })
                .ToArrayAsync();

            return lastFiveProducts;
        }
    }
}