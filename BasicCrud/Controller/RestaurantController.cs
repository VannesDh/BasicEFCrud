using Microsoft.AspNetCore.Mvc;
using BasicCrud.Models;
using BasicCrud.Services;
using BasicCrud.Models.Enums;

namespace BasicCrud.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RestaurantController : ControllerBase
{
    private readonly RestaurantService _restaurantService;

    public RestaurantController(RestaurantService restaurantService)
    {
        _restaurantService = restaurantService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Restaurant>>> GetRestaurants()
    {
        return Ok(await _restaurantService.GetAllRestaurant());
    }

    [HttpGet("id/{id}")]
    public async Task<ActionResult<Restaurant>> GetRestaurantById(int id)
    {
        var restaurant = await _restaurantService.GetRestaurantById(id);

        if (restaurant == null)
            return NotFound();

        return Ok(restaurant);
    }

    [HttpGet("type/{type}")]
    public async Task<ActionResult<List<Restaurant>>> GetRestaurantByType(RestaurantType type)
    {
        return Ok(await _restaurantService.GetRestaurantByType(type));
    }

    [HttpPost("create/")]
    public async Task<ActionResult<Restaurant>> CreateRestaurant(RestaurantDTO restaurantDTO)
    {

        var restaurant = new Restaurant
        {
            Name = restaurantDTO.Name,
            Star = restaurantDTO.Star,
            Location = restaurantDTO.Location,
            RestaurantType = restaurantDTO.RestaurantType
        };

        var created = await _restaurantService.CreateRestaurant(restaurant);

        return created;
    }

    [HttpDelete("delete/{id}")]
    public async Task<ActionResult<Restaurant>> DeleteRestaurant(int id)
    {
        var restaurant = await _restaurantService.DeleteRestaurantById(id);

        if (restaurant == null)
            return NotFound();

        return restaurant;
    }

    [HttpPut("update/{id}")]
    public async Task<ActionResult<Restaurant>> UpdateRestaurant(int id, RestaurantDTO restaurantDTO)
    {
        var restaurant = await _restaurantService.UpdateRestaurantById(id, restaurantDTO);

        if (restaurant == null)
            return NotFound();

        return restaurant;
    }
}