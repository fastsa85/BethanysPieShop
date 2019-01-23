using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShop.Models
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _appDbcontext;
        private readonly ShopingCart _shopingCart;

        public OrderRepository(AppDbContext appDbContext, ShopingCart shopingCart)
        {
            _appDbcontext = appDbContext;
            _shopingCart = shopingCart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;

            _appDbcontext.Orders.Add(order);

            var shopingCartItems = _shopingCart.ShopingCartItems;

            foreach(ShopingCartItem shopingCartItem in shopingCartItems)
            {
                var orderDetail = new OrderDetail()
                {
                    Amount = shopingCartItem.Amount,
                    PieId = shopingCartItem.Pie.PieId,
                    OrderId = order.OrderId,
                    Price = shopingCartItem.Pie.Price
                };

                _appDbcontext.OrderDetails.Add(orderDetail);
            }

            _appDbcontext.SaveChanges();
        }
    }
}
