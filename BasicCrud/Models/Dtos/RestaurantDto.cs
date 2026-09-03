using BasicCrud.Models.Enums;

public class RestaurantDTO
{
    public required string Name {get; set;}
    public int Star{get; set;}
    public required string Location {get; set;}
    public RestaurantType RestaurantType{get; set;} = default;
}