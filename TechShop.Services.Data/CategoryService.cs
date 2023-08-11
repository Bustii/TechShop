namespace TechShop.Services.Data
{
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TechShop.Data;
    using TechShop.Data.Models;
    using TechShop.Services.Data.Interfaces;
    using TechShop.Services.Data.Models;
    using TechShop.Web.ViewModels.Category;
    using TechShop.Web.ViewModels.Enums;

    public class CategoryService : ICategoryService
    {
        private readonly TechShopDbContext dbContext;

        public CategoryService(TechShopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<ProductSelectCategoryFormModel>> AllCategoriesAsync()
        {
            IEnumerable<ProductSelectCategoryFormModel> allCategories = await dbContext
                .Categories
                .AsNoTracking()
                .Select(c => new ProductSelectCategoryFormModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                })
                .ToListAsync();

            return allCategories;
        }

        public async Task<IEnumerable<AllCategoriesViewModel>> AllCategoriesForListAsync()
        {
            IEnumerable<AllCategoriesViewModel> allCategories = await dbContext
                .Categories
                .AsNoTracking()
                .Select(c => new AllCategoriesViewModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                })
                .ToArrayAsync();

            return allCategories;
        }

        public async Task<AllCategoriesFilteredServiceModel> AllCategoriesQueryAsync(AllCategoriesQueryModel queryModel)
        {
            IQueryable<Category> categoryQuery = dbContext
                .Categories
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(queryModel.SearchString))
            {
                string wildCard = $"%{queryModel.SearchString.ToLower()}%";

                categoryQuery = categoryQuery
                    .Where(h => EF.Functions.Like(h.Name, wildCard));
            }

            categoryQuery = queryModel.CategorySorting switch
            {
                CategorySorting.NameAscending => categoryQuery
                    .OrderBy(c => c.Name),
                CategorySorting.NameDescending => categoryQuery
                        .OrderByDescending(c => c.Name),
                CategorySorting.IdAscending => categoryQuery
                    .OrderBy(c => c.Id),
                CategorySorting.IdDescending => categoryQuery
                    .OrderByDescending(c => c.Id),
                _ => categoryQuery
                    .OrderBy(c => c.Id)
            };

            IEnumerable<CategoryDetailsViewModel> allCategories = await categoryQuery
                    .Where(h => h.IsDeleted == false)
                    .Skip((queryModel.CurrentPage - 1) * queryModel.CategoriesPerPage)
                    .Take(queryModel.CategoriesPerPage)
                    .Select(h => new CategoryDetailsViewModel
                    {
                        Id = h.Id,
                        Name = h.Name,
                    })
                    .ToArrayAsync();
            int totalCategories = categoryQuery.Count();

            return new AllCategoriesFilteredServiceModel()
            {
                TotalCategoriesCount = totalCategories,
                Categories = allCategories
            };
        }

        public async Task<IEnumerable<string>> AllCategoryNamesAsync()
        {
            IEnumerable<string> allNames = await dbContext
                .Categories
                .Select(c => c.Name)
                .ToArrayAsync();

            return allNames;
        }

        public async Task CreateNewCategoryAsync(NewCategoryViewModel categoryModel)
        {
            Category category = new Category()
            {
                Name = categoryModel.Name
            };

            await dbContext.Categories.AddAsync(category);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteCategoryByIdAsync(int categoryId)
        {
            Category category = await dbContext
                .Categories
                .Where(c => c.Id == categoryId)
                .FirstAsync();

            category.IsDeleted = true;

            dbContext.Remove(category);
            await dbContext.SaveChangesAsync();
        }

        public async Task EditCategoryAsync(int cateogryId, NewCategoryViewModel categoryModel)
        {
            var currCategory = await dbContext
                .Categories
                .FindAsync(cateogryId);

            if (currCategory != null)
            {
                currCategory.Name = categoryModel.Name;
                currCategory.IsDeleted = false;

                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsByIdAsync(int id)
        {
            bool result = await dbContext
                .Categories
                .AnyAsync(c => c.Id == id);

            return result;
        }

        public async Task<NewCategoryViewModel> GetCategoryByIdAsync(int categoryId)
        {
            var category = await dbContext
                .Categories
                .Where(c => c.Id == categoryId && c.IsDeleted == false)
                .Select(c => new NewCategoryViewModel()
                {
                    Name = c.Name
                })
                .FirstAsync();

            return category;
        }

        public async Task<CategoryDetailsViewModel> GetDetailsByIdAsync(int id)
        {
            Category category = await dbContext
                .Categories
                .FirstAsync(c => c.Id == id);

            CategoryDetailsViewModel viewModel = new CategoryDetailsViewModel()
            {
                Id = category.Id,
                Name = category.Name
            };
            return viewModel;
        }

        public async Task<bool> IsCategoryExistByNameAsync(string categoryName)
        {
            var isExist = await dbContext
                .Categories
                .Where(c => c.IsDeleted == false)
                .AnyAsync(c => c.Name == categoryName);

            return isExist;
        }

        public async Task SoftDeleteCategoryAsync(int categoryId)
        {
            Category category = await dbContext
                .Categories
                .Where(c => c.Id == categoryId)
                .FirstAsync();

            category.IsDeleted = true;

            await dbContext.SaveChangesAsync();
        }
    }
}

