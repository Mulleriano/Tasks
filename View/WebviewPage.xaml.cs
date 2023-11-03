using Tasks.ViewModel;

namespace Tasks;

public partial class WebviewPage : ContentPage
{
    public WebviewPage(WebviewViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}