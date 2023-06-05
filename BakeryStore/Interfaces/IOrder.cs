using System;
using BakeryStore.Models;

namespace BakeryStore.Interfaces
{
    public interface IOrder
    {
        public void Create(Order order);
    }
}

