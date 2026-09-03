using System.Text.Json.Serialization;

namespace BasicCrud.Models;

public class Food
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public int Price { get; set; }
    public int RestaurantId{get; set;}    
}