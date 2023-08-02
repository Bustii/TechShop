﻿namespace TechShop.Services.Data
{
    using Microsoft.EntityFrameworkCore;

    using TechShop.Data;
    using TechShop.Data.Models;
    using TechShop.Services.Data.Interfaces;
    using TechShop.Services.Data.Models;
    using TechShop.Web.ViewModels.Enums;
    using TechShop.Web.ViewModels.Home;
    using TechShop.Web.ViewModels.Products;

    public class ProductService : IProductService
    {
        private readonly TechShopDbContext dbContext;

        public ProductService(TechShopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<AllProductsFilteredServiceModel> AllAsync(AllProductsQueryModel queryModel)
        {
            IQueryable<Product> productsQuery = dbContext
                .Products
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(queryModel.Category))
            {
                productsQuery = productsQuery
                    .Where(h => h.Category.Name == queryModel.Category);
            }

            if (!string.IsNullOrWhiteSpace(queryModel.SearchString))
            {
                string wildCard = $"%{queryModel.SearchString.ToLower()}%";

                productsQuery = productsQuery
                    .Where(h => EF.Functions.Like(h.Name, wildCard) ||
                                EF.Functions.Like(h.Model, wildCard) ||
                                EF.Functions.Like(h.Description, wildCard));
            }

            productsQuery = queryModel.ProductSorting switch
            {
                ProductSorting.Newest => productsQuery
                    .OrderByDescending(h => h.CreatedOn),
                ProductSorting.Oldest => productsQuery
                    .OrderBy(h => h.CreatedOn),
                ProductSorting.PriceAscending => productsQuery
                    .OrderBy(h => h.Price),
                ProductSorting.PriceDescending => productsQuery
                    .OrderByDescending(h => h.Price),
                _ => productsQuery
                    .OrderBy(h => h.CreatedOn)
            };

            IEnumerable<ProductsAllViewModel> allProducts = await productsQuery
                .Where(h => h.IsActive)
                .Skip((queryModel.CurrentPage - 1) * queryModel.ProductsPerPage)
                .Take(queryModel.ProductsPerPage)
                .Select(h => new ProductsAllViewModel
                {
                    Id = h.Id.ToString(),
                    Name = h.Name,
                    Model = h.Model,
                    ImageUrl = h.ImageUrl,
                    Price = h.Price
                })
                .ToArrayAsync();
            int totalProducts = productsQuery.Count();

            return new AllProductsFilteredServiceModel()
            {
                TotalProductsCount = totalProducts,
                Products = allProducts
            };
        }

        public async Task<IEnumerable<ProductsAllViewModel>> AllProductsAsync(string productId)
        {
            IEnumerable<ProductsAllViewModel> allProducts = await dbContext
               .Products
               .Where(h => h.Id.ToString() == productId)
               .Select(h => new ProductsAllViewModel
               {
                   Id = h.Id.ToString(),
                   Name = h.Name,
                   Model = h.Model,
                   ImageUrl = h.ImageUrl,
                   Price = h.Price
               })
               .ToArrayAsync();

            return allProducts;
        }

        public async Task<string> CreateAndReturnIdAsync(ProductFormModel formModel)
        {
            Product newProduct = new Product()
            {
                Name = formModel.Name,
                Model = formModel.Model,
                ImageUrl = formModel.ImageUrl,
                Price = formModel.Price,
                Description = formModel.Description,
                CategoryId = formModel.CategoryId
            };

            await dbContext.Products.AddAsync(newProduct);
            await dbContext.SaveChangesAsync();

            return newProduct.Id.ToString();
        }

        public async Task EditHouseByIdAndFormModelAsync(string productId, ProductFormModel model)
        {
            Product product = await dbContext
                .Products
                .Include(h => h.Category)
                .Where(h => h.IsActive)
                .FirstAsync(h => h.Id.ToString() == productId);

            product.Name = model.Name;
            product.Model = model.Model;
            product.Description = model.Description;
            product.ImageUrl = model.ImageUrl;
            product.Price = model.Price;
            product.CategoryId = model.CategoryId;

            await dbContext.SaveChangesAsync();
        }

        public async Task<bool> ExistsByIdAsync(string productId)
        {
            bool result = await dbContext
                 .Products
                 .Where(h => h.IsActive)
                 .AnyAsync(h => h.Id.ToString() == productId);

            return result;
        }

        public async Task<ProductsDetailsViewModel> GetDetailsByIdAsync(string productId)
        {
            Product product = await dbContext
                .Products
                .Include(h => h.Category)
                //.ThenInclude(a => a.Name)
                .Where(h => h.IsActive)
                .FirstAsync(h => h.Id.ToString() == productId);

            return new ProductsDetailsViewModel
            {
                Id = product.Id.ToString(),
                Name = product.Name,
                Model = product.Model,
                ImageUrl = product.ImageUrl,
                Price = product.Price,
                Description = product.Description,
                Category = product.Category.Name
            };           
        }

        public async Task<ProductFormModel> GetProductForEditByIdAsync(string productId)
        {
            Product product = await dbContext
                 .Products
                 .Include(h => h.Category)
                 //.ThenInclude(a => a.Name)
                 .Where(h => h.IsActive)
                 .FirstAsync(h => h.Id.ToString() == productId);

            return new ProductFormModel
            {
                Name = product.Name,
                Model = product.Model,
                Description = product.Description,
                ImageUrl = product.ImageUrl,
                Price = product.Price,
                CategoryId = product.CategoryId,
            };
        }

        public async Task<IEnumerable<IndexViewModel>> LastFiveProductsAsync()
        {
            IEnumerable<IndexViewModel> lastFiveProducts = await this.dbContext
                .Products
                .OrderByDescending(p => p.Id)
                .Select(p => new IndexViewModel()
                {
                    Id = p.Id.ToString(),
                    Name = p.Name,
                    Model = p.Model,
                    ImageUrl = p.ImageUrl
                })
                .Take(5)
                .ToListAsync();

            return lastFiveProducts;
        }
    }
}
