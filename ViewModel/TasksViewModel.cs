using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Tasks.ViewModel;

[QueryProperty("Text", "Text")]
public partial class TasksViewModel : BaseViewModel
{
    [ObservableProperty]
    string text;

    [RelayCommand]
    async Task GoBack()
    {
        await Shell.Current.GoToAsync("..");
    }

}
