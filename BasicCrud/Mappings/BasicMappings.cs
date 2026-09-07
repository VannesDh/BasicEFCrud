using AutoMapper;
using BasicCrud.Models;

namespace BasicCrud.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<RestaurantDTO, Restaurant>();
        CreateMap<Restaurant, RestaurantDTO>();
        CreateMap<FoodDTO, Food>();
        CreateMap<Food,FoodDTO>();
    }
}