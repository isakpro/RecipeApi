using Microsoft.AspNetCore.Mvc;
using RecipeApi.Models.DTOs;
using RecipeApi.Services;

namespace RecipeApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RecipesController : ControllerBase
{
    private readonly IRecipeService _recipeService;

    public RecipesController(IRecipeService recipeService)
    {
        _recipeService = recipeService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var recipes = _recipeService.GetAllRecipes();
        return Ok(recipes);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        var recipe = _recipeService.GetRecipeById(id);
        if (recipe is null)
            return NotFound();

        return Ok(recipe);
    }

    [HttpGet("search")]
    public IActionResult Search([FromQuery] string q)
    {
        if (string.IsNullOrWhiteSpace(q))
            return BadRequest("Search term cannot be empty.");

        var recipes = _recipeService.SearchRecipes(q);
        return Ok(recipes);
    }

    [HttpGet("difficulty/{level}")]
    public IActionResult GetByDifficulty(string level)
    {
        var recipes = _recipeService.GetRecipesByDifficulty(level);
        return Ok(recipes);
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreateRecipeDto dto)
    {
        var recipe = _recipeService.CreateRecipe(dto);
        return CreatedAtAction(nameof(GetById), new { id = recipe.Id }, recipe);
    }

    [HttpPut("{id:int}")]
    public IActionResult Update(int id, [FromBody] UpdateRecipeDto dto)
    {
        var recipe = _recipeService.UpdateRecipe(id, dto);
        if (recipe is null)
            return NotFound();

        return Ok(recipe);
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        var deleted = _recipeService.DeleteRecipe(id);
        if (!deleted)
            return NotFound();

        return NoContent();
    }
}
