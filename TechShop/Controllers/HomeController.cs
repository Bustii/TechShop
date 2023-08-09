namespace TechShop_Project.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;
    using TechShop.Services.Data.Interfaces;
    using TechShop.Web.ViewModels.Home;

    public class HomeController : Controller
    {
        private readonly IProductService productService;

        public HomeController(IProductService productService)
        {
            this.productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<IndexViewModel> viewModels =
                await this.productService.LastFiveProductsAsync();

            return View(viewModels);

            return Ok();
        }
      

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}