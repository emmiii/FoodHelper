namespace FoodHelperClassLibrary
{
    public class Dish
    {
        public string Name { get; set; }
        public ProteinOptions Protein { get; set; }
        public CarbOptions Carb { get; set; }
        public EffortOptions Effort { get; set; }
        public string Recipe { get; set; }
        public int Minutes { get; set; }

        public Dish()
        {
            Protein = ProteinOptions.Chicken;
            Carb = CarbOptions.Pasta;
            Effort = EffortOptions.Low;
        }
    }
}
