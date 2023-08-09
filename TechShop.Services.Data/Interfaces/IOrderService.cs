﻿namespace TechShop.Services.Data.Interfaces
{
    using TechShop.Web.ViewModels.Order;

    public interface IOrderService
    {
        Task<OrderFormViewModel?> GetOrderDetailsAsync(string cartId);

        Task<IEnumerable<OrderHistoryViewModel>> GetAllOrdersByUserIdAsync(string userId);

        Task CreateOrderAsync(OrderFormViewModel orderModel);

        Task<OrderFormViewModel?> GetLastOrderListByUserIdAsync(string userId);
    }
}
