using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BethanysPieShop.Models;
using BethanysPieShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BethanysPieShop.Controllers
{
    public class ShopingCartController : Controller
    {
        private readonly IPieRepository _pieRepository;
        private readonly ShopingCart _shopingCart;

        public ShopingCartController(IPieRepository pieRepository, ShopingCart shopingCart)
        {
            _pieRepository = pieRepository;
            _shopingCart = shopingCart;
        }

        public ViewResult Index()
        {
            var items = _shopingCart.GetShopingCartItems();
            _shopingCart.ShopingCartItems = items;

            var shopingCartViewModel = new ShopingCartViewModel()
            {
                ShopingCart = _shopingCart,
                ShopingCartTotal = _shopingCart.GetShopingCartTotal()
            };

            return View(shopingCartViewModel);
        }

        public RedirectToActionResult AddToShopingCart(int pieId)
        {
            var selctedPie = _pieRepository.Pies.FirstOrDefault(p => p.PieId == pieId);
            if(selctedPie != null)
            {
                _shopingCart.AddToCart(selctedPie, 1);
            }
            return RedirectToAction("Index");
        }
    }
}
