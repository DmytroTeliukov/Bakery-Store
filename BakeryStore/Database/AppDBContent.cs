using BakeryStore.Models;
using Microsoft.EntityFrameworkCore;

namespace BakeryStore.Database
{
    public class AppDBContent : DbContext
    {
        public AppDBContent(DbContextOptions<AppDBContent> options) : base(options) { }
        public DbSet<Product> Product{ get; set; }
        public DbSet<Category> Category { get; set; }
    }
}
