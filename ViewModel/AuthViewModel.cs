using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Auth;
using Newtonsoft.Json;

namespace Tasks.ViewModel
{
    public partial class AuthViewModel : BaseViewModel
    {

        public string webApiKey = "AIzaSyBUuvP3_EE1qDKd-VTJYN8HWWwo0frbZFU";

        [ObservableProperty]
        private string email;
        [ObservableProperty]
        private string password;

        [RelayCommand]
        async Task GoToRegister()
        {
            await Shell.Current.GoToAsync(nameof(RegisterPage));
        }

        [RelayCommand]
        private async Task Login(object obj)
        {
            var authProvider = new FirebaseAuthProvider(new FirebaseConfig(webApiKey));

            try
            {
                var auth = await authProvider.SignInWithEmailAndPasswordAsync(Email, Password);
                var content = await auth.GetFreshAuthAsync();
                var serializedContent = JsonConvert.SerializeObject(content);
                Preferences.Set("FreshFirebaseToken", serializedContent);
                await Shell.Current.GoToAsync($"///{nameof(TaskPage)}");
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Erro", ex.Message, "Ok");
                return;
            }
            finally
            {
                Email = null;
                Password = null;
            }
        }
    }
}
