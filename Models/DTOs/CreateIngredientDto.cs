using System.ComponentModel.DataAnnotations;

namespace RecipeApi.Models.DTOs;

public class CreateIngredientDto
{
    [Required]
    [StringLength(100, MinimumLength = 1)]
    public string Name { get; set; } = string.Empty;

    [Range(0.01, double.MaxValue, ErrorMessage = "Quantity must be greater than zero.")]
    public decimal Quantity { get; set; }

    [Required]
    public string Unit { get; set; } = string.Empty;
}
