using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodHelperClassLibrary
{
    public class Search
    {
        public ProteinOptions? Protein { get; set; }
        public CarbOptions? Carb { get; set; }
        public EffortOptions? Effort { get; set; }

        public Dish ExecuteSearch(IEnumerable<Dish> availableDishes)
        {
            switch (SearchAlternative()) 
            {
                case SearchCombanation.ProteinCarbEffort: 
                    return SearchForEffortOption(SearchForCarbOption(SearchForProteinOption(availableDishes))).FirstOrDefault();
                case SearchCombanation.ProteinCarb:
                    return SearchForCarbOption(SearchForProteinOption(availableDishes)).FirstOrDefault();
                case SearchCombanation.ProteinEffort:
                    return SearchForEffortOption(SearchForProteinOption(availableDishes)).FirstOrDefault();
                case SearchCombanation.CarbEffort:
                    return SearchForEffortOption(SearchForCarbOption(availableDishes)).FirstOrDefault();
                case SearchCombanation.Protein:
                    return SearchForProteinOption(availableDishes).FirstOrDefault();
                case SearchCombanation.Carb:
                    return SearchForCarbOption(availableDishes).FirstOrDefault();
                case SearchCombanation.Effort:
                    return SearchForEffortOption(availableDishes).FirstOrDefault();
                case SearchCombanation.None:
                default:
                    return GetRandomDish(availableDishes);
            }

        }

        private SearchCombanation SearchAlternative()
        {
            if (Protein.HasValue && Carb.HasValue && Effort.HasValue)
            {
                return SearchCombanation.ProteinCarbEffort;
            }
            else if (Protein.HasValue && Carb.HasValue)
            {
                return SearchCombanation.ProteinCarb;
            }
            else if (Protein.HasValue && Effort.HasValue)
            {
                return SearchCombanation.ProteinEffort;
            }
            else if (Carb.HasValue && Effort.HasValue)
            {
                return SearchCombanation.CarbEffort;
            }
            else if (Protein.HasValue)
            {
                return SearchCombanation.Protein;
            }
            else if (Carb.HasValue)
            {
                return SearchCombanation.Carb;
            }
            else if (Effort.HasValue)
            {
                return SearchCombanation.Effort;
            }
            else 
            {
                return SearchCombanation.None;
            }
        }

        private List<Dish> SearchForProteinOption(IEnumerable<Dish> availableDishes) =>
            Protein.HasValue ? availableDishes.Where(x => x.Protein == Protein).ToList() : new List<Dish>();
        private List<Dish> SearchForCarbOption(IEnumerable<Dish> availableDishes) =>
            Carb.HasValue ? availableDishes.Where(x => x.Carb == Carb).ToList() : new List<Dish>();
        private List<Dish> SearchForEffortOption(IEnumerable<Dish> availableDishes) =>
            Effort.HasValue ? availableDishes.Where(x => x.Effort == Effort).ToList() : new List<Dish>();

        private Dish GetRandomDish(IEnumerable<Dish> availableDishes)
        {
            var randomIndex = new Random().Next(0, availableDishes.Count());
            return availableDishes.ElementAt(randomIndex);
        }
    }
}
