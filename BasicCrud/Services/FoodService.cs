using BasicCrud.Models;
using BasicCrud.Repositories;

namespace BasicCrud.Services;

public class FoodService
{
    private readonly IFoodRepository _foodRepository;

    public FoodService(IFoodRepository foodRepository)
    {
        _foodRepository = foodRepository;
    }

    public async Task<ServiceResult<List<Food>>> GetAllFood()
    {
        var foods = await _foodRepository.GetAll();

        return new ServiceResult<List<Food>>
        {
            Success = true,
            Message = "Foods retrieved successfully",
            Data = foods,
            StatusCode = 200
        };
    }

    public async Task<ServiceResult<List<Food>>> GetAllFoodBelowThisPrice(int price)
    {
        var foods = await _foodRepository.GetAllBelowPrice(price);

        return new ServiceResult<List<Food>>
        {
            Success = true,
            Message = "Foods retrieved successfully",
            Data = foods,
            StatusCode = 200
        };
    }

    public async Task<ServiceResult<Food>> CreateFood(Food food)
    {
        var createdFood = await _foodRepository.Create(food);

        return new ServiceResult<Food>
        {
            Success = true,
            Message = "Food created successfully",
            Data = createdFood,
            StatusCode = 201
        };
    }

    public async Task<ServiceResult<Food>> UpdateFoodById(int id, FoodDto food)
    {
        var updatedFood = await _foodRepository.Update(id, food);

        if (updatedFood == null)
        {
            return new ServiceResult<Food>
            {
                Success = false,
                Message = "Food not found",
                Data = null,
                StatusCode = 404
            };
        }

        return new ServiceResult<Food>
        {
            Success = true,
            Message = "Food updated successfully",
            Data = updatedFood,
            StatusCode = 200
        };
    }

    public async Task<ServiceResult<Food>> DeleteFoodById(int id)
    {
        var deletedFood = await _foodRepository.Delete(id);

        if (deletedFood == null)
        {
            return new ServiceResult<Food>
            {
                Success = false,
                Message = "Food not found",
                Data = null,
                StatusCode = 404
            };
        }

        return new ServiceResult<Food>
        {
            Success = true,
            Message = "Food deleted successfully",
            Data = deletedFood,
            StatusCode = 200
        };
    }
}