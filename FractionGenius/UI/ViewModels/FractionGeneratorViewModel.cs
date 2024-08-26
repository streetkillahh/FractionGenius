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
            int numberOfFractions = _random.Next(4, 11);

            bool openBracket = false;
            int bracketStartIndex = 0;

            for (int i = 0; i < numberOfFractions; i++)
            {
                // Возможность открытия скобки
                if (!openBracket && _random.Next(0, 3) == 0 && i < numberOfFractions - 2)
                {
                    paragraph.Inlines.Add(new Run("(")
                    {
                        FontSize = 24,
                        FontWeight = FontWeights.Bold
                    });
                    openBracket = true;
                    bracketStartIndex = i;
                }

                // Генерация дроби с опциональным целым числом
                AddFractionWithOptionalWholeNumber(paragraph, GetRandomNumber(), GetRandomNumber());

                // Возможность закрытия скобки
                if (openBracket && i > bracketStartIndex + 1 && (i == numberOfFractions - 1 || _random.Next(0, 3) == 0))
                {
                    paragraph.Inlines.Add(new Run(")")
                    {
                        FontSize = 24,
                        FontWeight = FontWeights.Bold
                    });
                    openBracket = false;

                    // Если скобки охватывают всё выражение, удаляем их
                    if (bracketStartIndex == 0 && i == numberOfFractions - 1)
                    {
                        paragraph.Inlines.Remove(paragraph.Inlines.FirstInline);
                        paragraph.Inlines.Remove(paragraph.Inlines.LastInline);
                    }
                }

                // Добавление оператора
                if (i < numberOfFractions - 1)
                {
                    paragraph.Inlines.Add(new Run(" " + GetRandomOperator() + " ")
                    {
                        FontSize = 24,
                        FontWeight = FontWeights.Bold
                    });
                }
            }

            // Добавление знака равно
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
            if (_random.NextDouble() < 0.5) // 50% шанс добавления натурального числа перед дробью
            {
                var naturalNumber = GetRandomNaturalNumber();
                var naturalNumberRun = new Run(naturalNumber)
                {
                    FontSize = 24,
                    FontWeight = FontWeights.Bold,
                    BaselineAlignment = BaselineAlignment.Center
                };
                paragraph.Inlines.Add(naturalNumberRun);

                // Добавляем дробь с пробелом после натурального числа
                AddFraction(paragraph, numerator, denominator);
            }
            else // Иначе добавляем целое число с операцией
            {
                var wholeNumber = GetRandomWholeNumber();
                var wholeNumberRun = new Run(wholeNumber)
                {
                    FontSize = 24,
                    FontWeight = FontWeights.Bold,
                    BaselineAlignment = BaselineAlignment.Center
                };
                paragraph.Inlines.Add(wholeNumberRun);

                // Добавляем случайный оператор с пробелами до и после
                AddOperator(paragraph,GetRandomOperator());

                // Добавляем дробь с пробелами
                AddFraction(paragraph, numerator, denominator);
            }
        }

        private string GetRandomNaturalNumber()
        {
            return _random.Next(1, 10).ToString(); // Генерация случайного натурального числа
        }

        private string GetRandomWholeNumber()
        {
            // Генерация случайного целого числа (может быть отрицательным или положительным)
            int number = _random.Next(-9, 10);
            return number == 0 ? "1" : number.ToString(); // Исключаем ноль
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
            var operatorRun = new Run(" " + operatorText + " ")
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
