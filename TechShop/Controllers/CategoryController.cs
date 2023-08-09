namespace TechShop.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Services.Data.Interfaces;
    using ViewModels.Category;
    using Infrastructure.Extensions;

    using static Common.NotificationMessagesConstants;
    [Authorize]
    public class CategoryController : Controller
    {

        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
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
