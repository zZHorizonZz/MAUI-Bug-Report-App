using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Test;

[INotifyPropertyChanged]
public partial class MainPageViewModel
{
    [ObservableProperty] private string _state;

    public MainPageViewModel()
    {
    }

    [RelayCommand]
    private void ToggleState()
    {
        State = State switch
        {
            "1" => "2",
            "2" => "3",
            "3" => "4",
            "4" => "5",
            _ => "1"
        };
    }
}