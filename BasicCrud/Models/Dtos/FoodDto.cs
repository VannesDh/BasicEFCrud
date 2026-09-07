namespace BasicCrud.Models;

public class FoodDTO
{
    public required string Name { get; set; }
    public int Price { get; set; }
    public int RestaurantId{get; set;}
    
}