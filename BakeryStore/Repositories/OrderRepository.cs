using BakeryStore.Database;
using BakeryStore.Interfaces;
using BakeryStore.Models;

namespace BakeryStore.Repositories
{
    public class OrderRepository : IOrders
    {
        private readonly AppDBContent appDBContent;
        private readonly ShopCart _shopCart;
        public OrderRepository(AppDBContent appDBContent, ShopCart
       shopCart)
        {
            this.appDBContent = appDBContent;
            this._shopCart = shopCart;
        }

        public void CreateOrder(Models.Order order)
        {
            order.Ordered = DateTime.Now;
            order.Status = "ORDERED";
            
            
            appDBContent.Order.Add(order);
            appDBContent.SaveChanges();
            var cart = _shopCart.ShopItems;
            order.TotalPrice = cart.Select(x => x.Price).Sum();


            AddProductsToOrder(cart, order);
            
            appDBContent.SaveChanges();
        }

        private void AddProductsToOrder(List<ShopCartItem> cart, Models.Order order)
        {
            foreach (var el in cart)
            {
                var orderDetail = new OrderDetail()
                {
                    ProductId = el.ProductId,
                    OrderId = order.Id,
                    Price = el.Price,
                    Quantity = el.Quantity
                };
                appDBContent.OrderDetails.Add(orderDetail);
            }
        }
    }

}
