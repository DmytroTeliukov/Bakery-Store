using BakeryStore.Database;
using BakeryStore.Interfaces;
using BakeryStore.Models;

namespace BakeryStore.Repositories
{
    public class CategoryRepository : ICategories
    {
        private readonly AppDBContent appDBContent;
        public CategoryRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public IEnumerable<Category> GetCategories() => appDBContent.Category;
        
        public Category GetCategory(int id) => appDBContent.Category.First(с => с.Id == id);
    }
}
