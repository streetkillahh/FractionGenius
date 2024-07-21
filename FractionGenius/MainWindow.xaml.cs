using System.Windows;
using FractionGenius.Application.Services;
using FractionGenius.Domain.Services;
using FractionGenius.UI.ViewModels;
using FractionGenius.UI.Views.Generator;

namespace FractionGenius
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel(new FractionService(new FractionCalculator()));
            mainFrame.Content = new FractionGenerator(); // Используйте правильный путь
        }
    }
}
