using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BakeryStore.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }  
        public string Photo { get; set; }

        [ForeignKey("Category")]
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; } = decimal.Zero;
        public string Stuff { get; set; }
        public string Calories { get; set; }
        public double Weight { get; set;}
        public int ShelfLife { get; set; }
        public string StorageConditions { get; set; }
        public bool isFavourite { get; set; }
        public bool Available { get; set; }
    }
}
