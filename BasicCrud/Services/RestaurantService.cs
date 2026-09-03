using BasicCrud.Data;
using BasicCrud.Models;
using BasicCrud.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace BasicCrud.Services;
public class RestaurantService
{
    private readonly AppDbContext _appDbContext;

    public RestaurantService(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<List<Restaurant>> GetAllRestaurant()
    {
        return await _appDbContext.Restaurants
                    .Include(r => r.Foods)
                    .ToListAsync();
    }

    public async Task<Restaurant?> GetRestaurantById(int id)
    {
        return await _appDbContext.Restaurants
                    .Include(r => r.Foods)
                    .FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task<List<Restaurant>> GetRestaurantByType(RestaurantType type)
    {
        return await _appDbContext.Restaurants
                .Include(r => r.Foods)
                .Where(r => r.RestaurantType == type)
                .ToListAsync();
    }

    public async Task<Restaurant> CreateRestaurant(Restaurant restaurant)
    {
        _appDbContext.Restaurants.Add(restaurant);
        await _appDbContext.SaveChangesAsync();
        return restaurant;
    }

    public async Task<Restaurant?> DeleteRestaurantById(int id)
    {
        Restaurant? restaurant = await _appDbContext.Restaurants
                                .FirstOrDefaultAsync(r => r.Id == id);

        if (restaurant == null)
            return null;

        _appDbContext.Restaurants.Remove(restaurant);
        await _appDbContext.SaveChangesAsync();
        return restaurant;
    }

    public async Task<Restaurant?> UpdateRestaurantById(int id, RestaurantDTO updatedRestaurant)
    {
        Restaurant? restaurant = await _appDbContext.Restaurants
                                .FirstOrDefaultAsync(r => r.Id == id);

        if (restaurant == null)
            return null;

        restaurant.Name = updatedRestaurant.Name;
        restaurant.RestaurantType = updatedRestaurant.RestaurantType;
        restaurant.Star = updatedRestaurant.Star;
        restaurant.Location = updatedRestaurant.Location;

        await _appDbContext.SaveChangesAsync();

        return restaurant;
    }
}