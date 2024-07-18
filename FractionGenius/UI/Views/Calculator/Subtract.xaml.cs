using FractionGenius.Application.Services;
using FractionGenius.Domain.Services;
using FractionGenius.UI.ViewModels;
using System.Windows.Controls;

namespace FractionGenius.UI.Views.Calculator;

public partial class Subtract : Page
{
    public Subtract()
    {
        InitializeComponent();
        DataContext = new MainViewModel(new FractionService(new FractionCalculator()));
    }
}
