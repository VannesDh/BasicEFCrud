namespace BasicCrud.Models;

public class FoodDto
{
    public required string Name { get; set; }
    public int Price { get; set; }
    public int RestaurantId{get; set;}
    
}