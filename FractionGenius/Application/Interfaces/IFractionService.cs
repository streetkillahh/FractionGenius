using FractionGenius.Domain.Entities;

namespace FractionGenius.Application.Interfaces;

public interface IFractionService
{
    Fraction AddFractions(int numerator1, int denominator1, int numerator2, int denominator2);
    Fraction SubtractFractions(int numerator1, int denominator1, int numerator2, int denominator2);
    Fraction MultiplyFractions(int numerator1, int denominator1, int numerator2, int denominator2);
    Fraction DivideFractions(int numerator1, int denominator1, int numerator2, int denominator2);
}
