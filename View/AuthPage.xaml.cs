using Tasks.ViewModel;

namespace Tasks;

public partial class AuthPage : ContentPage
{
    public AuthPage(AuthViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}