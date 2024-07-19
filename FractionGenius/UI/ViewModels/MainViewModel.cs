using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using FractionGenius.Application.Interfaces;
using FractionGenius.Domain.Entities;

namespace FractionGenius.UI.ViewModels;

public class MainViewModel : INotifyPropertyChanged
{
    private int _numerator1;
    private int _denominator1;
    private int _numerator2;
    private int _denominator2;
    private string _result;
    private string _selectedOperation;
    private readonly IFractionService _fractionService;

    public MainViewModel(IFractionService fractionService)
    {
        _fractionService = fractionService ?? throw new ArgumentNullException(nameof(fractionService));
        CalculateCommand = new RelayCommand(Calculate);
        Operations = new List<string> { "Add", "Subtract", "Multiply", "Divide" };
        SelectedOperation = Operations[0]; // Default operation
    }

    public int Numerator1
    {
        get => _numerator1;
        set
        {
            _numerator1 = value;
            OnPropertyChanged();
        }
    }

    public int Denominator1
    {
        get => _denominator1;
        set
        {
            _denominator1 = value;
            OnPropertyChanged();
        }
    }

    public int Numerator2
    {
        get => _numerator2;
        set
        {
            _numerator2 = value;
            OnPropertyChanged();
        }
    }

    public int Denominator2
    {
        get => _denominator2;
        set
        {
            _denominator2 = value;
            OnPropertyChanged();
        }
    }

    public string Result
    {
        get => _result;
        set
        {
            _result = value;
            OnPropertyChanged();
        }
    }

    public string SelectedOperation
    {
        get => _selectedOperation;
        set
        {
            _selectedOperation = value;
            OnPropertyChanged();
        }
    }

    public List<string> Operations { get; }

    public ICommand CalculateCommand { get; }

    private void Calculate(object parameter)
    {
        Fraction result = null;

        switch (SelectedOperation)
        {
            case "Add":
                result = _fractionService?.AddFractions(Numerator1, Denominator1, Numerator2, Denominator2);
                break;
            case "Subtract":
                result = _fractionService?.SubtractFractions(Numerator1, Denominator1, Numerator2, Denominator2);
                break;
            case "Multiply":
                result = _fractionService?.MultiplyFractions(Numerator1, Denominator1, Numerator2, Denominator2);
                break;
            case "Divide":
                result = _fractionService?.DivideFractions(Numerator1, Denominator1, Numerator2, Denominator2);
                break;
        }

        Result = result?.ToString() ?? "Ошибка при расчете";
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
