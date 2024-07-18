using FractionGenius.UI.Views.Calculator;
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
            NavigationService.Navigate(new Summation());
        }
        private void Button_Subtract_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Subtract());
        }
        private void Button_Multiply_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Multiply());
        }
        private void Button_Divide_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Summation());
        }
    }
}
