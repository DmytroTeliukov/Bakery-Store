using BakeryStore.Repositories;
using BakeryStore.Views.Cart;
using Microsoft.AspNetCore.Mvc;

namespace BakeryStore.Controllers
{
    public class ShopCartController : Controller
    {
        private readonly ProductRepository _productRepository;
        private readonly ShopCart _shopCart;
        public ShopCartController(ProductRepository productRepository, ShopCart shopCart)
        {
            _productRepository = productRepository;
            _shopCart = shopCart;
        }
        public ViewResult Cart()
        {
            return View(_shopCart.GetShopItems());
        }
        public RedirectToActionResult AddToCart(int id, int quantity)
        {
            var item = _productRepository.GetProductById(id);
            if (item != null)
            {
                _shopCart.AddToCart(item, quantity);
            }
            return RedirectToAction("Cart");
        }

        [HttpDelete]
        public IActionResult DeleteFromCart(int id)
        {
            _shopCart.DeleteFromCart(id);
            return Redirect("/Cart");
        }
    }

}
