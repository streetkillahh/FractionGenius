using System;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows;
using FractionGenius.Base;
using FractionGenius.UI.Views;

namespace FractionGenius.UI.ViewModels
{
    public class FractionGeneratorViewModel : ViewModelBase
    {
        private readonly Random _random = new Random();
        private readonly string[] _operators = { " + ", " - ", " * ", " : " };

        public ICommand GenerateFractionCommand { get; }

        public FractionGeneratorViewModel()
        {
            GenerateFractionCommand = new RelayCommand(param => GenerateAndDisplayEquation());
        }

        private void GenerateAndDisplayEquation()
        {
            var paragraph = new Paragraph();
            // Пример с дробями и операторами
            AddFractionWithOptionalWholeNumber(paragraph, GetRandomNumber(), GetRandomNumber());
            AddOperator(paragraph, GetRandomOperator());
            AddFractionWithOptionalWholeNumber(paragraph, GetRandomNumber(), GetRandomNumber());
            AddOperator(paragraph, GetRandomOperator());
            AddFractionWithOptionalWholeNumber(paragraph, GetRandomNumber(), GetRandomNumber());
            AddOperator(paragraph, GetRandomOperator());
            AddFractionWithOptionalWholeNumber(paragraph, GetRandomNumber(), GetRandomNumber());

            EquationDocument.Blocks.Clear();
            EquationDocument.Blocks.Add(paragraph);
        }

        private void AddFractionWithOptionalWholeNumber(Paragraph paragraph, string numerator, string denominator)
        {
            // Случайным образом добавляем целое число перед дробью
            if (_random.NextDouble() < 0.5) // 50% шанс добавления целого числа
            {
                var wholeNumber = GetRandomNumber();
                var wholeNumberRun = new Run(wholeNumber + " ")
                {
                    FontSize = 24,
                    FontWeight = FontWeights.Bold,
                    BaselineAlignment = BaselineAlignment.Center
                };
                paragraph.Inlines.Add(wholeNumberRun);
            }

            AddFraction(paragraph, numerator, denominator);
        }

        private void AddFraction(Paragraph paragraph, string numerator, string denominator)
        {
            var fraction = new FractionControl { Numerator = numerator, Denominator = denominator };
            var container = new InlineUIContainer(fraction)
            {
                BaselineAlignment = BaselineAlignment.Center
            };
            paragraph.Inlines.Add(container);
        }

        private void AddOperator(Paragraph paragraph, string operatorText)
        {
            var operatorRun = new Run(operatorText)
            {
                FontSize = 24,
                FontWeight = FontWeights.Bold,
                BaselineAlignment = BaselineAlignment.Center
            };
            paragraph.Inlines.Add(operatorRun);
        }

        private string GetRandomNumber()
        {
            return _random.Next(1, 10).ToString();
        }

        private string GetRandomOperator()
        {
            return _operators[_random.Next(_operators.Length)];
        }

        public FlowDocument EquationDocument { get; } = new FlowDocument();
    }
}
