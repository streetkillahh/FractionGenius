using FractionGenius.Domain.Entities;

namespace FractionGenius.Domain.Interfaces;

public interface IFractionCalculator
{
    Fraction Add(Fraction a, Fraction b);
    Fraction Subtract(Fraction a, Fraction b);
    Fraction Multiply(Fraction a, Fraction b);
    Fraction Divide(Fraction a, Fraction b);
}
