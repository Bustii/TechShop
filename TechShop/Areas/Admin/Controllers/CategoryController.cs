namespace TechShop.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using TechShop.Services.Data.Interfaces;
    using TechShop.Web.ViewModels.Category;

    using static Common.NotificationMessagesConstants;
    public class CategoryController : BaseController
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
        public IActionResult Add()
        {
            try
            {
                var categoryModel = new NewCategoryViewModel();

                return View(categoryModel);
            }
            catch (Exception)
            {
                return GeneralErrorMessage();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(NewCategoryViewModel categoryModel)
        {
            bool isCategoryExist = await categoryService
                .IsCategoryExistByNameAsync(categoryModel.Name);

            if (isCategoryExist)
            {
                ModelState.AddModelError(nameof(categoryModel.Name), "This Category already exist");
            }

            try
            {
                await categoryService.CreateNewCategoryAsync(categoryModel);
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = "An unexpected error occurred! Please, try again.";

                return View(categoryModel);
            }

            TempData[SuccessMessage] = "Your new category have been added successfully.";
            return RedirectToAction("Categories", "Admin");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var currentCategory = await categoryService.GetCategoryByIdAsync(id);
                return View(currentCategory);
            }
            catch (Exception)
            {
                return GeneralErrorMessage();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewCategoryViewModel categoryModel)
        {

            if (!ModelState.IsValid || string.IsNullOrWhiteSpace(categoryModel.Image))
            {
                TempData[ErrorMessage] = "An unexpected error occurred! Please, try again.";

                return View(categoryModel);
            }

            try
            {
                await categoryService.EditCategoryAsync(id, categoryModel);
            }
            catch (Exception)
            {
                return GeneralErrorMessage();
            }

            TempData[SuccessMessage] = "You edited the category successfully.";
            return RedirectToAction("Categories", "Admin");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await categoryService.SoftDeleteCategoryAsync(id);
                TempData[SuccessMessage] = "You deleted category successfully.";
                return RedirectToAction("Categories", "Admin");
            }
            catch (Exception)
            {
                return GeneralErrorMessage();
            }
        }

        private IActionResult GeneralErrorMessage()
        {
            TempData[ErrorMessage] = "An unexpected error occurred! Please, try again.";

            return RedirectToAction("Categories", "Admin");
        }
    }
}
