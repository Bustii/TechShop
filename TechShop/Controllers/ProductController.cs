namespace TechShop.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using TechShop.Services.Data.Interfaces;
    using TechShop.Services.Data.Models;
    using TechShop.Web.Infrastructure.Extensions;
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
        public async Task<IActionResult> All([FromQuery]AllProductsQueryModel queryModel)
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
                TempData[SuccessMessage] = "Product was added successfully!";
                return RedirectToAction("All", "Product");
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Unexpected error occurred while trying to add your new house! Please try again later or contact administrator!");
                productModel.Categories = await categoryService.AllCategoriesAsync();

                return View(productModel);
            }
        }

        private IActionResult GeneralError()
        {
            TempData[ErrorMessage] =
                "Unexpected error occurred! Please try again later or contact administrator";

            return RedirectToAction("All", "Product");
        }
    }
}
