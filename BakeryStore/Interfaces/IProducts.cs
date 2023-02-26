using BakeryStore.Models;

namespace BakeryStore.Interfaces
{
    public interface IProducts
    {
        IEnumerable<Product> GetProducts();
        IEnumerable<Product> GetProductsByCategory(String categoryName);
        Product GetProductById(int id);
    }
}
