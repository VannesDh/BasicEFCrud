using BasicCrud.Models;

public interface IFoodRepository
{
    Task<List<Food>> GetAll();
    Task<List<Food>> GetAllBelowPrice(int price);
    Task<Food> Create(Food food);
    Task<Food?> GetById(int id);
    Task<Food?> Delete(int id);
    Task<Food?> Update(int id, FoodDTO updatedFood);
}