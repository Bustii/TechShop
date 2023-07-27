namespace TechShop.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using TechShop.Services.Data.Interfaces;
    using TechShop.Web.Infrastructure.Extensions;

    using ViewModels.Seller;
    using Microsoft.AspNetCore.Authorization;

    using static Common.NotificationMessagesConstants;

    [Authorize]
    public class SellerController : Controller
    {
        private readonly ISellerService sellerService;

        public SellerController(ISellerService sellerService)
        {
            this.sellerService = sellerService;
        }

        [HttpGet]
        public async Task<IActionResult> BecomeSeller()
        {
            string? userId = this.User.GetId();
            bool isSeller = await this.sellerService.SellerExistsByUserIdAsync(userId);
            if (isSeller)
            {
                this.TempData[ErrorMessage] = "You are already an seller!";

                return this.RedirectToAction("Index", "Home");
            }

            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> BecomeSeller(BecomeSellerFormModel model)
        {
            string? userId = this.User.GetId();
            bool isSeller = await this.sellerService.SellerExistsByUserIdAsync(userId);
            if (isSeller)
            {
                this.TempData[ErrorMessage] = "You are already an seller!";

                return this.RedirectToAction("Index", "Home");
            }

            bool isPhoneNumberTaken =
                await this.sellerService.SellerExistsByUserIdAsync(model.PhoneNumber);
            if (isPhoneNumberTaken)
            {
                this.ModelState.AddModelError(nameof(model.PhoneNumber), "Seller with the provided phone number already exists!");
            }

            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            bool userHasSoldProducts = await this.sellerService
                .HasSoldProductsByUserIdAsync(userId);
            if (userHasSoldProducts)
            {
                this.TempData[ErrorMessage] = "You must not have any products in the shop cart to become an seller!";

                return this.RedirectToAction("All", "Products"); // TODO
            }

            try
            {
                await this.sellerService.Create(userId, model);
            }
            catch (Exception)
            {
                this.TempData[ErrorMessage] =
                    "Unexpected error occurred while registering you as an seller! Please try again later or contact administrator.";

                return this.RedirectToAction("Index", "Home");
            }

            return this.RedirectToAction("All", "Products");
        }
    }
}
