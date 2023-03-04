using BakeryStore.Database;
using BakeryStore.Interfaces;
using BakeryStore.Models;
using Microsoft.EntityFrameworkCore;

namespace BakeryStore.Repositories
{
    public class ProductRepository : IProducts
    {
        private readonly AppDBContent appDBContent;
        public ProductRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public Product GetProductById(int id) => appDBContent.Product.Include(c => c.Category).Where(p => p.Id == id).First();

        public IEnumerable<Product> GetProducts() => appDBContent.Product.Include(c =>c.Category);


        public IEnumerable<Product> GetProductsByCategory(string categoryName) => appDBContent.Product.Include(c => c.Category).Where(p => p.Category.Name == categoryName);

        public IEnumerable<Product> SearchProductsByName(string productName) => appDBContent.Product.Include(c => c.Category).Where(p => p.Title.Contains(productName));
    }
}
