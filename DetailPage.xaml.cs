using Tasks.ViewModel;

namespace Tasks;

public partial class DetailPage : ContentPage
{
    public DetailPage(DetailViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}