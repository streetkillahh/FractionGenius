using FractionGenius.Base;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace FractionGenius.UI.ViewModels;

public class FractionSettingsViewModel : ViewModelBase
{
    public ObservableCollection<FractionSettingsTemplate> SettingsTemplates { get; set; }
    public FractionSettingsTemplate SelectedTemplate { get; set; }
    public bool IncludeBrackets { get; set; }
    public int MinValue { get; set; }
    public int MaxValue { get; set; }
    public int FractionCount { get; set; }
    public bool IncludeAddition { get; set; }
    public bool IncludeSubtraction { get; set; }
    public bool IncludeMultiplication { get; set; }
    public bool IncludeDivision { get; set; }
    public ICommand SaveTemplateCommand { get; set; }

    public FractionSettingsViewModel()
    {
        SettingsTemplates = new ObservableCollection<FractionSettingsTemplate>
        {
            new FractionSettingsTemplate
            {
                Name = "Standard",
                IncludeBrackets = true,
                MinValue = 1,
                MaxValue = 100,
                FractionCount = 3,
                Operations = "+-*/"
            },
            new FractionSettingsTemplate
            {
                Name = "Custom",
                IncludeBrackets = false,
                MinValue = 10,
                MaxValue = 50,
                FractionCount = 5,
                Operations = "+-"
            }
        };
    }

    private void SaveTemplate()
    {
        var template = new FractionSettingsTemplate
        {
            Name = "Новый шаблон",
            IncludeBrackets = this.IncludeBrackets,
            MinValue = this.MinValue,
            MaxValue = this.MaxValue,
            FractionCount = this.FractionCount,
            Operations = string.Join("", new List<string> { "+", "-", "*", "/" })
        };

        // Сохранение шаблона
        SettingsTemplates.Add(template);
        // Логика для сохранения в файл
    }

}
