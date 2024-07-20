using System.Windows.Controls;
using FractionGenius.UI.ViewModels;

namespace FractionGenius.UI.Views.Generator;

public partial class FractionGenerator : Page
{
    public FractionGenerator()
    {
        InitializeComponent();
        DataContext = new FractionGeneratorViewModel();
    }
}
