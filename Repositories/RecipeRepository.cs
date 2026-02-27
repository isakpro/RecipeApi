using RecipeApi.Models;

namespace RecipeApi.Repositories;

public class RecipeRepository : IRecipeRepository
{
    private readonly List<Recipe> _recipes = [];
    private int _nextRecipeId = 1;
    private int _nextIngredientId = 1;

    public IEnumerable<Recipe> GetAll()
    {
        return _recipes;
    }

    public Recipe? GetById(int id)
    {
        return _recipes.FirstOrDefault(r => r.Id == id);
    }

    public IEnumerable<Recipe> Search(string term)
    {
        var lowerTerm = term.ToLowerInvariant();

        return _recipes.Where(r =>
            r.Name.Contains(lowerTerm, StringComparison.OrdinalIgnoreCase) ||
            r.Description.Contains(lowerTerm, StringComparison.OrdinalIgnoreCase) ||
            r.Ingredients.Any(i => i.Name.Contains(lowerTerm, StringComparison.OrdinalIgnoreCase)));
    }

    public IEnumerable<Recipe> GetByDifficulty(string difficulty)
    {
        return _recipes.Where(r =>
            r.Difficulty.Equals(difficulty, StringComparison.OrdinalIgnoreCase));
    }

    public Recipe Add(Recipe recipe)
    {
        recipe.Id = _nextRecipeId++;
        AssignIngredientIds(recipe.Ingredients);
        _recipes.Add(recipe);
        return recipe;
    }

    public Recipe? Update(int id, Recipe recipe)
    {
        var existing = GetById(id);
        if (existing is null)
            return null;

        existing.Name = recipe.Name;
        existing.Description = recipe.Description;
        existing.PrepTimeMinutes = recipe.PrepTimeMinutes;
        existing.CookTimeMinutes = recipe.CookTimeMinutes;
        existing.Servings = recipe.Servings;
        existing.Difficulty = recipe.Difficulty;
        existing.Ingredients = recipe.Ingredients;
        existing.Instructions = recipe.Instructions;

        AssignIngredientIds(existing.Ingredients);

        return existing;
    }

    public bool Delete(int id)
    {
        var recipe = GetById(id);
        if (recipe is null)
            return false;

        return _recipes.Remove(recipe);
    }

    private void AssignIngredientIds(List<Ingredient> ingredients)
    {
        foreach (var ingredient in ingredients.Where(i => i.Id == 0))
        {
            ingredient.Id = _nextIngredientId++;
        }
    }
}
