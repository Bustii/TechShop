namespace TechShop.Web.Controllers
{
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using TechShop.Data.Models;
    using TechShop.Web.ViewModels.User;
    using static Common.NotificationMessagesConstants;
    public class UserController : Controller
    {
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;

        public UserController(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterFormModel registerModel)
        {
            if (!ModelState.IsValid)
            {
                return View(registerModel);
            }

            User user = new User()
            {
                FirstName = registerModel.FirstName,
                LastName = registerModel.LastName
            };

            await userManager.SetEmailAsync(user, registerModel.Email);
            await userManager.SetUserNameAsync(user, registerModel.Email);

            IdentityResult result =
                await userManager.CreateAsync(user, registerModel.Password);

            if (!result.Succeeded)
            {
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

                return View(registerModel);
            }

            await signInManager.SignInAsync(user, false);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Login(string? returnUrl = null)
        {
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            LoginFormModel loginModel = new LoginFormModel()
            {
                ReturnUrl = returnUrl
            };

            return View(loginModel);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginFormModel loginModel)
        {
            if (!ModelState.IsValid)
            {
                return View(loginModel);
            }

            var result =
                await signInManager.PasswordSignInAsync(loginModel.Email, loginModel.Password, loginModel.RememberMe, false);

            if (!result.Succeeded)
            {
                TempData[ErrorMessage] =
                    "There was an error while logging! Please try again later.";

                return View(loginModel);
            }

            return Redirect(loginModel.ReturnUrl ?? "/Home/Index");
        }
    }
}
