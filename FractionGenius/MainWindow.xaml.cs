using System.Windows;
using FractionGenius.Application.Services;
using FractionGenius.Domain.Services;
using FractionGenius.UI.ViewModels;
using FractionGenius.UI.Views.Generator;
using FractionGenius.Views;

namespace FractionGenius
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel(new FractionService(new FractionCalculator()));
            MainFrame.Content = new MainPage(); // Путь к странице при открытии приложения
        }
        private void GoHome_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new MainPage());
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            if (MainFrame.CanGoBack)
            {
                MainFrame.GoBack();
            }
        }
    }
}
