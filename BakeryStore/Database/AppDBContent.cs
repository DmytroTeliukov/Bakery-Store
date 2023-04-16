using BakeryStore.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BakeryStore.Database
{
    public class AppDBContent : IdentityDbContext
    {
        public AppDBContent(DbContextOptions<AppDBContent> options) : base(options) { }
   
        public DbSet<Product> Product{ get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<User> User { get; set; }  
    }
}
