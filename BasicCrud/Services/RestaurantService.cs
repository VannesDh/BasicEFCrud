using BasicCrud.Models;
using BasicCrud.Models.Enums;
using BasicCrud.Repositories;

namespace BasicCrud.Services;

public class RestaurantService
{
    private readonly IRestaurantRepository _restaurantRepository;

    public RestaurantService(IRestaurantRepository restaurantRepository)
    {
        _restaurantRepository = restaurantRepository;
    }

    public async Task<ServiceResult<List<Restaurant>>> GetAllRestaurant()
    {
        var restaurants = await _restaurantRepository.GetAll();

        return new ServiceResult<List<Restaurant>>
        {
            Success = true,
            Message = "Restaurants retrieved successfully",
            Data = restaurants,
            StatusCode = 200
        };
    }

    public async Task<ServiceResult<Restaurant>> GetRestaurantById(int id)
    {
        var restaurant = await _restaurantRepository.GetById(id);

        if (restaurant == null)
        {
            return new ServiceResult<Restaurant>
            {
                Success = false,
                Message = "Restaurant not found",
                StatusCode = 404
            };
        }

        return new ServiceResult<Restaurant>
        {
            Success = true,
            Message = "Restaurant retrieved successfully",
            Data = restaurant,
            StatusCode = 200
        };
    }

    public async Task<ServiceResult<List<Restaurant>>> GetRestaurantByType(
        RestaurantType type)
    {
        var restaurants = await _restaurantRepository.GetByType(type);

        return new ServiceResult<List<Restaurant>>
        {
            Success = true,
            Message = "Restaurants retrieved successfully",
            Data = restaurants,
            StatusCode = 200
        };
    }

    public async Task<ServiceResult<Restaurant>> CreateRestaurant(
        Restaurant restaurant)
    {
        var created = await _restaurantRepository.Create(restaurant);

        return new ServiceResult<Restaurant>
        {
            Success = true,
            Message = "Restaurant created successfully",
            Data = created,
            StatusCode = 201
        };
    }

    public async Task<ServiceResult<Restaurant>> DeleteRestaurantById(int id)
    {
        var restaurant = await _restaurantRepository.Delete(id);

        if (restaurant == null)
        {
            return new ServiceResult<Restaurant>
            {
                Success = false,
                Message = "Restaurant not found",
                StatusCode = 404
            };
        }

        return new ServiceResult<Restaurant>
        {
            Success = true,
            Message = "Restaurant deleted successfully",
            Data = restaurant,
            StatusCode = 200
        };
    }

    public async Task<ServiceResult<Restaurant>> UpdateRestaurantById(
        int id,
        RestaurantDTO updatedRestaurant)
    {
        var restaurant = await _restaurantRepository.Update(
            id,
            updatedRestaurant
        );

        if (restaurant == null)
        {
            return new ServiceResult<Restaurant>
            {
                Success = false,
                Message = "Restaurant not found",
                StatusCode = 404
            };
        }

        return new ServiceResult<Restaurant>
        {
            Success = true,
            Message = "Restaurant updated successfully",
            Data = restaurant,
            StatusCode = 200
        };
    }
}