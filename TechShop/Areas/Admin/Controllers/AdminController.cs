namespace TechShop.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using TechShop.Data.Models;
    using TechShop.Services.Data.Interfaces;
    using TechShop.Web.ViewModels.Category;
    using TechShop.Web.ViewModels.Products;
    using TechShop.Web.ViewModels.User;

    using static Common.NotificationMessagesConstants;
    using static Common.GeneralApplicationConstans;

    public class AdminController : BaseController
    {
        private readonly IProductService productService;
        private readonly IUserService userService;
        private readonly ICategoryService categoryService;
        private readonly UserManager<ApplicationUser> userManager;

        public AdminController(
            IProductService productService, 
            IUserService userService, 
            ICategoryService categoryService,
            UserManager<ApplicationUser> userManager)
        {
            this.productService = productService;
            this.userService = userService;
            this.categoryService = categoryService;
            this.userManager = userManager;

        }

        public async Task<IActionResult> Products([FromQuery] AllProductsQueryModel queryModel)
        {
            try
            {
                var allProducts = await productService.AllAsync(queryModel);

                queryModel.Products = allProducts.Products;
                queryModel.TotalProducts = allProducts.TotalProductsCount;
                queryModel.Categories = await categoryService.AllCategoryNamesAsync();

                return View(queryModel);
            }
            catch (Exception)
            {
                return GeneralErrorMessage();
            }
        }

        public async Task<IActionResult> Categories([FromQuery] AllCategoriesQueryModel queryModel)
        {
            try
            {
                var allCategories = await categoryService.AllCategoriesQueryAsync(queryModel);

                queryModel.Categories = allCategories.Categories;
                queryModel.TotalCategories = allCategories.TotalCategoriesCount;

                return View(queryModel);
            }
            catch (Exception)
            {
                return GeneralErrorMessage();
            }

        }

        public async Task<IActionResult> Users([FromQuery] AllUsersQueryModel queryModel)
        {
            try
            {
                var allUsers = await userService.AllUsersQueryAsync(queryModel);

                queryModel.Users = allUsers.Users;
                queryModel.TotalUsers = allUsers.TotalUsersCount;

                return View(queryModel);
            }
            catch (Exception)
            {
                return GeneralErrorMessage();
            }
        }

        [HttpPost]
        public async Task<IActionResult> SetRole(string userId, bool isModerator)
        {
            var user = await userManager.FindByIdAsync(userId);
            var roles = await userManager.GetRolesAsync(user);
            bool isChecked = roles.Any(r => r.Contains(AdminRoleName));

            try
            {
                if (!isChecked)
                {
                    await userManager.AddToRoleAsync(user, AdminRoleName);
                }
                else if (isChecked)
                {
                    await userManager.RemoveFromRoleAsync(user, AdminRoleName);
                }

                await userService.ReverseIsAdministratorAsync(userId);
                return RedirectToAction("Users", "Admin");
            }
            catch (Exception)
            {
                return GeneralErrorMessage();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Enable(int id)
        {
            try
            {
                await productService.TurnActivityAsync(id);
                ProductFormModel currentItem = await productService.GetProductByIdAsync(id);

                TempData[SuccessMessage] = currentItem.IsActive ? "You Deactivated the product successfully." : "You Activated the product successfully.";

                return RedirectToAction("Products", "Admin");
            }
            catch (Exception)
            {
                return GeneralErrorMessage();
            }
        }

        private IActionResult GeneralErrorMessage()
        {
            TempData[ErrorMessage] = "An unexpected error occurred! Please, try again.";

            return RedirectToAction("Index", "Admin");
        }
    }
}
