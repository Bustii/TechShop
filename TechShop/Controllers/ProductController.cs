namespace TechShop.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using TechShop.Services.Data.Interfaces;
    using Infrastructure.Extensions;
    using TechShop.Web.ViewModels.Products;
    using TechShop.Services.Data.Models;

    [Authorize]
    public class ProductController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly ISellerService sellerService;
        private readonly IProductService productService;

        public ProductController(ICategoryService categoryService, ISellerService sellerService, IProductService productService)
        {
            this.sellerService = sellerService;
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
    }
}
