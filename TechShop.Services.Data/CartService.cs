namespace TechShop.Services.Data
{
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;
    using TechShop.Data;
    using TechShop.Data.Models;
    using TechShop.Services.Data.Interfaces;
    using TechShop.Web.ViewModels.Cart;

    public class CartService : ICartService
    {
        private readonly TechShopDbContext dbContext;

        public CartService(TechShopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddProductToCartAsync(int productId, string cartId, string userId)
        {
            bool isProductExistInCart = await dbContext
                .CartProducts
                .AnyAsync(c => c.ProductId == productId
                             && c.CartId.ToString() == cartId);

            Product currentProduct = await dbContext
                .Products
                .Where(i => i.Id == productId)
                .FirstAsync();

            Cart cart = await dbContext
                .Carts
                .Where(c => c.Id.ToString() == cartId)
                .FirstAsync();

            CartItem? currentCartProduct;

            if (!isProductExistInCart)
            {
                currentCartProduct = await dbContext
                 .CartProducts
                 .Where(c => c.ProductId == productId && c.CartId.ToString() == cartId)
                 .FirstOrDefaultAsync();

                if (currentCartProduct == null)
                {
                    currentCartProduct = new CartItem()
                    {
                        ProductId = currentProduct.Id,
                        CartId = cart.Id
                    };
                }

                dbContext.CartProducts.Add(currentCartProduct);

            }
            else
            {
                currentCartProduct = await dbContext
                    .CartProducts
                    .Where(ci => ci.ProductId == productId && ci.CartId.ToString() == cartId)
                    .FirstAsync();

                currentCartProduct.Quantity++;
            }

            await dbContext.SaveChangesAsync();
        }

        public async Task CreateCartAsync(string userId)
        {
            Guid guidId;

            bool isValidId = Guid.TryParse(userId, out guidId);

            if (isValidId)
            {
                Cart cart = new Cart()
                {
                    UserId = guidId
                };

                dbContext.Carts.Add(cart);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task DecreaseItemCountAsync(int productId, string cartId)
        {
            var cartProduct = await dbContext
                .CartProducts
                .Where(c => c.ProductId == productId && c.CartId.ToString() == cartId)
                .FirstAsync();

            cartProduct.Quantity--;

            await dbContext.SaveChangesAsync();
        }

        public async Task<CartFormViewModel> GetCartByOrderIdAsync(string orderId)
        {
            var currentCart = await dbContext
                .Orders
                .Where(c => c.Id.ToString() == orderId)
                .Select(c => new CartFormViewModel()
                {
                    Id = c.CartId.ToString(),
                    Products = c.Cart.CartProducts
                    .Select(cp => new CartProductViewModel()
                    {
                        ProductId = cp.ProductId,
                        Name = cp.Product.Name,
                        Model = cp.Product.Model,
                        Image = cp.Product.ImageUrl,
                        Price = cp.Product.Price,
                        Quantity = cp.Quantity,
                        TotalPrice = cp.Quantity * cp.Product.Price
                    })
                    .ToArray()
                })
                .FirstAsync();

            return currentCart;
        }

        public async Task<CartFormViewModel?> GetCurrentCartByUserIdAsync(string userId)
        {
            var cart = await dbContext
                .Carts
                .OrderByDescending(c => c.CreatedOn)
                .Where(c => c.UserId.ToString() == userId)
                .Select(c => new CartFormViewModel()
                {
                    Id = c.Id.ToString(),
                    Products = c.CartProducts
                    .Select(cp => new CartProductViewModel()
                    {
                        ProductId = cp.ProductId,
                        Name = cp.Product.Name,
                        Model = cp.Product.Model,
                        Image = cp.Product.ImageUrl,
                        Price = cp.Product.Price,
                        Quantity = cp.Quantity,
                        TotalPrice = cp.Quantity * cp.Product.Price
                    })
                    .ToArray()

                })
                .FirstOrDefaultAsync();

            if (cart != null)
            {
                cart!.TotalPrice += cart.Products.Select(i => i.TotalPrice).Sum();

            }

            return cart;
        }

        public async Task IncreaseItemCountAsync(int productId, string cartId)
        {
            var cartItem = await dbContext
                .CartProducts
                .Where(c => c.ProductId == productId && c.CartId.ToString() == cartId)
                .FirstAsync();

            cartItem.Quantity++;

            await dbContext.SaveChangesAsync();
        }

        public async Task RemoveItemFromCartAsync(int cartProductId, string cartId)
        {
            var cartItem = await dbContext
                .CartProducts
                .Where(c => c.ProductId == cartProductId && c.CartId.ToString() == cartId)
                .FirstAsync();

            if (cartItem != null)
            {
                dbContext.CartProducts.Remove(cartItem);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
