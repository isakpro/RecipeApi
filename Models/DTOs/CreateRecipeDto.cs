using System.ComponentModel.DataAnnotations;

namespace RecipeApi.Models.DTOs;

public class CreateRecipeDto
{
    [Required]
    [StringLength(200, MinimumLength = 1)]
    public string Name { get; set; } = string.Empty;

    [Required]
    public string Description { get; set; } = string.Empty;

    [Range(0, 1440)]
    public int PrepTimeMinutes { get; set; }

    [Range(0, 1440)]
    public int CookTimeMinutes { get; set; }

    [Range(1, 100)]
    public int Servings { get; set; }

    [Required]
    [RegularExpression("^(Easy|Medium|Hard)$", ErrorMessage = "Difficulty must be Easy, Medium, or Hard.")]
    public string Difficulty { get; set; } = "Easy";

    public List<CreateIngredientDto> Ingredients { get; set; } = [];

    [MinLength(1, ErrorMessage = "At least one instruction is required.")]
    public List<string> Instructions { get; set; } = [];
}
