using System;
using System.Collections.Generic;
using BakeryStore.Models;

namespace BakeryStore.Repositories
{
    public interface IShopCart
    {
        string ShopCartId { get; set; }
        List<ShopCartItem> ShopItems { get; set; }

        void AddToCart(Product product, int quantity);
        List<ShopCartItem> GetShopItems();
        int[] GetShopItemsIds();
        bool Contains(Product product);
        void DeleteFromCart(int id);
        ShopCartItem GetItem(int id);
        void Clear();
    }
}
