using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Restaurant.Data.Models;

namespace Restaurant.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<DishIngredient> DishIngredients { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<DishPortion> DishPortions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<DishIngredient>()
                .HasKey(di => new { di.DishId, di.IngredientId });
            builder.Entity<DishIngredient>()
                .HasOne(di => di.Dish)
                .WithMany(d => d.DishIngredients)
                .HasForeignKey(di => di.DishId);
            builder.Entity<DishIngredient>()
                .HasOne(di => di.Ingredient)
                .WithMany(s => s.DishIngredients)
                .HasForeignKey(di => di.IngredientId);
            builder.Entity<DishPortion>()
               .HasOne(di => di.Order)
               .WithMany(s => s.DishPortions)
               .HasForeignKey(di => di.OrderId);
        }
    }
}