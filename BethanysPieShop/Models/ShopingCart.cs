using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShop.Models
{
    public class ShopingCart
    {
        private readonly AppDbContext _appDbContext;

        private ShopingCart(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public string ShopingCartId { get; set; }

        public List<ShopingCartItem> ShopingCartItems { get; set; }

        public static ShopingCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;

            var context = services.GetService<AppDbContext>();
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", cartId);

            return new ShopingCart(context) { ShopingCartId = cartId };
        }

        public void AddToCart(Pie pie, int amount)
        {
            var shopingCartItem =
                    _appDbContext.ShopingCartItems.SingleOrDefault(
                        s => s.Pie.PieId == pie.PieId && s.ShopingCartId == ShopingCartId);

            if (shopingCartItem == null)
            {
                shopingCartItem = new ShopingCartItem
                {
                    ShopingCartId = ShopingCartId,
                    Pie = pie,
                    Amount = 1
                };

                _appDbContext.ShopingCartItems.Add(shopingCartItem);
            }
            else
            {
                shopingCartItem.Amount++;
            }
            _appDbContext.SaveChanges();
        }

        public int RemoveFromCart(Pie pie)
        {
            var shopingCartItem =
                    _appDbContext.ShopingCartItems.SingleOrDefault(
                        s => s.Pie.PieId == pie.PieId && s.ShopingCartId == ShopingCartId);

            var localAmount = 0;

            if (shopingCartItem != null)
            {
                if (shopingCartItem.Amount > 1)
                {
                    shopingCartItem.Amount--;
                    localAmount = shopingCartItem.Amount;
                }
                else
                {
                    _appDbContext.ShopingCartItems.Remove(shopingCartItem);
                }
            }

            _appDbContext.SaveChanges();

            return localAmount;
        }

        public List<ShopingCartItem> GetShopingCartItems()
        {
            return ShopingCartItems ??
                   (ShopingCartItems =
                       _appDbContext.ShopingCartItems.Where(c => c.ShopingCartId == ShopingCartId)
                           .Include(s => s.Pie)
                           .ToList());
        }

        public decimal GetShopingCartTotal()
        {
            var total = _appDbContext.ShopingCartItems.Where(c => c.ShopingCartId == ShopingCartId)
                .Select(c => c.Pie.Price * c.Amount).Sum();
            return total;
        }

        public void ClearCart()
        {
            var cartItems = _appDbContext
                .ShopingCartItems
                .Where(cart => cart.ShopingCartId == ShopingCartId);

            _appDbContext.ShopingCartItems.RemoveRange(cartItems);

            _appDbContext.SaveChanges();
        }
    }
}
