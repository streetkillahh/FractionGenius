using System;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using FractionGenius.Base;
using FractionGenius.UI.Views;

namespace FractionGenius.UI.ViewModels
{
    public class FractionGeneratorViewModel : ViewModelBase
    {
        private readonly Random _random = new Random();

        public ICommand GenerateFractionCommand { get; }

        public FractionGeneratorViewModel()
        {
            GenerateFractionCommand = new RelayCommand(param => GenerateAndDisplayEquation());
        }

        private void GenerateAndDisplayEquation()
        {
            var paragraph = new Paragraph
            {
                TextAlignment = TextAlignment.Center // Выравнивание по центру
            };

            AddFraction(paragraph, GetRandomNumber(), GetRandomNumber());
            paragraph.Inlines.Add(CreateOperator(" + "));
            AddFraction(paragraph, GetRandomNumber(), GetRandomNumber());
            paragraph.Inlines.Add(CreateOperator(" - "));
            AddFraction(paragraph, GetRandomNumber(), GetRandomNumber());
            paragraph.Inlines.Add(CreateOperator(" : "));
            AddFraction(paragraph, GetRandomNumber(), GetRandomNumber());
            paragraph.Inlines.Add(CreateOperator(" * "));

            EquationDocument.Blocks.Clear();
            EquationDocument.Blocks.Add(paragraph);
        }

        private InlineUIContainer CreateOperator(string operatorText)
        {
            var textBlock = new TextBlock
            {
                Text = operatorText,
                TextAlignment = TextAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };
            return new InlineUIContainer(textBlock);
        }

        private void AddFraction(Paragraph paragraph, string numerator, string denominator)
        {
            var fraction = new FractionControl
            {
                Numerator = numerator,
                Denominator = denominator
            };
            var container = new InlineUIContainer(fraction)
            {
                BaselineAlignment = BaselineAlignment.Center
            };
            paragraph.Inlines.Add(container);
        }

        private string GetRandomNumber()
        {
            return _random.Next(1, 10).ToString();
        }

        public FlowDocument EquationDocument { get; } = new FlowDocument();
    }
}
