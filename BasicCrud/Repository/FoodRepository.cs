using AutoMapper;
using BasicCrud.Data;
using BasicCrud.Models;
using Microsoft.EntityFrameworkCore;

namespace BasicCrud.Repositories;

public class FoodRepository : IFoodRepository
{
    private readonly AppDbContext _appDbContext;
    private readonly IMapper _mapper;

    public FoodRepository(AppDbContext appDbContext, IMapper mapper)
    {
        _appDbContext = appDbContext;
        _mapper = mapper;
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

    public async Task<Food?> Update(int id, FoodDTO updatedFood)
    {
        var food = await _appDbContext.Foods
            .FirstOrDefaultAsync(f => f.Id == id);

        if (food == null)
            return null;


        _mapper.Map(updatedFood, food);
        await _appDbContext.SaveChangesAsync();

        return food;
    }
}   