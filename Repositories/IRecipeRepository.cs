using RecipeApi.Models;

namespace RecipeApi.Repositories;

public interface IRecipeRepository
{
    IEnumerable<Recipe> GetAll();
    Recipe? GetById(int id);
    IEnumerable<Recipe> Search(string term);
    IEnumerable<Recipe> GetByDifficulty(string difficulty);
    Recipe Add(Recipe recipe);
    Recipe? Update(int id, Recipe recipe);
    bool Delete(int id);
}
