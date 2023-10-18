namespace Tasks;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(TasksPage), typeof(TasksPage));
    }
}