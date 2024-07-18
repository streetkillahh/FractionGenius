using FractionGenius.Application.Services;
using FractionGenius.Domain.Services;
using FractionGenius.UI.ViewModels;
using System.Windows.Controls;

namespace FractionGenius.Views
{
    public partial class Summation : Page
    {
        public Summation()
        {
            InitializeComponent();
            DataContext = new MainViewModel(new FractionService(new FractionCalculator()));
        }
    }
}
