using Tasks.ViewModel;

namespace Tasks;

public partial class TasksPage : ContentPage
{
    public TasksPage(TasksViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}