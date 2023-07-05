using FoodHelperClassLibrary;
using System;
using System.Collections.Generic;
using System.Windows;

namespace FoodHelper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Dish> Dishes { get; set; } = new List<Dish>();

        public MainWindow()
        {
            InitializeComponent();
            FillComboBoxes();
            CreateDefaultDishes();
        }

        private void FillComboBoxes()
        {
            ProteinComboBox.ItemsSource = Enum.GetValues(typeof(ProteinOptions));
            CarbComboBox.ItemsSource = Enum.GetValues(typeof(CarbOptions));
            EffortComboBox.ItemsSource = Enum.GetValues(typeof(EffortOptions));
        }

        private void FeedMeButton_Click(object sender, RoutedEventArgs e)
        {
            var search = new Search()
            { 
                Protein = (ProteinOptions?)ProteinComboBox.SelectedItem,
                Carb = (CarbOptions?)CarbComboBox.SelectedItem,
                Effort = (EffortOptions?)EffortComboBox.SelectedItem,
            };

            //execute search
            var searchResult = search.ExecuteSearch(Dishes);

            //display top result
            SetRecipeText(searchResult);
        }

        private void SetRecipeText(Dish dish)
        {
            RecipeTextBox.Text = dish.Name + "\n\n" + dish.Recipe;
        }

        private void CreateDefaultDishes()
        {
            Dishes.Add(
                new Dish() 
                {
                    Name = "Garlic pasta",
                    Protein = ProteinOptions.Chicken,
                    Carb = CarbOptions.Pasta,
                    Effort = EffortOptions.Low,
                    Recipe = "Boil the pasta in salted water. " +
                    "\nCut up the chicken in medium size chunks and fry in oil on medium to high heat. " +
                    "Add salt and pepper. Fry until the chicken is cooked through and starting to brown." +
                    "Peel two cloves of garlic and press into pan with chicken. When the garlic starts " +
                    "to turn brown and crispy, add cream and some soy sauce. Add salt and pepper to taste. ",
                    Minutes = 30
                });
            Dishes.Add(
                new Dish() 
                {
                    Name = "Hot dog and fries",
                    Protein = ProteinOptions.Sausage,
                    Carb = CarbOptions.Potatoes,
                    Effort = EffortOptions.Minimal,
                    Recipe = "Put hot dogs and fries on a baking sheet and put it in the oven. " +
                    "Take out after half of the time to stir and salt the fries.",
                    Minutes = 20
                });
            Dishes.Add(
                new Dish() 
                {
                    Name = "Baked potatoes with garlic butter",
                    Protein = ProteinOptions.None,
                    Carb = CarbOptions.Potatoes,
                    Effort = EffortOptions.Minimal,
                    Recipe = "Stab the potatoes with a fork. Put them in the oven. " +
                    "\nMix butter with garlic and salt to taste.",
                    Minutes = 60
                });
            Dishes.Add(
                new Dish() 
                {
                    Name = "Sherpherd's pie",
                    Protein = ProteinOptions.MincedBeef,
                    Carb = CarbOptions.Potatoes,
                    Effort = EffortOptions.High,
                    Recipe = "Peel the potatoes and boil them in lightly salted water. Let them cool " +
                    "of a bit before you start mashing. Add butter, cream, egg yolk and cheddar. Mix and " +
                    "match and add salt and pepper to taste." +
                    "\nFry the minced beef. Add worchestershire sauce, soy sauce, tabasco and egg. Salt and pepper to taste. " +
                    "\nPut the fried minced beef in a oven dish and bake for about 15 min. Take out the dish and add a layer of " +
                    "mashed potatoes and sprinkle some cheddar on top. Bake for 20 min or until golden. ",
                    Minutes = 120
                });
        }
    }
}
