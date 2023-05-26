using BakeryStore.Interfaces;
using BakeryStore.Models;
using BakeryStore.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BakeryStore.Controllers
{
    public class OrderController : Controller
    {
        private readonly OrderRepository _orderRepository;
        private readonly ShopCart _shopCart;
        private readonly UserManager<User> _userManager;
        public OrderController(OrderRepository orderRepository, ShopCart shopCart)
        {
            this._orderRepository = orderRepository;
            this._shopCart = shopCart;
        }

        [HttpGet]
        public IActionResult CreateOrderForm()
        {
            return View(new Order());
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            _shopCart.ShopItems = _shopCart.GetShopItems();
            
            if (_shopCart.ShopItems.Count == 0)
            {
                ModelState.AddModelError("", "Ви повинні додати товар!");
            }
            if (ModelState.IsValid)
            {
                
                order.UserId = GetCurrentUserId();
                _orderRepository.CreateOrder(order);
                return RedirectToAction("Index");
            }
            return View(order);
        }

        private string GetCurrentUserId() 
        {
            return _userManager.GetUserId(HttpContext.User);
        }

        public IActionResult Complete()
        {
            ViewBag.Message = "Ваше замовлення відправлено!";
            return View();
        }
    }

    
}
