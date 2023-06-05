using System;
using BakeryStore.Models;

namespace BakeryStore.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public DateTime Ordered { get; set; }
        public string UserId { get; set; }
        public int TotalPrice { get; set; }
        public List<OrderDetailViewModel> OrderDetails { get; set; }
    }

    public class OrderDetailViewModel
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}