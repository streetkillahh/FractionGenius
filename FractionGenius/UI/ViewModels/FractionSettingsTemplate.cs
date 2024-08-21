using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FractionGenius.UI.ViewModels
{
    public class FractionSettingsTemplate
    {
        public string Name { get; set; } // Название шаблона настроек
        public bool IncludeBrackets { get; set; } // Включение/выключение скобок
        public int MinValue { get; set; } // Минимальное значение чисел в дробях
        public int MaxValue { get; set; } // Максимальное значение чисел в дробях
        public int FractionCount { get; set; } // Количество генерируемых дробей
        public string Operations { get; set; } // Доступные операции между дробями (+, -, *, /)
    }

}
