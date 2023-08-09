namespace TechShop.Web.Controllers
{
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using TechShop.Data.Models;
    using TechShop.Services.Data.Interfaces;
    using TechShop.Web.Infrastructure.Extensions;
    using TechShop.Web.ViewModels.User;
    using static Common.NotificationMessagesConstants;
    public class UserController : Controller
    {
        private readonly IUserService userService;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;

        public UserController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, IUserService userService)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.userService = userService;
        }

        [AllowAnonymous]
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

            ApplicationUser user = new ApplicationUser()
            {
                FirstName = registerModel.FirstName,
                LastName = registerModel.LastName
            };

            var checkUser = await userManager.FindByEmailAsync(registerModel.Email);
            if (checkUser != null)
            {
                TempData[ErrorMessage] = "This email is already registered!";

                return View(registerModel);
            }

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


            //await userManager.AddToRoleAsync(user, "User");
            await signInManager.SignInAsync(user, false);

            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
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

            var user = await userManager.FindByEmailAsync(loginModel.Email);
            if (user != null)
            {
                if (user.IsDeleted)
                {
                    ModelState.AddModelError(string.Empty, "This account doesn't exist");
                    return View(loginModel);
                }

                var resultUser = await signInManager.PasswordSignInAsync(user, loginModel.Password, loginModel.RememberMe, lockoutOnFailure: true);
                if (resultUser.IsLockedOut)
                {
                    ModelState.AddModelError(string.Empty, "The account is locked. Too many attempts! Try again later");
                }

                if (resultUser.Succeeded)
                {
                    return RedirectToAction("All", "Product");
                }
            }

            TempData[ErrorMessage] = "Incorect Email or Password! Please  try again.";
            return View(loginModel);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Details()
        {
            var userId = User.GetId();
            try
            {
                var currentUser = await userService.GetUserByIdAsync(userId!);
                return View(currentUser);
            }
            catch (Exception)
            {
                return GeneralErrorMessage();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit()
        {
            var userId = User.GetId();

            try
            {
                var editUserModel = await userService.GetUserByIdAsync(userId!);
                return View(editUserModel);
            }
            catch (Exception)
            {
                return GeneralErrorMessage();
            }

        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditUserProfileViewModel userModel)
        {
            var users = await userService.GetAllUsersExceptCurrentOneAsync(userModel.Id);

            if (users.Any(u => u.Email == userModel.Email))
            {
                ModelState.AddModelError("Email", "This email address is already used");
            }

            var userId = User.GetId();
            var user = await userService.GetUserByIdAsync(userId!);

            if (!ModelState.IsValid)
            {
                userModel.Email = user.Email;

                return View(userModel);
            }

            try
            {

                await userService.EditProfileAsync(userId!, userModel);
            }
            catch (Exception)
            {
                return GeneralErrorMessage();
            }

            TempData[SuccessMessage] = "You edited your profile successfully.";
            return RedirectToAction("Details", "User");
        }

        [HttpPost]
        public async Task<IActionResult> Delete()
        {
            var userId = User.GetId();

            try
            {
                await userService.SoftDeleteUserAsync(userId!);

                await signInManager.SignOutAsync();
                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {
                return GeneralErrorMessage();
            }
        }

        private IActionResult GeneralErrorMessage()
        {
            TempData[ErrorMessage] = "An unexpected error occurred! Please, try again.";

            var previousUrl = Request.Headers["Referer"].ToString();

            return Redirect(previousUrl);
        }
    }
}
