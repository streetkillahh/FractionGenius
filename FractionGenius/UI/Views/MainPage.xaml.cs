using FractionGenius.UI.Views.Calculator;
using FractionGenius.UI.Views.Generator;
using System.Windows;
using System.Windows.Controls;

namespace FractionGenius.Views
{
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new FractionCalculator());
        }
        private void Button_Subtract_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new FractionGenerator());
        }
    }
}
