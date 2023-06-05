using BakeryStore.Interfaces;
using BakeryStore.Repositories;
using Microsoft.AspNetCore.Mvc;
using BakeryStore.Models;
using BakeryStore.ViewModels;
using Mysqlx.Crud;
using Microsoft.AspNetCore.Identity;

namespace BakeryStore.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrder _order;
        private readonly ShopCart _shopCart;
        private readonly IUsers _user;
        private readonly UserManager<IdentityUser> _userManager;

        public OrderController(IOrder order, ShopCart shopCart, IUsers user, UserManager<IdentityUser> userManager)
        {
            _order = order;
            _shopCart = shopCart;
            _user = user;
            _userManager = userManager;
        }

        [HttpGet("order/create")]
        public IActionResult CreateOrderForm()
        {
            var order = new OrderViewModel();
            return View(order);
        }

        [HttpPost("order/create/checkout")]
        public async Task<IActionResult> Checkout()
        {
            var shopItems = _shopCart.GetShopItems();
            if (shopItems.Count == 0)
            {
                ModelState.AddModelError("", "Ви повинні додати товар!");
            }
            var user = await _userManager.GetUserAsync(User);
            var order = new BakeryStore.Models.Order
            {
                Status = "new",
                UserId = user.Id,
                OrderDetails = new List<OrderDetail>()
            };
            int totalPrice = 0; // Initialize total price
            foreach (var item in shopItems)
            {
                if (order.OrderDetails == null)
                {
                    order.OrderDetails = new List<OrderDetail>();
                }
                var detail = new OrderDetail
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    Price = item.Price
                };
                order.OrderDetails.Add(detail);
                totalPrice += (int)(detail.Price * detail.Quantity);
            }
            order.TotalPrice = totalPrice;

            _order.Create(order);
            _shopCart.Clear();
            return RedirectToAction("Complete");
        }

        public IActionResult Complete()
        {
            ViewBag.Message = "Замовлення відправлено на обробку!";
            return View();
        }


    }
}
