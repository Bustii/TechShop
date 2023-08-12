namespace TechShop.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Services.Data.Interfaces;
    using ViewModels.Category;
    using Infrastructure.Extensions;

    using static Common.NotificationMessagesConstants;
    using static Common.GeneralApplicationConstans;

    [Authorize]
    public class CategoryController : Controller
    {

        private readonly ICategoryService categoryService;
        private readonly IProductService productService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            bool isUserAdmin = User.IsInRole(AdminRoleName);
            if (!isUserAdmin)
            {
                TempData[ErrorMessage] = "You are not authorized to add new products!";

                return RedirectToAction("All", "Product");
            }

            try
            {
                IEnumerable<AllCategoriesViewModel> viewModel =
                await categoryService.AllCategoriesForListAsync();

                return View(viewModel);
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = "Something get wrong! Please try again later.";
                return RedirectToAction("Index", "Home");
            }

        }

        [HttpGet]
        public async Task<IActionResult> Products(string name)
        {
            bool isUserAdmin = User.IsInRole(AdminRoleName);
            if (!isUserAdmin)
            {
                TempData[ErrorMessage] = "You are not authorized to add new products!";

                return RedirectToAction("All", "Product");
            }

            try
            {
                var products = await productService.AllProductsByChoosenCategoryAsync(name);

                return View(products);
            }
            catch (Exception)
            {
                return GenerealCategoryError();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id, string information)
        {
            bool categoryExists = await categoryService.ExistsByIdAsync(id);
            if (!categoryExists)
            {
                return NotFound();
            }

            CategoryDetailsViewModel viewModel =
                await categoryService.GetDetailsByIdAsync(id);

            if (viewModel.GetUrlInformation() != information)
            {
                return NotFound();
            }

            return View(viewModel);
        }

        private IActionResult GenerealCategoryError()
        {
            TempData[ErrorMessage] = "Something get wrong! Please try again later";

            var previousUrl = Request.Headers["Referer"].ToString();

            return Redirect(previousUrl);
        }
    }
}
