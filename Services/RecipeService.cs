using RecipeApi.Models;
using RecipeApi.Models.DTOs;
using RecipeApi.Repositories;

namespace RecipeApi.Services;

public class RecipeService : IRecipeService
{
    private readonly IRecipeRepository _repository;

    public RecipeService(IRecipeRepository repository)
    {
        _repository = repository;
    }

    public IEnumerable<Recipe> GetAllRecipes()
    {
        return _repository.GetAll();
    }

    public Recipe? GetRecipeById(int id)
    {
        return _repository.GetById(id);
    }

    public IEnumerable<Recipe> SearchRecipes(string term)
    {
        return _repository.Search(term);
    }

    public IEnumerable<Recipe> GetRecipesByDifficulty(string difficulty)
    {
        return _repository.GetByDifficulty(difficulty);
    }

    public Recipe CreateRecipe(CreateRecipeDto dto)
    {
        var recipe = MapToRecipe(dto);
        return _repository.Add(recipe);
    }

    public Recipe? UpdateRecipe(int id, UpdateRecipeDto dto)
    {
        var recipe = MapToRecipe(dto);
        return _repository.Update(id, recipe);
    }

    public bool DeleteRecipe(int id)
    {
        return _repository.Delete(id);
    }

    private static Recipe MapToRecipe(CreateRecipeDto dto)
    {
        return new Recipe
        {
            Name = dto.Name,
            Description = dto.Description,
            PrepTimeMinutes = dto.PrepTimeMinutes,
            CookTimeMinutes = dto.CookTimeMinutes,
            Servings = dto.Servings,
            Difficulty = dto.Difficulty,
            Ingredients = dto.Ingredients.Select(MapToIngredient).ToList(),
            Instructions = dto.Instructions
        };
    }

    private static Recipe MapToRecipe(UpdateRecipeDto dto)
    {
        return new Recipe
        {
            Name = dto.Name,
            Description = dto.Description,
            PrepTimeMinutes = dto.PrepTimeMinutes,
            CookTimeMinutes = dto.CookTimeMinutes,
            Servings = dto.Servings,
            Difficulty = dto.Difficulty,
            Ingredients = dto.Ingredients.Select(MapToIngredient).ToList(),
            Instructions = dto.Instructions
        };
    }

    private static Ingredient MapToIngredient(CreateIngredientDto dto)
    {
        return new Ingredient
        {
            Name = dto.Name,
            Quantity = dto.Quantity,
            Unit = dto.Unit
        };
    }
}
