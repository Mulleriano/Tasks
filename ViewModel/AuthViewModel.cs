using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Tasks.ViewModel
{
    public partial class AuthViewModel : BaseViewModel
    {
        [RelayCommand]
        async Task Login()
        {
            await Shell.Current.GoToAsync("///Task");
        }
    }
}
