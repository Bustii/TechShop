namespace TechShop.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using TechShop.Services.Data.Interfaces;
    using TechShop.Services.Data.Models;
    using TechShop.Web.ViewModels.Products;
    using static TechShop.Common.NotificationMessagesConstants;

    [Authorize]
    public class ProductController : Controller
    {
        private readonly ICategoryService categoryService;
        //private readonly ISellerService sellerService;
        private readonly IProductService productService;

        public ProductController(ICategoryService categoryService, IProductService productService)
        {
            this.categoryService = categoryService;
            this.productService = productService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> All([FromQuery] AllProductsQueryModel queryModel)
        {
            AllProductsFilteredServiceModel serviceModel =
                 await productService.AllAsync(queryModel);

            queryModel.Products = serviceModel.Products;
            queryModel.TotalProducts = serviceModel.TotalProductsCount;
            queryModel.Categories = await categoryService.AllCategoryNamesAsync();

            return View(queryModel);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(string id)
        {
            bool productExists = await productService
                .ExistsByIdAsync(id);
            if (!productExists)
            {
                TempData[ErrorMessage] = "Products with the provided id does not exist!";

                return RedirectToAction("All", "Product");
            }

            try
            {
                ProductsDetailsViewModel viewModel = await productService
                    .GetDetailsByIdAsync(id);

                return View(viewModel);
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            try
            {
                ProductFormModel formModel = new ProductFormModel()
                {
                    Categories = await categoryService.AllCategoriesAsync()
                };

                return View(formModel);
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }
        [HttpPost]
        public async Task<IActionResult> Add(ProductFormModel productModel)
        {

            bool productCategoryExists =
                await categoryService.ExistsByIdAsync(productModel.CategoryId);
            if (!productCategoryExists)
            {
                // Adding model error to ModelState automatically makes ModelState Invalid
                ModelState.AddModelError(nameof(productModel.CategoryId), "Selected category does not exist!");
            }

            if (!ModelState.IsValid)
            {
                productModel.Categories = await categoryService.AllCategoriesAsync();

                return View(productModel);
            }

            try
            {
                string productId =
                    await productService.CreateAndReturnIdAsync(productModel);

                TempData[SuccessMessage] = "Product was added successfully!";
                return RedirectToAction("All", "Product", new { id = productId });
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Unexpected error occurred while trying to add your new product! Please try again later or contact administrator!");
                productModel.Categories = await categoryService.AllCategoriesAsync();

                return View(productModel);
            }
        }
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
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
            if (!ModelState.IsValid)
            {
                productModel.Categories = await categoryService.AllCategoriesAsync();

                return View(productModel);
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
                await productService.EditProductByIdAndFormModelAsync(id, productModel);
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty,
                    "Unexpected error occurred! Please try again later or contact administrator");
                productModel.Categories = await categoryService.AllCategoriesAsync();

                return View(productModel);
            }

            TempData[SuccessMessage] = "Product was edited successfully!";
            return RedirectToAction("Details", "Product", new { id });
        }

        private IActionResult GeneralError()
        {
            TempData[ErrorMessage] =
                "Unexpected error occurred! Please try again later or contact administrator";

            return RedirectToAction("All", "Product");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            bool productExists = await productService
                .ExistsByIdAsync(id);
            if (!productExists)
            {
                TempData[ErrorMessage] = "The product with this id does not exist!";

                return RedirectToAction("All", "Product");
            }

            try
            {
                ProductPreDeleteDetailsViewModel productModel =
                    await productService.GetProductForDeleteByIdAsync(id);

                return View(productModel);
            }

            catch (Exception)
            {
                return GeneralError();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id, ProductPreDeleteDetailsViewModel model)
        {
            bool productExists = await productService
                .ExistsByIdAsync(id);
            if (!productExists)
            {
                TempData[ErrorMessage] = "The product with this id does not exist!";

                return RedirectToAction("All", "Product");
            }

            try
            {
                await productService.DeleteProductByIdAsync(id);

                TempData[WarningMessage] = "The product was successfully deleted!";
                return RedirectToAction("All", "Product");
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }
    }
}
    
    
    
