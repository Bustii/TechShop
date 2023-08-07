namespace TechShop.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using TechShop.Services.Data.Interfaces;

    [Authorize]
    public class BuyerController : Controller
    {
        private readonly IBuyerService buyerService;

        public BuyerController(IBuyerService buyerService)
        {
            this.buyerService = buyerService;
        }

        public IActionResult Index()
        {
            return Ok();
        }
    }
}
