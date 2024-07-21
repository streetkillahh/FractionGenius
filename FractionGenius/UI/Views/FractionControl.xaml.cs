using System.Windows;
using System.Windows.Controls;

namespace FractionGenius.UI.Views
{
    public partial class FractionControl : UserControl
    {
        public FractionControl()
        {
            InitializeComponent();
        }

        public string Numerator
        {
            get { return (string)GetValue(NumeratorProperty); }
            set
            {
                SetValue(NumeratorProperty, value);
                NumeratorTextBlock.Text = value; // Обновите текст при изменении значения
            }
        }

        public static readonly DependencyProperty NumeratorProperty =
            DependencyProperty.Register("Numerator", typeof(string), typeof(FractionControl), new PropertyMetadata(string.Empty));

        public string Denominator
        {
            get { return (string)GetValue(DenominatorProperty); }
            set
            {
                SetValue(DenominatorProperty, value);
                DenominatorTextBlock.Text = value; // Обновите текст при изменении значения
            }
        }

        public static readonly DependencyProperty DenominatorProperty =
            DependencyProperty.Register("Denominator", typeof(string), typeof(FractionControl), new PropertyMetadata(string.Empty));
    }
}
