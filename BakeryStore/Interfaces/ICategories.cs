using BakeryStore.Models;

namespace BakeryStore.Interfaces
{
    public interface ICategories
    {
        IEnumerable<Category> GetCategories();
        Category GetCategory(int id);
    }
}
