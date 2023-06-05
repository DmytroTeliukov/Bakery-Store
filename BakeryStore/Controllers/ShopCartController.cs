using BakeryStore.Interfaces;
using BakeryStore.Models;
using BakeryStore.Repositories;
using BakeryStore.Views.Cart;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BakeryStore.Controllers
{
    public class ShopCartController : Controller
    {
        private readonly IProducts _productRepository;
        private readonly IShopCart _shopCart;

        public ShopCartController(IProducts productRepository, IShopCart shopCart)
        {
            _productRepository = productRepository;
            _shopCart = shopCart;
        }

        public ViewResult Cart()
        {
            var shopItems = _shopCart.GetShopItems();
            var cartViewModel = new CartViewModel
            {
                ShopItems = shopItems,
                TotalPrice = CalculateTotalPrice(shopItems)
            };

            return View(cartViewModel);
        }

        public RedirectToActionResult AddToCart(int id, int quantity)
        {
            var product = _productRepository.GetProductById(id);
            if (product != null)
            {
                _shopCart.AddToCart(product, quantity);
            }

            return RedirectToAction("Cart");
        }

        public IActionResult DeleteFromCart(int id)
        {
            _shopCart.DeleteFromCart(id);
            return RedirectToAction("Cart");
        }

        private decimal CalculateTotalPrice(List<ShopCartItem> shopItems)
        {
            decimal totalPrice = 0;
            foreach (var item in shopItems)
            {
                totalPrice += item.Product.Price * item.Quantity;
            }

            return totalPrice;
        }
    }
}
