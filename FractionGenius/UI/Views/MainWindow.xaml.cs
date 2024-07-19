using FractionGenius.Application.Services;
using FractionGenius.Domain.Services;
using FractionGenius.UI.ViewModels;
using System.Windows;

namespace FractionGenius
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel(new FractionService(new FractionCalculator()));
            mainFrame.Content = new Views.MainPage();
        }
    }
}