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

    // Добавить другие операции, такие как сложение, вычитание, умножение и деление
    /*
    public static Fraction operator +(Fraction a, Fraction b)
    {
        int numerator = a.Numerator * b.Denominator + b.Numerator * a.Denominator;
        int denominator = a.Denominator * b.Denominator;
        return new Fraction(numerator, denominator);
    }

    public static Fraction operator -(Fraction a, Fraction b)
    {
        int numerator = a.Numerator * b.Denominator - b.Numerator * a.Denominator;
        int denominator = a.Denominator * b.Denominator;
        return new Fraction(numerator, denominator);
    }

    public static Fraction operator *(Fraction a, Fraction b)
    {
        return new Fraction(a.Numerator * b.Numerator, a.Denominator * b.Denominator);
    }

    public static Fraction operator /(Fraction a, Fraction b)
    {
        if (b.Numerator == 0)
        {
            throw new ArgumentException("Нельзя делить на дробь с числителем, равным нулю.");
        }
        return new Fraction(a.Numerator * b.Denominator, a.Denominator * b.Numerator);
    }*/
}
