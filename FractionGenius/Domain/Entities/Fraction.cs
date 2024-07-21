using System.Windows;

namespace FractionGenius.Domain.Entities;

public class Fraction
{
    public int Numerator { get; set; }
    public int Denominator { get; set; }

    public Fraction(int numerator, int denominator)
    {
        if (denominator == 0)
        {
            MessageBox.Show("Знаменатель не может быть равным 0.");
            throw new ArgumentException("Знаменатель не может быть равным 0.");
        }
        Numerator = numerator;
        Denominator = denominator;
        Simplify(); // Вызов метода для упрощения дроби при создании новой дроби
    }

    // Метод для упрощения дроби
    public void Simplify()
    {
        int gcd = GCD(Math.Abs(Numerator), Math.Abs(Denominator));
        Numerator /= gcd;
        Denominator /= gcd;

        // Если знаменатель отрицательный, перенести знак к числителю
        if (Denominator < 0)
        {
            Numerator = -Numerator;
            Denominator = -Denominator;
        }
    }

    // Метод для нахождения наибольшего общего делителя
    private int GCD(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    // Переопределение метода ToString для удобного вывода
    public override string ToString()
    {
        return $"Результат:{Numerator}/{Denominator}";
    }
}
