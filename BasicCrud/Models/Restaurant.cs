using System.Runtime.InteropServices;
using BasicCrud.Models.Enums;

namespace BasicCrud.Models;

public class Restaurant
{
    public int Id { get; set; }
    public required string Name {get; set;}
    public int Star{get; set;}
    public required string Location {get; set;}
    public RestaurantType RestaurantType{get; set;}
    public List<Food> Foods { get; set; } = new();
}