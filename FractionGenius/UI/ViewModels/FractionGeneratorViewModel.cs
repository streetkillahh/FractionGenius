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

            // Генерация случайного количества дробей
            int numberOfFractions = _random.Next(4, 11);

            for (int i = 0; i < numberOfFractions; i++)
            {
                // Генерация случайного натурального числа с 50% шансом
                if (_random.Next(2) == 0)
                {
                    var naturalNumberRun = new Run(GetRandomNaturalNumber() + " ")
                    {
                        FontSize = 24, 
                        FontWeight = FontWeights.Bold 
                    };
                    paragraph.Inlines.Add(naturalNumberRun);
                }

                // Добавление дроби
                AddFraction(paragraph, GetRandomNumber(), GetRandomNumber());

                // Добавление случайного оператора, если это не последняя дробь
                if (i < numberOfFractions - 1)
                {
                    var operatorRun = new Run(" " + GetRandomOperator() + " ")
                    {
                        FontSize = 24, 
                        FontWeight = FontWeights.Bold 
                    };
                    paragraph.Inlines.Add(operatorRun);
                }
            }

            // Замена точки на знак равенства
            var equalsRun = new Run(" = ")
            {
                FontSize = 24, 
                FontWeight = FontWeights.Bold 
            };
            paragraph.Inlines.Add(equalsRun);

            EquationDocument.Blocks.Clear();
            EquationDocument.Blocks.Add(paragraph);
        }

        private void AddFractionWithOptionalWholeNumber(Paragraph paragraph, string numerator, string denominator)
        {
            // Случайным образом добавляет целое число перед дробью
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

        private string GetRandomNaturalNumber()
        {
            return _random.Next(1, 10).ToString();
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
            return _random.Next(1, 10).ToString(); // Генерирует случайные числа для дробей
        }

        private string GetRandomOperator()
        {
            var operators = new[] { "+", "-", ":", "*" };
            return operators[_random.Next(operators.Length)];
        }

        public FlowDocument EquationDocument { get; } = new FlowDocument();
    }
}
