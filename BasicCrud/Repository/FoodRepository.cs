using BasicCrud.Data;
using BasicCrud.Models;
using Microsoft.EntityFrameworkCore;

namespace BasicCrud.Repositories;

public class FoodRepository : IFoodRepository
{
    private readonly AppDbContext _appDbContext;

    public FoodRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<List<Food>> GetAll()
    {
        return await _appDbContext.Foods
            .ToListAsync();
    }

    public async Task<List<Food>> GetAllBelowPrice(int price)
    {
        return await _appDbContext.Foods
            .Where(f => f.Price <= price)
            .ToListAsync();
    }

    public async Task<Food> Create(Food food)
    {
        _appDbContext.Foods.Add(food);
        await _appDbContext.SaveChangesAsync();

        return food;
    }

    public async Task<Food?> GetById(int id)
    {
        return await _appDbContext.Foods
            .FirstOrDefaultAsync(f => f.Id == id);
    }

    public async Task<Food?> Delete(int id)
    {
        var food = await _appDbContext.Foods
            .FirstOrDefaultAsync(f => f.Id == id);

        if (food == null)
            return null;

        _appDbContext.Foods.Remove(food);
        await _appDbContext.SaveChangesAsync();

        return food;
    }

    public async Task<Food?> Update(int id, FoodDto updatedFood)
    {
        var food = await _appDbContext.Foods
            .FirstOrDefaultAsync(f => f.Id == id);

        if (food == null)
            return null;

        food.Name = updatedFood.Name;
        food.Price = updatedFood.Price;
        food.RestaurantId = updatedFood.RestaurantId;

        await _appDbContext.SaveChangesAsync();

        return food;
    }
}