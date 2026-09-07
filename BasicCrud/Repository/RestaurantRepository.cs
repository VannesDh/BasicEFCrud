using AutoMapper;
using BasicCrud.Data;
using BasicCrud.Models;
using BasicCrud.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace BasicCrud.Repositories;

public class RestaurantRepository : IRestaurantRepository
{
    private readonly AppDbContext _appDbContext;
    private readonly IMapper _mapper;

    public RestaurantRepository(AppDbContext appDbContext, IMapper mapper)
    {
        _appDbContext = appDbContext;
        _mapper = mapper;
    }

    public async Task<List<Restaurant>> GetAll()
    {
        return await _appDbContext.Restaurants
            .Include(r => r.Foods)
            .ToListAsync();
    }

    public async Task<Restaurant?> GetById(int id)
    {
        return await _appDbContext.Restaurants
            .Include(r => r.Foods)
            .FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task<List<Restaurant>> GetByType(RestaurantType type)
    {
        return await _appDbContext.Restaurants
            .Include(r => r.Foods)
            .Where(r => r.RestaurantType == type)
            .ToListAsync();
    }

    public async Task<Restaurant> Create(Restaurant restaurant)
    {
        _appDbContext.Restaurants.Add(restaurant);
        await _appDbContext.SaveChangesAsync();

        return restaurant;
    }

    public async Task<Restaurant?> Delete(int id)
    {
        var restaurant = await _appDbContext.Restaurants
            .FirstOrDefaultAsync(r => r.Id == id);

        if (restaurant == null)
            return null;

        _appDbContext.Restaurants.Remove(restaurant);
        await _appDbContext.SaveChangesAsync();

        return restaurant;
    }

    public async Task<Restaurant?> Update(
        int id,
        RestaurantDTO updatedRestaurant)
    {
        var restaurant = await _appDbContext.Restaurants
            .FirstOrDefaultAsync(r => r.Id == id);

        if (restaurant == null)
            return null;

        _mapper.Map(updatedRestaurant, restaurant);

        await _appDbContext.SaveChangesAsync();

        return restaurant;
    }
}