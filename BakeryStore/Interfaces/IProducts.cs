using BakeryStore.Models;

namespace BakeryStore.Interfaces
{
    public interface IProducts
    {
        IEnumerable<Product> GetProducts();
        IEnumerable<Product> GetProductsByCategory(String categoryName);
        IEnumerable<Product> SearchProductsByName(String productName);
        Product GetProductById(int id);
    }
}
