# RecipeApi

Ett RESTful Web API byggt med ASP.NET Core för att hantera matrecept. API:et stödjer CRUD-operationer på recept och ingredienser.

## Teknikstack

- ASP.NET Core (.NET 9)
- xUnit & Moq för enhetstester
- Swagger/OpenAPI för dokumentation
- In-memory datalagring

## Projektstruktur

```
RecipeApi/
├── Controllers/
│   └── RecipesController.cs
├── Services/
│   ├── IRecipeService.cs
│   └── RecipeService.cs
├── Repositories/
│   ├── IRecipeRepository.cs
│   └── RecipeRepository.cs
├── Models/
│   ├── Recipe.cs
│   ├── Ingredient.cs
│   └── DTOs/
│       ├── CreateRecipeDto.cs
│       ├── UpdateRecipeDto.cs
│       └── CreateIngredientDto.cs
├── Program.cs
└── RecipeApi.Tests/
    ├── RecipeServiceTests.cs
    └── RecipesControllerTests.cs
```

## Kom igång

### Förutsättningar

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9)

### Köra projektet

```bash
dotnet run
```

API:et startar på `http://localhost:5260`. Öppna Swagger UI i webbläsaren:

```
http://localhost:5260/swagger
```

### Köra tester

```bash
dotnet test
```

## API-endpoints

| Metod  | Route                            | Beskrivning              |
|--------|----------------------------------|--------------------------|
| GET    | /api/recipes                     | Hämta alla recept        |
| GET    | /api/recipes/{id}                | Hämta specifikt recept   |
| GET    | /api/recipes/search?q={term}     | Sök recept               |
| GET    | /api/recipes/difficulty/{level}  | Filtrera på svårighetsgrad |
| POST   | /api/recipes                     | Skapa nytt recept        |
| PUT    | /api/recipes/{id}                | Uppdatera recept         |
| DELETE | /api/recipes/{id}                | Ta bort recept           |

## Exempel

### Skapa recept

```
POST /api/recipes
Content-Type: application/json

{
  "name": "Pannkakor",
  "description": "Klassiska svenska pannkakor",
  "prepTimeMinutes": 10,
  "cookTimeMinutes": 20,
  "servings": 4,
  "difficulty": "Easy",
  "ingredients": [
    { "name": "Mjöl", "quantity": 3, "unit": "dl" },
    { "name": "Mjölk", "quantity": 6, "unit": "dl" },
    { "name": "Ägg", "quantity": 3, "unit": "st" },
    { "name": "Salt", "quantity": 0.5, "unit": "tsk" }
  ],
  "instructions": [
    "Vispa ihop mjöl, mjölk och ägg till en slät smet",
    "Låt vila 30 minuter",
    "Stek i smör i het stekpanna"
  ]
}
```

### Svar (201 Created)

```json
{
  "id": 1,
  "name": "Pannkakor",
  "description": "Klassiska svenska pannkakor",
  "prepTimeMinutes": 10,
  "cookTimeMinutes": 20,
  "servings": 4,
  "difficulty": "Easy",
  "ingredients": [...],
  "instructions": [...],
  "createdAt": "2024-03-15T10:30:00Z"
}
```

## Tester

Projektet innehåller 8 enhetstester:

**Service-tester (5 st)**
- GetAllRecipesAsync returnerar lista med recept
- GetRecipeByIdAsync returnerar recept vid giltigt ID
- GetRecipeByIdAsync returnerar null vid ogiltigt ID
- CreateRecipeAsync skapar och returnerar recept
- SearchRecipesAsync filtrerar korrekt

**Controller-tester (3 st)**
- GetAll returnerar 200 OK med recept
- GetById returnerar 404 Not Found vid ogiltigt ID
- Create returnerar 201 Created med recept


