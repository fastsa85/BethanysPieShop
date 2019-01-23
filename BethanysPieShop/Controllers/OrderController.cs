using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BethanysPieShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BethanysPieShop.Controllers
{   
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ShopingCart _shopingCart;

        public OrderController(IOrderRepository orderRepository, ShopingCart shopingCart)
        {
            _orderRepository = orderRepository;
            _shopingCart = shopingCart;
        }

        [Authorize]
        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Checkout(Order order)
        {
            var items = _shopingCart.GetShopingCartItems();
            _shopingCart.ShopingCartItems = items;

            if (_shopingCart.ShopingCartItems.Count == 0)
            {
                ModelState.AddModelError("", "Your cart is empty, add some pies first");
            }

            if (ModelState.IsValid)
            {
                _orderRepository.CreateOrder(order);
                _shopingCart.ClearCart();
                return RedirectToAction("CheckoutComplete");
            }
            return View(order);
        }
       
        public IActionResult CheckoutComplete()
        {
            ViewBag.CheckoutCompleteMessage ="Thanks for your order. You'll soon enjoy our delicious pies!";
            return View();
        }
    }
}
