using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
using System.Collections.ObjectModel;

namespace Tasks.ViewModel;

public partial class TaskViewModel : BaseViewModel
{
    IConnectivity connectivity;
    private string _deviceToken;

    public TaskViewModel(IConnectivity connectivity)
    {
        Items = new ObservableCollection<string>();
        this.connectivity = connectivity;


        if (Preferences.ContainsKey("DeviceToken"))
        {
            _deviceToken = Preferences.Get("DeviceToken", "");
        }
        _ = Notification();
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

    private async Task Notification()
    {
        var androidNotificationObject = new Dictionary<string, string>
            {
                { "NavigationID", "2" }
            };

        var messageList = new List<Message>();

        var obj = new Message
        {
            Token = _deviceToken,
            Notification = new Notification
            {
                Title = "Bem vindo!",
                Body = "Seja bem vindo ao app Tasks"
            },
            Data = androidNotificationObject,
        };

        messageList.Add(obj);

        await FirebaseMessaging.DefaultInstance.SendAllAsync(messageList);
    }
}
