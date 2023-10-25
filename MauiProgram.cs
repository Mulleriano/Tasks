using Camera.MAUI;
using Microsoft.Extensions.Logging;
using Tasks.ViewModel;

namespace Tasks
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCameraView()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            builder.Services.AddSingleton<IConnectivity>(Connectivity.Current);
            builder.Logging.AddDebug();

            builder.Services.AddSingleton<AuthPage>();
            builder.Services.AddSingleton<AuthViewModel>();

            builder.Services.AddSingleton<TaskPage>();
            builder.Services.AddSingleton<TaskViewModel>();

            builder.Services.AddSingleton<QRPage>();
            builder.Services.AddSingleton<QRViewModel>();

            builder.Services.AddTransient<TasksPage>();
            builder.Services.AddTransient<TasksViewModel>();
            builder.Services.AddTransient<RegisterPage>();
            builder.Services.AddTransient<RegisterViewModel>();
#endif

            return builder.Build();
        }
    }
}