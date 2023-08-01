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

                return RedirectToAction("All", "Products");
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

        private IActionResult GeneralError()
        {
            TempData[ErrorMessage] =
                "Unexpected error occurred! Please try again later or contact administrator";

            return RedirectToAction("Index", "Home");
        }
    }
}
