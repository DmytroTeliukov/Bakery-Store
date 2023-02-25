using BakeryStore.Models;

namespace BakeryStore.Interfaces
{
    public interface IProducts
    {
        IEnumerable<Product> GetProducts();
        Product GetProductById(int id);
    }
}
