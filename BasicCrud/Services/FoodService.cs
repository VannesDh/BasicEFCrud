using BasicCrud.Data;
using BasicCrud.Models;
using Microsoft.EntityFrameworkCore;

namespace BasicCrud.Services;
public class FoodService
{
    private readonly AppDbContext _appDbContext;

    public FoodService(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<List<Food>> GetAllFood()
    {
        return await _appDbContext.Foods
                    .ToListAsync();
    }

    public async Task<List<Food>> GetAllFoodBelowThisPrice(int price)
    {
        return await _appDbContext.Foods
                    .Where(f => f.Price <= price)
                    .ToListAsync();
    }

    public async Task<Food> CreateFood(Food food)
    {
        _appDbContext.Foods.Add(food);
        await _appDbContext.SaveChangesAsync();
        return food;
    }

    public async Task<Food?> DeleteFoodById(int id)
    {
        Food? food = await _appDbContext.Foods
                            .FirstOrDefaultAsync(f => f.Id == id);

        if(food == null)
            return null;

        _appDbContext.Foods.Remove(food);
        await _appDbContext.SaveChangesAsync();

        return food;
    }

    public async Task<Food?> UpdateFoodById(int id, FoodDto updatedFood)
    {
        Food? food = await _appDbContext.Foods
                            .FirstOrDefaultAsync(f => f.Id == id);

        if(food == null)
            return null;

        food.Name = updatedFood.Name;
        food.Price = updatedFood.Price;
        food.RestaurantId = updatedFood.RestaurantId;

        await _appDbContext.SaveChangesAsync();

        return food;
    }


}