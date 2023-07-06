namespace FoodHelperClassLibrary
{
    public class Enums
    {
    }
    public enum ProteinOptions
    {
        None,
        Chicken, 
        Beef, 
        MincedChicken,
        MincedBeef,
        Pork,
        Bacon,
        Fish,
        Sausage,
    }
    public enum CarbOptions
    {
        None,
        Pasta, 
        Rice, 
        Potatoes, 
        Couscous,
        Bread
    }
    public enum EffortOptions
    {
        Minimal,
        Low,
        Medium,
        High,
    }
    public enum SearchCombanation
    {
        ProteinCarbEffort,
        ProteinCarb,
        ProteinEffort,
        CarbEffort,
        Protein, 
        Carb, 
        Effort,
        None
    }
}
