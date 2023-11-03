using CommunityToolkit.Mvvm.Input;

namespace Tasks.ViewModel
{
    public partial class AppShellViewModel : BaseViewModel
    {
        [RelayCommand]
        async Task SignOut()
        {
            try
            {
                Preferences.Remove("FreshFirebaseToken");
                await Shell.Current.DisplayAlert("Logout", "Logout feito com sucesso", "OK");
                await Shell.Current.GoToAsync($"///{nameof(AuthPage)}");
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Erro", ex.Message, "Ok");
                return;
            }
        }
    }
}