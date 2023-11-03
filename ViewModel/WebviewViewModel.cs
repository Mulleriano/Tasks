using CommunityToolkit.Mvvm.ComponentModel;

namespace Tasks.ViewModel
{
    public partial class WebviewViewModel : BaseViewModel
    {
        [ObservableProperty]
        string webUrl = "https://github.com/Mulleriano";
    }
}
