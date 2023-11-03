using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Auth;
using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;

namespace Tasks.ViewModel
{
    public partial class AuthViewModel : BaseViewModel
    {

        public string webApiKey = "web-api-key";

        [ObservableProperty]
        private string email;
        [ObservableProperty]
        private string password;

        public AuthViewModel()
        {
            ReadFirebaseAdmin();
        }

        private async void ReadFirebaseAdmin()
        {
            var stream = await FileSystem.OpenAppPackageFileAsync("admin_sdk.json");
            var reader = new StreamReader(stream);
            var jsonContent = reader.ReadToEnd();

            if (FirebaseMessaging.DefaultInstance == null)
            {
                FirebaseApp.Create(new AppOptions()
                {
                    Credential = GoogleCredential.FromJson(jsonContent)
                });
            }
        }

        [RelayCommand]
        async Task GoToRegister()
        {
            await Shell.Current.GoToAsync(nameof(RegisterPage));
        }

        [RelayCommand]
        private async Task Login(object obj)
        {
            if (Email == null || Password == null)
            {
                await Shell.Current.DisplayAlert("Erro", "Preencha todos os campos", "Ok");
                return;
            }
            var authProvider = new FirebaseAuthProvider(new FirebaseConfig(webApiKey));

            try
            {
                var auth = await authProvider.SignInWithEmailAndPasswordAsync(Email, Password);
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
