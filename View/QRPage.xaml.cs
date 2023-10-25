using Tasks.ViewModel;

namespace Tasks;

public partial class QRPage : ContentPage
{
    public QRPage(QRViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }

    public void cameraView_CamerasLoaded(object sender, EventArgs e)
    {
        cameraView.Camera = cameraView.Cameras.First();

        MainThread.BeginInvokeOnMainThread(async () =>
        {
            await cameraView.StopCameraAsync();
            await cameraView.StartCameraAsync();
        });
    }
}