using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using FractionGenius.Application.Interfaces;
using FractionGenius.Application.Services;

namespace FractionGenius.UI.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private int _numerator1;
        private int _denominator1;
        private int _numerator2;
        private int _denominator2;
        private string _result;
        private readonly IFractionService _fractionService;

        public MainViewModel(IFractionService fractionService)
        {
            _fractionService = fractionService;
            AddCommand = new RelayCommand(Add);
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

        public ICommand AddCommand { get; }

        private void Add(object parameter)
        {
            var result = _fractionService.AddFractions(Numerator1, Denominator1, Numerator2, Denominator2);
            Result = result.ToString();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
