namespace TechShop.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using TechShop.Services.Data.Interfaces;
    using TechShop.Web.ViewModels.Products;

    using static Common.NotificationMessagesConstants;

    public class ProductController : BaseController
    {
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            this.productService = productService;
            this.categoryService = categoryService;

        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            try
            {
                var productModel = new ProductFormModel()
                {
                    Categories = await this.categoryService.AllCategoriesAsync()
                };

                return View(productModel);
            }
            catch (Exception)
            {
                return GeneralErrorMessage();
            }

        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductFormModel productModel)
        {
            bool isCategoryExist = await categoryService
                .ExistsByIdAsync(productModel.CategoryId);

            if (!isCategoryExist)
            {
                ModelState.AddModelError(nameof(productModel.CategoryId), "Invalid Category");
            }

            if (!ModelState.IsValid)
            {
                productModel.Categories = await categoryService.AllCategoriesAsync();

                TempData[ErrorMessage] = "An unexpected error occurred! Please, try again.";

                return View(productModel);
            }

            try
            {
                await productService.CreateAndReturnIdAsync(productModel);
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = "An unexpected error occurred! Please, try again.";

                return View(productModel);
            }

            TempData[SuccessMessage] = "Your product have been added successfully.";
            return Redirect("/Product/All");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var cuurrentProduct = await productService.GetItemByIdAsync(id);
                return View(cuurrentProduct);
            }
            catch (Exception)
            {
                return GeneralErrorMessage();
            }

        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, ProductFormModel productModel)
        {
            bool isCategoryExist = await categoryService
                .ExistsByIdAsync(productModel.CategoryId);

            if (!isCategoryExist)
            {
                ModelState.AddModelError(nameof(productModel.CategoryId), "Invalid Category");
            }

            if (!ModelState.IsValid)
            {
                productModel.Categories = await categoryService.AllCategoriesAsync();
                TempData[ErrorMessage] = "An unexpected error occurred! Please, try again.";
                return View(productModel);
            }

            try
            {
                await productService.EditProductAsync(id, productModel);
            }
            catch (Exception)
            {
                return GeneralErrorMessage();
            }

            TempData[SuccessMessage] = "You edited the product successfully.";
            return RedirectToAction("Products", "Admin");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await productService.SoftDeleteItemAsync(id);
                TempData[SuccessMessage] = "You deleted the product successfully.";
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

            return RedirectToAction("Products", "Admin");
        }
    }
}
