using RecipeApi.Models;
using RecipeApi.Models.DTOs;

namespace RecipeApi.Services;

public interface IRecipeService
{
    IEnumerable<Recipe> GetAllRecipes();
    Recipe? GetRecipeById(int id);
    IEnumerable<Recipe> SearchRecipes(string term);
    IEnumerable<Recipe> GetRecipesByDifficulty(string difficulty);
    Recipe CreateRecipe(CreateRecipeDto dto);
    Recipe? UpdateRecipe(int id, UpdateRecipeDto dto);
    bool DeleteRecipe(int id);
}
