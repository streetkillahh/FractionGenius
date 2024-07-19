using FractionGenius.Application.Interfaces;
using FractionGenius.Domain.Entities;
using FractionGenius.Domain.Interfaces;

namespace FractionGenius.Application.Services;

public class FractionService : IFractionService
{
    private readonly IFractionCalculator _calculator;

    public FractionService(IFractionCalculator calculator)
    {
        _calculator = calculator;
    }

    public Fraction AddFractions(int numerator1, int denominator1, int numerator2, int denominator2)
    {
        var fraction1 = new Fraction(numerator1, denominator1);
        var fraction2 = new Fraction(numerator2, denominator2);
        return _calculator.Add(fraction1, fraction2);
    }
    public Fraction SubtractFractions(int numerator1, int denominator1, int numerator2, int denominator2)
    {
        var fraction1 = new Fraction(numerator1, denominator1);
        var fraction2 = new Fraction(numerator2, denominator2);
        return _calculator.Subtract(fraction1, fraction2);
    }
    public Fraction MultiplyFractions(int numerator1, int denominator1, int numerator2, int denominator2)
    {
        var fraction1 = new Fraction(numerator1, denominator1);
        var fraction2 = new Fraction(numerator2, denominator2);
        return _calculator.Multiply(fraction1, fraction2);
    }
    public Fraction DivideFractions(int numerator1, int denominator1, int numerator2, int denominator2)
    {
        var fraction1 = new Fraction(numerator1, denominator1);
        var fraction2 = new Fraction(numerator2, denominator2);
        return _calculator.Divide(fraction1, fraction2);
    }
}
