using System.ComponentModel.DataAnnotations;

namespace BakeryStore.Models
{
    public class OrderDetail
    {
        [Key]
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }
}
