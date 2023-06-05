using BakeryStore.Database;
using BakeryStore.Interfaces;
using BakeryStore.Models;
using Microsoft.EntityFrameworkCore;

namespace BakeryStore.Repositories
{
    public class OrderRepository : IOrder
    {
        private readonly AppDBContent _context;
        private readonly ShopCart _shopCart;

        public OrderRepository(AppDBContent context, ShopCart shopCart)
        {
            _context = context;
            _shopCart = shopCart;
        }

        public void Create(Order order)
        {
            _context.Order.Add(order);
            _context.SaveChanges();
        }
    }
}
