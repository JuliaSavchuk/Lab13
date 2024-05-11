namespace Lab13
{
    internal class Recipe
    {
        public string Name { get; set; }
        public string Cuisine { get; set; }
        public List<string> Ingredients { get; set; }
        public int CookingTime { get; set; }
        public string Instructions { get; set; }
        public Dictionary<string, int> IngredientCalories { get; set; }
        public string DishType { get; set; }

        public override string ToString()
        {
            return $"{Name} ({Cuisine}) - {CookingTime} min";
        }
    }
}
