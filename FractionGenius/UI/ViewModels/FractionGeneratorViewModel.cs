using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using FractionGenius.Domain.Entities;

namespace FractionGenius.UI.ViewModels;

public class FractionGeneratorViewModel : INotifyPropertyChanged
{
    private readonly Random _random;
    private Fraction _generatedFraction1;
    private Fraction _generatedFraction2;
    private string _generatedOperation;
    private string _fractionEquation;

    public FractionGeneratorViewModel()
    {
        _random = new Random();
        GenerateFractionCommand = new RelayCommand(GenerateFraction);
    }

    public Fraction GeneratedFraction1
    {
        get => _generatedFraction1;
        set
        {
            _generatedFraction1 = value;
            OnPropertyChanged();
        }
    }

    public Fraction GeneratedFraction2
    {
        get => _generatedFraction2;
        set
        {
            _generatedFraction2 = value;
            OnPropertyChanged();
        }
    }

    public string GeneratedOperation
    {
        get => _generatedOperation;
        set
        {
            _generatedOperation = value;
            OnPropertyChanged();
        }
    }

    public string FractionEquation
    {
        get => _fractionEquation;
        set
        {
            _fractionEquation = value;
            OnPropertyChanged();
        }
    }

    public ICommand GenerateFractionCommand { get; }

    private void GenerateFraction(object parameter)
    {
        GeneratedFraction1 = new Fraction(_random.Next(1, 10), _random.Next(1, 10));
        GeneratedFraction2 = new Fraction(_random.Next(1, 10), _random.Next(1, 10));
        GeneratedOperation = GetRandomOperation();
        FractionEquation = $"{GeneratedFraction1.Numerator}/{GeneratedFraction1.Denominator} {GeneratedOperation} {GeneratedFraction2.Numerator}/{GeneratedFraction2.Denominator}";
    }

    private string GetRandomOperation()
    {
        string[] operations = { "+", "-", "*", "/" };
        int index = _random.Next(operations.Length);
        return operations[index];
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
