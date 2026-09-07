using AutoMapper;
using BasicCrud.Models;
using BasicCrud.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BasicCrud.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class FoodController : ControllerBase
{
    private readonly FoodService _foodService;
    private readonly IMapper _mapper;


    public FoodController(FoodService foodService, IMapper mapper)
    {
        _foodService = foodService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<Food>>> GetAllFood()
    {
        return Ok(await _foodService.GetAllFood());
    }

    [HttpGet("below-price/{price}")]
    public async Task<ActionResult<List<Food>>> GetAllFoodBelowThisPrice(int price)
    {
        return Ok(await _foodService.GetAllFoodBelowThisPrice(price));
    }

    [HttpPost("create/")]
    public async Task<ActionResult<Food>> CreateFood(FoodDTO foodDTO)
    {

        var food = _mapper.Map<Food>(foodDTO);
    
        var createdFood = await _foodService.CreateFood(food);

        return Ok(createdFood);
    }
    
    [HttpPut("{id}")]
    public async Task<ActionResult<Food>> UpdateFood(int id, FoodDTO food)
    {
        var updatedFood = await _foodService.UpdateFoodById(id, food);

        if (updatedFood == null)
            return NotFound();

        return Ok(updatedFood);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Food>> DeleteFood(int id)
    {
        var deletedFood = await _foodService.DeleteFoodById(id);

        if (deletedFood == null)
            return NotFound();

        return Ok(deletedFood);
    }
}

