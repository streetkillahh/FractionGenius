using System.Windows.Controls;
using System.Windows.Documents;
using FractionGenius.UI.ViewModels;

namespace FractionGenius.UI.Views.Generator
{
    public partial class FractionGenerator : Page
    {
        private FractionGeneratorViewModel ViewModel => DataContext as FractionGeneratorViewModel;

        public FractionGenerator()
        {
            InitializeComponent();
            DataContext = new FractionGeneratorViewModel(); // Убедитесь, что ViewModel установлен

            // Установите документ RichTextBox из ViewModel
            if (ViewModel != null)
            {
                EquationRichTextBox.Document = ViewModel.EquationDocument;
            }
        }
    }
}
