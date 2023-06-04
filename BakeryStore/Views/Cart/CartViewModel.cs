using System.Collections.Generic;
using BakeryStore.Models;

namespace BakeryStore.Views.Cart
{
    public class CartViewModel
    {
        public List<ShopCartItem> ShopItems { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
