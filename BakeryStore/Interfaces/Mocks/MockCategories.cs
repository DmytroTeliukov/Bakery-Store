using BakeryStore.Models;

namespace BakeryStore.Interfaces.Mocks
{
    public class MockCategories : ICategories
    {
        private List<Category> _categories;

        public MockCategories() { 
            _categories = new List<Category>();
            GenerateData();
        }

        public IEnumerable<Category> GetCategories()
        {
            return _categories;
        }

        public Category GetCategory(int id)
        {
            return _categories.Where(category => category.Id == id).First();
        }

        private void GenerateData() 
        { 
            Category cookie = new Category {Id = 1, Name = "Печиво", Description = "It is cookies!"};
            Category cake = new Category { Id = 2, Name = "Торти", Description = "It is cakes!" };
            Category candy = new Category { Id = 3, Name = "Цукерки", Description = "It is candies!" };

            _categories.Add(cookie);
            _categories.Add(cake);
            _categories.Add(candy);
        }
    }
}
