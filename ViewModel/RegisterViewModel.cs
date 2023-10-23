﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Auth;

namespace Tasks.ViewModel
{
    public partial class RegisterViewModel : BaseViewModel
    {
        public string webApiKey = "AIzaSyBUuvP3_EE1qDKd-VTJYN8HWWwo0frbZFU";

        [ObservableProperty]
        private string email;
        [ObservableProperty]
        private string password;
        [ObservableProperty]
        private string confirmPassword;

        [RelayCommand]
        async Task GoToLogin()
        {
            await Shell.Current.GoToAsync("..");
        }

        [RelayCommand]
        private async Task Register(object obj)
        {
            if (Email == null || Password == null || ConfirmPassword == null)
            {
                await Shell.Current.DisplayAlert("Erro", "Preencha todos os campos", "Ok");
                return;
            }
            if (ConfirmPassword != Password)
            {
                await Shell.Current.DisplayAlert("Erro", "As senhas não conferem", "Ok");
                return;
            }

            try
            {
                var authProvider = new FirebaseAuthProvider(new FirebaseConfig(webApiKey));
                var auth = await authProvider.CreateUserWithEmailAndPasswordAsync(Email, Password);
                string token = auth.FirebaseToken;
                if (token != null)
                {
                    Preferences.Set("FreshFirebaseToken", token);
                    await Shell.Current.DisplayAlert("Registrado", $"Usuário registrado com sucesso - {token}", "Ok");
                    await Shell.Current.GoToAsync($"///{nameof(TaskPage)}");
                }

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
                ConfirmPassword = null;
            }
        }
    }
}
