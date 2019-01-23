using BethanysPieShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShop.ViewModels
{
    public class ShopingCartViewModel
    {
        public ShopingCart ShopingCart { get; set; }
        public decimal ShopingCartTotal { get; set; }
    }
}
