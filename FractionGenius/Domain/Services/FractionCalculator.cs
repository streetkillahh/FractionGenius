using FractionGenius.Domain.Entities;
using FractionGenius.Domain.Interfaces;

namespace FractionGenius.Domain.Services
{
    public class FractionCalculator : IFractionCalculator
    {
        public Fraction Add(Fraction a, Fraction b)
        {
            var numerator = a.Numerator * b.Denominator + b.Numerator * a.Denominator;
            var denominator = a.Denominator * b.Denominator;
            return new Fraction(numerator, denominator);
        }

        public Fraction Subtract(Fraction a, Fraction b)
        {
            var numerator = a.Numerator * b.Denominator - b.Numerator * a.Denominator;
            var denominator = a.Denominator * b.Denominator;
            return new Fraction(numerator, denominator);
        }

        public Fraction Multiply(Fraction a, Fraction b)
        {
            var numerator = a.Numerator * b.Numerator;
            var denominator = a.Denominator * b.Denominator;
            return new Fraction(numerator, denominator);
        }

        public Fraction Divide(Fraction a, Fraction b)
        {
            var numerator = a.Numerator * b.Denominator;
            var denominator = a.Denominator * b.Numerator;
            return new Fraction(numerator, denominator);
        }
    }
}
