using BethanysPieShop.Models;
using BethanysPieShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShop.Components
{
    public class ShopingCartSummary : ViewComponent
    {
        private readonly ShopingCart _shopingCart;

        public ShopingCartSummary(ShopingCart shopingCart)
        {
            _shopingCart = shopingCart;
        }

        public IViewComponentResult Invoke()
        {
            var items = _shopingCart.GetShopingCartItems();            
            _shopingCart.ShopingCartItems = items;

            var shopingCartViewModel = new ShopingCartViewModel
            {
                ShopingCart = _shopingCart,
                ShopingCartTotal = _shopingCart.GetShopingCartTotal()
            };

            return View(shopingCartViewModel);
        }        
    }
}
