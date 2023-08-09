namespace TechShop.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using TechShop.Services.Data.Interfaces;
    using TechShop.Web.Infrastructure.Extensions;

    using static Common.NotificationMessagesConstants;
    [Authorize]
    public class CartController : Controller
    {
        private readonly ICartService cartService;

        public CartController(ICartService cartService)
        {
            this.cartService = cartService;
        }

        [HttpGet]
        public async Task<IActionResult> Cart()
        {
            try
            {
                var userId = User.GetId();

                var cart = await cartService.GetCurrentCartByUserIdAsync(userId!);

                return View(cart);
            }
            catch (Exception)
            {
                return GeneralErrorMessage();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(int id)
        {
            try
            {
                var userId = User.GetId();

                var cart = await cartService.GetCurrentCartByUserIdAsync(userId!);

                if (cart == null)
                {
                    await cartService.CreateCartAsync(userId!);

                    cart = await cartService.GetCurrentCartByUserIdAsync(userId!);
                }

                var cartId = cart!.Id;

                await cartService.AddProductToCartAsync(id, cartId, userId!);

                var previousUrl = Request.Headers["Referer"].ToString();

                return Redirect(previousUrl);
            }
            catch (Exception)
            {
                return GeneralErrorMessage();
            }

        }

        [HttpPost]
        public async Task<IActionResult> Remove(int id)
        {
            try
            {
                var userId = User.GetId();

                var cart = await cartService.GetCurrentCartByUserIdAsync(userId!);

                await cartService.RemoveItemFromCartAsync(id, cart!.Id);

                TempData[SuccessMessage] = "You have successfully removed the product from the cart!";

                return RedirectToAction("Cart", "Cart");

            }
            catch (Exception)
            {
                return GeneralErrorMessage();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Increase(int id)
        {
            try
            {
                var userId = User.GetId();

                var cart = await cartService.GetCurrentCartByUserIdAsync(userId!);

                await cartService.IncreaseItemCountAsync(id, cart!.Id);
            }
            catch
            {
                TempData[ErrorMessage] = "An unexpected error occurred with cart! Please, try again.";

                return RedirectToAction("Cart", "Cart");
            }

            return RedirectToAction("Cart", "Cart");

        }

        [HttpPost]
        public async Task<IActionResult> Decrease(int id)
        {
            try
            {
                var userId = User.GetId();

                var cart = await cartService.GetCurrentCartByUserIdAsync(userId!);

                await cartService.DecreaseItemCountAsync(id, cart!.Id);
            }
            catch
            {
                TempData[ErrorMessage] = "An unexpected error occurred with cart! Please, try again.";

                return RedirectToAction("Cart", "Cart");
            }

            return RedirectToAction("Cart", "Cart");
        }

        private IActionResult GeneralErrorMessage()
        {
            TempData[ErrorMessage] = "An unexpected error occurred with cart! Please, try again.";

            var previousUrl = Request.Headers["Referer"].ToString();

            return Redirect(previousUrl);
        }
    }
}
