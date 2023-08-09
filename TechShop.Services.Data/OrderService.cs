namespace TechShop.Services.Data
{
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TechShop.Data;
    using TechShop.Data.Models;
    using TechShop.Services.Data.Interfaces;
    using TechShop.Web.ViewModels.Cart;
    using TechShop.Web.ViewModels.Order;

    public class OrderService : IOrderService
    {
        private readonly TechShopDbContext dbContext;

        public OrderService(TechShopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task CreateOrderAsync(OrderFormViewModel orderModel)
        {
            Guid validCartId;
            Guid validUserId;

            bool isValidCartId = Guid.TryParse(orderModel.CartId, out validCartId);
            bool isValidUserId = Guid.TryParse(orderModel.UserId, out validUserId);

            if (isValidCartId && isValidUserId)
            {
                Order order = new Order()
                {
                    FirstName = orderModel.FirstName,
                    LastName = orderModel.LastName,
                    Country = orderModel.Country,
                    City = orderModel.City,
                    Address = orderModel.Address,
                    PostCode = orderModel.PostCode,
                    CartId = validCartId,
                    UserId = validUserId,
                    TotalPrice = orderModel.TotalPrice
                };

                await dbContext.Orders.AddAsync(order);
                await dbContext.SaveChangesAsync();
            }

        }

        public async Task<IEnumerable<OrderHistoryViewModel>> GetAllOrdersByUserIdAsync(string userId)
        {
            var orders = await dbContext
                .Orders
                .Where(o => o.UserId.ToString() == userId)
                .OrderByDescending(o => o.CreatedOn)
                .Select(o => new OrderHistoryViewModel()
                {
                    Id = o.Id.ToString(),
                    CreatedOn = o.CreatedOn,
                    TotalPrice = o.TotalPrice,
                    CartProducts = o.Cart.CartProducts.Select(c => new CartProductViewModel()
                    {
                        ProductId = c.ProductId,
                        Name = c.Product.Name,
                        Image = c.Product.ImageUrl,
                        Price = c.Product.Price,
                        Quantity =  c.Quantity,
                        TotalPrice = c.Quantity * c.Product.Price
                    })
                    .ToArray()
                })
                .ToListAsync();

            return orders;
        }

        public async Task<OrderFormViewModel?> GetLastOrderListByUserIdAsync(string userId)
        {
            var orderList = await dbContext
                .Orders
                .Where(o => o.UserId.ToString() == userId)
                .Select(o => new OrderFormViewModel()
                {
                    Id = o.Id.ToString(),
                    FirstName = o.FirstName!,
                    LastName = o.LastName!,
                    Country = o.Country!,
                    City = o.City!,
                    Address = o.Address!,
                    PostCode = o.PostCode!,
                    CartId = o.CartId.ToString(),
                    UserId = o.UserId.ToString(),
                    TotalPrice = o.TotalPrice
                })
                .ToListAsync();

            var lastOrder = orderList.LastOrDefault();

            return (lastOrder);
        }

        public async Task<OrderFormViewModel?> GetOrderDetailsAsync(string cartId)
        {
            var order = await dbContext
                .Orders
                .Where(c => c.CartId.ToString() == cartId)
                .Select(c => new OrderFormViewModel()
                {
                    Id = c.Id.ToString(),
                    FirstName = c.FirstName!,
                    LastName = c.LastName!,
                    Country = c.Country!,
                    City = c.City!,
                    Address = c.Address!,
                    PostCode = c.PostCode!,
                    CartId = c.CartId.ToString(),
                    UserId = c.UserId.ToString(),
                    TotalPrice = c.TotalPrice
                })
                .FirstOrDefaultAsync();

            return order;
        }
    }
}
