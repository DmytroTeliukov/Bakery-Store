using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using Mysqlx.Crud;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BakeryStore.Models
{
    [PrimaryKey("ShopCartId, ProductId")]
    public class ShopCartItem
    {
        public string ShopCartId { get; set; }
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        [ValidateNever]
        public virtual Product Product { get; set; }

        public int Price { get; set; }
        public int Quantity { get; set; }

    }
}
