﻿using System.ComponentModel.DataAnnotations;

namespace BakeryStore.Models
{
    public class OrderDetail
    {
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }

        public float Price { get; set; }
    }
}
