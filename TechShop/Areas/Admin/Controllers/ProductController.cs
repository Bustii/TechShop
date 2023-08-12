namespace TechShop.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using TechShop.Services.Data.Interfaces;
    using TechShop.Web.ViewModels.Products;

    using static Common.NotificationMessagesConstants;
    using static Common.GeneralApplicationConstans;

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
        public async Task<IActionResult> Edit(string id)
        {
            bool isUserAdmin = User.IsInRole(AdminRoleName);
            if (!isUserAdmin)
            {
                TempData[ErrorMessage] = "You are not authorized to edit products!";

                return RedirectToAction("All", "Product");
            }

            bool productExists = await productService
                .ExistsByIdAsync(id);
            if (!productExists)
            {
                TempData[ErrorMessage] = "The product with this id does not exist!";

                return RedirectToAction("All", "Product");
            }

            try
            {
                ProductFormModel productModel = await productService
                    .GetProductForEditByIdAsync(id);
                productModel.Categories = await categoryService.AllCategoriesAsync();

                return View(productModel);
            }
            catch (Exception)
            {
                return GeneralError();
            }

        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, ProductFormModel productModel)
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
                await productService.EditProductByIdAndFormModelAsync(id, productModel);
            }
            catch (Exception)
            {
                return GeneralErrorMessage();
            }

            TempData[SuccessMessage] = "You edited the product successfully.";
            return RedirectToAction("Products", "Admin");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await productService.DeleteProductByIdAsync(id);
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

        private IActionResult GeneralError()
        {
            TempData[ErrorMessage] =
                "Unexpected error occurred! Please try again later or contact administrator";

            return RedirectToAction("All", "Product");
        }
    }
}
