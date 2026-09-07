using Microsoft.AspNetCore.Mvc;
using BasicCrud.Models;
using BasicCrud.Services;
using BasicCrud.Models.Enums;
using Microsoft.AspNetCore.Authorization;

namespace BasicCrud.Controllers;

[Authorize]
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
    public async Task<ActionResult> GetRestaurants()
    {
        var result = await _restaurantService.GetAllRestaurant();

        if (!result.Success)
            return StatusCode(result.StatusCode, result.Message);

        return StatusCode(result.StatusCode, result.Data);
    }

    [HttpGet("id/{id}")]
    public async Task<ActionResult> GetRestaurantById(int id)
    {
        var result = await _restaurantService.GetRestaurantById(id);

        if (!result.Success)
            return StatusCode(result.StatusCode, result.Message);

        return StatusCode(result.StatusCode, result.Data);
    }

    [HttpGet("type/{type}")]
    public async Task<ActionResult> GetRestaurantByType(RestaurantType type)
    {
        var result = await _restaurantService.GetRestaurantByType(type);

        if (!result.Success)
            return StatusCode(result.StatusCode, result.Message);

        return StatusCode(result.StatusCode, result.Data);
    }

    [HttpPost("create")]
    public async Task<ActionResult> CreateRestaurant(
        RestaurantDTO restaurantDTO)
    {
        var restaurant = new Restaurant
        {
            Name = restaurantDTO.Name,
            Star = restaurantDTO.Star,
            Location = restaurantDTO.Location,
            RestaurantType = restaurantDTO.RestaurantType
        };

        var result = await _restaurantService.CreateRestaurant(restaurant);

        if (!result.Success)
            return StatusCode(result.StatusCode, result.Message);

        return StatusCode(result.StatusCode, result.Data);
    }

    [HttpDelete("delete/{id}")]
    public async Task<ActionResult> DeleteRestaurant(int id)
    {
        var result = await _restaurantService.DeleteRestaurantById(id);

        if (!result.Success)
            return StatusCode(result.StatusCode, result.Message);

        return StatusCode(result.StatusCode, result.Data);
    }

    [HttpPut("update/{id}")]
    public async Task<ActionResult> UpdateRestaurant(
        int id,
        RestaurantDTO restaurantDTO)
    {
        var result = await _restaurantService.UpdateRestaurantById(
            id,
            restaurantDTO
        );

        if (!result.Success)
            return StatusCode(result.StatusCode, result.Message);

        return StatusCode(result.StatusCode, result.Data);
    }
}