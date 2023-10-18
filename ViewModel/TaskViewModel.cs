using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace Tasks.ViewModel;

public partial class TaskViewModel : BaseViewModel
{
    IConnectivity connectivity;

    public TaskViewModel(IConnectivity connectivity)
    {
        Items = new ObservableCollection<string>();
        this.connectivity = connectivity;
    }

    [ObservableProperty]
    ObservableCollection<String> items;

    [ObservableProperty]
    string text;

    [RelayCommand]
    async Task Add()
    {
        if (string.IsNullOrWhiteSpace(Text))
            return;

        if (connectivity.NetworkAccess != NetworkAccess.Internet)
        {
            await Shell.Current.DisplayAlert("Ops", "Sem internet", "OK");
            return;
        }

        Items.Add(Text);
        Text = string.Empty;
    }

    [RelayCommand]
    void Delete(string s)
    {
        if (Items.Contains(s))
            Items.Remove(s);
    }

    [RelayCommand]
    async Task Tap(string s)
    {
        await Shell.Current.GoToAsync($"{nameof(TasksPage)}?Text={s}");
    }
}
