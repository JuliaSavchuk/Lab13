namespace Lab13
{
    class Program
    {
        static void Main(string[] args)
        {
            RecipeManager manager = new RecipeManager();

            manager.AddRecipe(new Recipe
            {
                Name = "Spaghetti Carbonara",
                Cuisine = "Italian",
                Ingredients = new List<string> { "Spaghetti", "Eggs", "Parmesan Cheese", "Bacon" },
                CookingTime = 20,
                Instructions = "Cook spaghetti. Mix eggs and cheese. Fry bacon. Combine all ingredients.",
                IngredientCalories = new Dictionary<string, int> 
                {
                    { "Spaghetti", 220 }, 
                    { "Eggs", 70 }, 
                    { "Parmesan Cheese", 110 }, 
                    { "Bacon", 60 } 
                },
                DishType = "Main Course"
            });

            manager.AddRecipe(new Recipe
            {
                Name = "Caesar Salad",
                Cuisine = "American",
                Ingredients = new List<string> { "Romaine Lettuce", "Chicken Breast", "Parmesan Cheese", "Croutons", "Caesar Dressing" },
                CookingTime = 15,
                Instructions = "Toss lettuce, chicken, cheese, and croutons with dressing.",
                IngredientCalories = new Dictionary<string, int> 
                { 
                    { "Romaine Lettuce", 10 }, 
                    { "Chicken Breast", 165 }, 
                    { "Parmesan Cheese", 110 }, 
                    { "Croutons", 60 }, 
                    { "Caesar Dressing", 160 } 
                },
                DishType = "Salad"
            });

            manager.AddRecipe(new Recipe
            {
                Name = "Chicken Alfredo",
                Cuisine = "Italian",
                Ingredients = new List<string> { "Fettuccine", "Chicken Breast", "Heavy Cream", "Parmesan Cheese", "Garlic", "Butter" },
                CookingTime = 25,
                Instructions = "Cook pasta. Grill chicken. Mix cream, cheese, garlic, and butter. Combine with pasta and chicken.",
                IngredientCalories = new Dictionary<string, int> 
                { 
                    { "Fettuccine", 220 }, 
                    { "Chicken Breast", 165 }, 
                    { "Heavy Cream", 450 }, 
                    { "Parmesan Cheese", 110 }, 
                    { "Garlic", 5 }, 
                    { "Butter", 100 } 
                },
                DishType = "Main Course"
            });

            manager.AddRecipe(new Recipe
            {
                Name = "Chocolate Cake",
                Cuisine = "American",
                Ingredients = new List<string> { "Flour", "Sugar", "Cocoa Powder", "Eggs", "Butter", "Vanilla Extract", "Baking Powder", "Milk" },
                CookingTime = 40,
                Instructions = "Mix dry ingredients. Add wet ingredients. Bake at 350°F for 30 minutes.",
                IngredientCalories = new Dictionary<string, int> 
                { 
                    { "Flour", 110 }, 
                    { "Sugar", 120 }, 
                    { "Cocoa Powder", 20 }, 
                    { "Eggs", 70 }, 
                    { "Butter", 100 }, 
                    { "Vanilla Extract", 12 }, 
                    { "Baking Powder", 5 }, 
                    { "Milk", 80 } 
                },
                DishType = "Dessert"
            });

            manager.SaveRecipesToFile("recipes.txt");

            manager.LoadRecipesFromFile("recipes.txt");

        List<Recipe> italianRecipes = manager.FindRecipesByCuisine("Italian");
        Console.WriteLine("Italian Recipes:");
        foreach (Recipe recipe in italianRecipes)
        {
            Console.WriteLine(recipe.Name);
        }

            manager.ReportCuisine("American");

            manager.ReportCookingTime(15, 30);

            manager.ReportIngredients(new List<string> { "Spaghetti", "Bacon" });

            manager.ReportName("Spaghetti Carbonara");

            manager.ReportType("Main Course");
        }
    }
}