using CookBookApp.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace CookBookApp.DataAccess
{
    public class CookBookAppContext : DbContext
    {
        public CookBookAppContext(DbContextOptions<CookBookAppContext> opt) : base(opt)
        {

        }
        
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredient { get; set; }
        public DbSet<Unit> Unit { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> Roles { get; set; }
        public DbSet<FoodType> FoodTypes { get; set; }
        public DbSet<RecipeFoodType> RecipeFoodTypes { get; set; }
    }
}
