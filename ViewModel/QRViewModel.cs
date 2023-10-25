using CommunityToolkit.Mvvm.Input;
using ZXing;

namespace Tasks.ViewModel
{
    public partial class QRViewModel : BaseViewModel
    {
        [RelayCommand]
        async Task GetObj(object obj)
        {
            await Shell.Current.DisplayAlert("Deu boa", $"{obj}", "Ok");
        }

        public string BarcodeText { get; set; } = "No barcode detected";
        private Result[] barCodeResults;
        public Result[] BarCodeResults
        {
            get => barCodeResults;
            set
            {
                barCodeResults = value;
                if (barCodeResults != null && barCodeResults.Length > 0)
                    BarcodeText = barCodeResults[0].Text;
                else
                    BarcodeText = "No barcode detected";
                OnPropertyChanged(nameof(BarcodeText));
            }
        }
    }
}
