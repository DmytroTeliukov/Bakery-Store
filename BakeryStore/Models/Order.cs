using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BakeryStore.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public string Status { get; set; }
        public DateTime Ordered { get; set; } = DateTime.Now;
        [ValidateNever]
        public virtual List<OrderDetail> OrderDetails { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        [ValidateNever]
        public virtual User User { get; set; }
        public int TotalPrice { get; set; }

    }
}