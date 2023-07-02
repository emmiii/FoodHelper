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
        public MainWindow()
        {
            InitializeComponent();
            FillComboBoxes();
        }

        private void FillComboBoxes()
        {
            ProteinComboBox.ItemsSource = Enum.GetValues(typeof(ProteinOptions));
            CarbComboBox.ItemsSource = Enum.GetValues(typeof(CarbOptions));
            EffortComboBox.ItemsSource = Enum.GetValues(typeof(EffortOptions));
        }

        private void FeedMeButton_Click(object sender, RoutedEventArgs e)
        {
            //get selected values
            var search = new Search()
            { 
                Protein = (ProteinOptions?)ProteinComboBox.SelectedItem,
                Carb = (CarbOptions?)CarbComboBox.SelectedItem,
                Effort = (EffortOptions?)EffortComboBox.SelectedItem,
            };

            //execute search

            //display top result
        }
    }
}
