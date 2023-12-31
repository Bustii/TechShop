﻿namespace TechShop.Services.Data
{
    using Microsoft.EntityFrameworkCore;

    using TechShop.Data;
    using TechShop.Data.Models;
    using TechShop.Services.Data.Interfaces;
    using TechShop.Services.Data.Models;
    using TechShop.Web.ViewModels.Category;
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

        public async Task DeleteProductByIdAsync(string productId)
        {
            Product productToDelete = await dbContext
                .Products
                .Where(h => h.IsActive)
                .FirstAsync(h => h.Id.ToString() == productId);

            productToDelete.IsActive = false;

            dbContext.Remove(productToDelete);
            await dbContext.SaveChangesAsync();
        }

        public async Task EditProductByIdAndFormModelAsync(string productId, ProductFormModel productModel)
        {
            Product product = await dbContext
                .Products
                .Include(h => h.Category)
                .Where(h => h.IsActive)
                .FirstAsync(h => h.Id.ToString() == productId);

            product.Name = productModel.Name;
            product.Model = productModel.Model;
            product.Description = productModel.Description;
            product.ImageUrl = productModel.ImageUrl;
            product.Price = productModel.Price;
            product.CategoryId = productModel.CategoryId;

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

        public async Task<ProductPreDeleteDetailsViewModel> GetProductForDeleteByIdAsync(string productId)
        {
            Product product = await dbContext
                .Products
                .Where(h => h.IsActive)
                .FirstAsync(h => h.Id.ToString() == productId);

            return new ProductPreDeleteDetailsViewModel
            {
                Name = product.Name,
                Model = product.Model,
                ImageUrl = product.ImageUrl
            };
        }

        public async Task<ProductFormModel> GetProductForEditByIdAsync(string productId)
        {
            Product product = await dbContext
                 .Products
                 .Include(h => h.Category)
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

        public async Task TurnActivityAsync(int productId)
        {
            Product currentProduct = await dbContext
                .Products
                .Where(i => i.Id == productId)
                .FirstAsync();

            currentProduct.IsActive = !currentProduct.IsActive;

            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<IndexViewModel>> LastFiveProductsAsync()
        {
            IEnumerable<IndexViewModel> lastFiveProducts = await this.dbContext
                .Products
                .OrderByDescending(p => p.Id)
                .Select(p => new IndexViewModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Model = p.Model,
                    ImageUrl = p.ImageUrl
                })
                .Take(5)
                .ToListAsync();

            return lastFiveProducts;
        }

        public async Task<ProductFormModel> GetProductByIdAsync(int productId)
        {
            var categories = await dbContext
                .Categories
                .Select(c => new CategoryDetailsViewModel()
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();


            var currentProduct = await dbContext
                .Products
                .Where(i => i.Id == productId)
                .Select(i => new ProductFormModel()
                {
                    Name = i.Name,
                    Model = i.Model,
                    Description = i.Description,
                    Price = i.Price,
                    ImageUrl = i.ImageUrl,
                    CategoryId = i.CategoryId,
                    IsActive = i.IsActive
                })
                .FirstAsync();

            return currentProduct;
        }

        public async Task SoftDeleteProductAsync(int productId)
        {
            Product product = await dbContext
                .Products
                .Where(i => !i.IsDeleted && i.Id == productId)
                .FirstAsync();


            product.IsActive = false;
            product.IsDeleted = true;

            await dbContext.SaveChangesAsync();
        }

        public async Task EditProductAsync(int id, ProductFormModel productModel)
        {
            var currItem = await dbContext
                .Products
                .FindAsync(id);

            if (currItem != null)
            {
                currItem.Name = productModel.Name;
                currItem.Model = productModel.Model;
                currItem.Description = productModel.Description;
                currItem.Price = productModel.Price;
                currItem.ImageUrl = productModel.ImageUrl;
                currItem.CategoryId = productModel.CategoryId;
                currItem.LastEdit = DateTime.UtcNow;

                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<IndexViewModel>> GetAllIActiveProductsAsync()
        {
            var allProducts = await dbContext
                .Products
                .Where(i => i.IsActive)
                .Select(i => new IndexViewModel
                {
                    Id = i.Id,
                    Name = i.Name,
                    Model = i.Model,
                    ImageUrl = i.ImageUrl
                })
                .ToArrayAsync();

            return allProducts;
        }

        public async Task<IEnumerable<IndexViewModel>> AllProductsByChoosenCategoryAsync(string name)
        {
            var allItems = await dbContext
               .Products
               .Where(i => i.Category.Name == name && i.IsActive && i.Category.IsDeleted == false)
               .Select(i => new IndexViewModel()
               {
                   Id = i.Id,
                   Name = i.Name,
                   Model = i.Model,
                   ImageUrl = i.ImageUrl,
               })
               .ToArrayAsync();

            return allItems;
        }
    }
}
