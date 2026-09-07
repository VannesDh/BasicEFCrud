using BasicCrud.Models;
using Microsoft.EntityFrameworkCore;
namespace BasicCrud.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
       : base(options)
    {
    }

    public DbSet<Restaurant> Restaurants { get; set; }
    public DbSet<Food> Foods { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Restaurant>(entity =>
        {
            entity.HasKey(r => r.Id);

            entity.Property(r => r.Name)
             .IsRequired()
             .HasMaxLength(100);

            entity.Property(r => r.RestaurantType)
                .HasConversion<string>();
        });

        modelBuilder.Entity<Food>(entity =>
        {
            entity.HasKey(f => f.Id);

            entity.Property(f => f.Name)
            .IsRequired()
            .HasMaxLength(100);
        });
    }

}