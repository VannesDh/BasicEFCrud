using BasicCrud.Models;
using BasicCrud.Models.Enums;

namespace BasicCrud.Repositories;

public interface IRestaurantRepository
{
    Task<List<Restaurant>> GetAll();
    Task<Restaurant?> GetById(int id);
    Task<List<Restaurant>> GetByType(RestaurantType type);
    Task<Restaurant> Create(Restaurant restaurant);
    Task<Restaurant?> Delete(int id);
    Task<Restaurant?> Update(int id, RestaurantDTO updatedRestaurant);
}