namespace Lab13
{
    internal class RecipeManager
    {
        //task1
        public List<Recipe> recipes;

        public RecipeManager()
        {
            recipes = new List<Recipe>();
        }

        public void AddRecipe(Recipe recipe)
        {
            recipes.Add(recipe);
        }

        public void RemoveRecipe(string name)
        {
            Recipe recipeToRemove = recipes.Find(recipe => recipe.Name == name);
            if (recipeToRemove != null)
            {
                recipes.Remove(recipeToRemove);
            }
        }
        public void UpdateRecipe(string name, Recipe newRecipe)
        {
            Recipe oldRecipe = recipes.Find(r => r.Name == name);
            if (oldRecipe != null)
            {
                int index = recipes.IndexOf(oldRecipe);
                recipes[index] = newRecipe;
            }
            else
            {
                Console.WriteLine("Recipe not found.");
            }
        }

        public Recipe FindRecipeByName(string name)
        {
            return recipes.Find(recipe => recipe.Name == name);
        }

        public List<Recipe> FindRecipesByCuisine(string cuisine)
        {
            return recipes.FindAll(recipe => recipe.Cuisine == cuisine);
        }

        public void SaveRecipesToFile(string fileName)
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                foreach (Recipe recipe in recipes)
                {
                    writer.WriteLine($"Name: {recipe.Name}");
                    writer.WriteLine($"Cuisine: {recipe.Cuisine}");
                    writer.WriteLine($"Ingredients: {string.Join(", ", recipe.Ingredients)}");
                    writer.WriteLine($"Cooking Time: {recipe.CookingTime} minutes");
                    writer.WriteLine($"Instructions: {recipe.Instructions}");
                    writer.WriteLine();
                }
            }
        }

        public void LoadRecipesFromFile(string fileName)
        {
            recipes.Clear();
            using (StreamReader reader = new StreamReader(fileName))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    //Trim() використовується для видалення пробілів з початку та кінця рядка.
                    Recipe recipe = new Recipe();
                    recipe.Name = line.Split(':')[1].Trim();
                    line = reader.ReadLine();
                    recipe.Cuisine = line.Split(':')[1].Trim();
                    line = reader.ReadLine();
                    recipe.Ingredients = line.Split(':')[1].Trim().Split(',').Select(i => i.Trim()).ToList();
                    line = reader.ReadLine();
                    recipe.CookingTime = int.Parse(line.Split(':')[1].Trim().Split(' ')[0]);
                    line = reader.ReadLine();
                    recipe.Instructions = line.Split(':')[1].Trim();
                    recipes.Add(recipe);
                    reader.ReadLine();
                }
            }
        }

        //task2
        public void ReportCuisine(string cuisine)
        {
            List<Recipe> filteredRecipes = recipes.Where(r => r.Cuisine == cuisine).ToList();
            GenerateReport(filteredRecipes, $"ReportCuisine.txt");
        }

        public void ReportCookingTime(int minTime, int maxTime)
        {
            List<Recipe> filteredRecipes = recipes.Where(r => r.CookingTime >= minTime && r.CookingTime <= maxTime).ToList();
            GenerateReport(filteredRecipes, $"ReportCookingTime.txt");
        }

        public void ReportIngredients(List<string> ingredients)
        {
            List<Recipe> filteredRecipes = recipes.Where(r => r.Ingredients.Intersect(ingredients).Any()).ToList();
            GenerateReport(filteredRecipes, $"ReportIngredients.txt");
        }

        public void ReportName(string name)
        {
            List<Recipe> filteredRecipes = recipes.Where(r => r.Name.ToLower().Contains(name.ToLower())).ToList();
            GenerateReport(filteredRecipes, $"ReportName.txt");
        }

        private void GenerateReport(List<Recipe> recipes, string fileName)
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                if (recipes.Count > 0)
                {
                    foreach (Recipe recipe in recipes)
                    {
                        writer.WriteLine($"Name: {recipe.Name}");
                        writer.WriteLine($"Cuisine: {recipe.Cuisine}");
                        writer.WriteLine($"Ingredients: {string.Join(", ", recipe.Ingredients)}");
                        writer.WriteLine($"Cooking Time: {recipe.CookingTime} minutes");
                        writer.WriteLine($"Instructions: {recipe.Instructions}");
                        writer.WriteLine();
                    }
                }
                else
                {
                    writer.WriteLine("No recipes found for the selected criteria.");
                }
            }
        }

        //task3
        public void ReportCalories(int minCalories, int maxCalories)
        {
            List<Recipe> filteredRecipes = recipes.Where(r => r.IngredientCalories.Values.Sum() >= minCalories && r.IngredientCalories.Values.Sum() <= maxCalories).ToList();
            GenerateReport(filteredRecipes, $"ReportCalories.txt");
        }

        public void ReportType(string dishType)
        {
            List<Recipe> filteredRecipes = recipes.Where(r => r.DishType == dishType).ToList();
            GenerateReport(filteredRecipes, $"ReportType.txt");
        }

        public void ReportCombination(List<string> dishTypes)
        {
            List<Recipe> filteredRecipes = recipes.Where(r => dishTypes.Contains(r.DishType)).ToList();
            GenerateReport(filteredRecipes, $"ReportCombination.txt");
        }
    }
}
