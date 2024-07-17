namespace FractionGenius.Domain.Entities;

public class Fraction
{
    public int Numerator { get; set; }
    public int Denominator { get; set; }
    public Fraction(int numerator, int denominator)
    {
        if (denominator == 0)
        {
            throw new ArgumentException("Знаменатель не может быть равен 0.");

            Numerator = numerator;
            Denominator = denominator;
        }

        // Добавить методы для упрощения, приведения и другие операции с дробями
    }
}
