namespace TechShop.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class ProductController : Controller
    {
        [AllowAnonymous]
        public IActionResult All()
        {
            return View();
        }
    }
}
