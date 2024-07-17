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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Summation());
        }
    }
}
