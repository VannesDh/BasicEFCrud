using BasicCrud.Models;
using Microsoft.EntityFrameworkCore;
namespace BasicCrud.Data;

public class AppDbContext : DbContext
{
     public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Restaurant> Restaurants {get; set;}
    public DbSet<Food> Foods {get; set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Restaurant>()
            .Property(r => r.RestaurantType)
            .HasConversion<string>();
    }
}