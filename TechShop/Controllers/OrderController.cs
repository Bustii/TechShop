﻿namespace TechShop.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using TechShop.Services.Data.Interfaces;
    using TechShop.Web.Infrastructure.Extensions;
    using TechShop.Web.ViewModels.Order;

    using static Common.NotificationMessagesConstants;
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderService orderService;
        private readonly ICartService cartService;


        public OrderController(IOrderService orderService, ICartService cartService)
        {
            this.orderService = orderService;
            this.cartService = cartService;
        }

        [HttpGet]
        public async Task<IActionResult> Checkout()
        {
            try
            {
                var userId = User.GetId();

                var currCart = await cartService.GetCurrentCartByUserIdAsync(userId!);

                var order = new OrderFormViewModel()
                {
                    TotalPrice = currCart!.TotalPrice
                };

                return View(order);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Checkout(OrderFormViewModel order)
        {
            var userId = User.GetId()!;

            var model = await cartService.GetCurrentCartByUserIdAsync(userId);

            order.UserId = userId;
            order.CartId = model!.Id;
            order.TotalPrice = model!.TotalPrice;

            if (!ModelState.IsValid)
            {
                order.TotalPrice = model!.TotalPrice;

                TempData[ErrorMessage] = "An unexpected error occurred! Please fill all fields and try again.";

                return View(order);
            }

            try
            {
                await orderService.CreateOrderAsync(order);
                await cartService.CreateCartAsync(userId);
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = "An unexpected error occurred! Please, try again.";

                return View(order);
            }

            return RedirectToAction("Confirmed", "Order");
        }

        [HttpGet]
        public IActionResult Confirmed()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> OrderHistory()
        {
            string userId = User.GetId()!;

            try
            {
                var userOrders = await orderService.GetAllOrdersByUserIdAsync(userId);

                return View(userOrders);
            }
            catch
            {
                TempData[ErrorMessage] = "Something get wrong! Please try again later!";
                return RedirectToAction("All", "Products");
            }
        }

        [HttpGet]
        public async Task<IActionResult> OrderDetails(string id)
        {
            try
            {
                var cart = await cartService.GetCartByOrderIdAsync(id);

                return View(cart);
            }
            catch
            {
                TempData[ErrorMessage] = "Something get wrong! Please try again later!";
                return RedirectToAction("OrderHistory", "Order");
            }
        }
    }
}
