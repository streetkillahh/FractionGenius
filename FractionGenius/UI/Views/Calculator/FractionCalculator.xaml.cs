using System.Windows.Controls;
using FractionGenius.Application.Services;
using FractionGenius.Domain.Services;
using FractionGenius.UI.ViewModels;

namespace FractionGenius.UI.Views.Calculator;

public partial class FractionCalculator : Page
{
    public FractionCalculator()
    {
        InitializeComponent();
        DataContext = new MainViewModel(new FractionService(new FractionGenius.Domain.Services.FractionCalculator()));
    }
}
