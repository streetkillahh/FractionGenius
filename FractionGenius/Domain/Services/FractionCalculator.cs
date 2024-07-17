using FractionGenius.Domain.Entities;
using FractionGenius.Domain.Interfaces;

namespace FractionGenius.Domain.Services;

public class FractionCalculator : IFractionCalculator
{
    // Сложение
    public Fraction Add(Fraction a, Fraction b)
    {
        int numerator = a.Numerator * b.Denominator + b.Numerator * a.Denominator;
        int denominator = a.Denominator * b.Denominator;
        return new Fraction(numerator, denominator);
    }

    //Вычитание
    public Fraction Subtract(Fraction a, Fraction b)
    {
        int numerator = a.Numerator * b.Denominator - b.Numerator * a.Denominator;
        int denominator = a.Denominator * b.Denominator;
        return new Fraction(numerator, denominator);
    }

    // Умножение
    public Fraction Multiply(Fraction a, Fraction b)
    {
        int numerator = a.Numerator * b.Numerator;
        int denominator = a.Denominator * b.Denominator;
        return new Fraction(numerator, denominator);
    }

    // Деление
    public Fraction Divide(Fraction a, Fraction b)
    {
        if (b.Numerator == 0)
            throw new DivideByZeroException();

        int numerator = b.Numerator * a.Denominator;
        int denominator = b.Denominator * a.Numerator;
        return new Fraction(numerator, denominator);
    }
}
