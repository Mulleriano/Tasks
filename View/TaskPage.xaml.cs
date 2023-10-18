using Tasks.ViewModel;

namespace Tasks;

public partial class TaskPage : ContentPage
{
    public TaskPage(TaskViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}