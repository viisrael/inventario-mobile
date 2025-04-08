using Camera.MAUI.ZXingHelper;

namespace InventarioMobile.Views;

public partial class EditProductPage : ContentPage
{
    private EditProductViewModel _viewModel;

    public EditProductPage(EditProductViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = _viewModel = viewModel;
    }

    private void cameraView_OnBarcodeDetected(object sender, BarcodeEventArgs args)
    {
        MainThread.BeginInvokeOnMainThread(async () =>
        {
            _viewModel.Barcode = args.Result[0].Text;
            await _viewModel.getInfoProductAsync(_viewModel.Barcode);
        });

    }

    private void cameraView_CamerasLoaded(object sender, EventArgs e)
    {
        MainThread.BeginInvokeOnMainThread(async () =>
        {
            _viewModel.Cameras.Clear();
            foreach (var camera in cameraView.Cameras)
            {
                _viewModel.Cameras.Add(camera);
            }

            if (_viewModel.Cameras.Count > 0)
            {
                _viewModel.SelectedCamera = _viewModel.Cameras.First();
                cameraPicker.SelectedIndex = 0;
            }
        });
    }



    protected override async void OnDisappearing()
    {
        base.OnDisappearing();
        await cameraView.StopCameraAsync();
    }

    private void cameraPicker_OnSelectedIndexChanged(object? sender, EventArgs e)
    {
        if (cameraPicker.SelectedIndex >= 0)
        {
            var selectedCameraName = cameraPicker.SelectedItem.ToString();
            _viewModel.SelectedCamera = cameraView.Cameras.FirstOrDefault(c => c.Name == selectedCameraName);
        }
    }

    private async void activateCameraButton_Clicked(object sender, EventArgs e)
    {
        if (_viewModel.SelectedCamera is not null)
        {
            cameraView.Camera = _viewModel.SelectedCamera;
            await cameraView.StopCameraAsync();
            await cameraView.StartCameraAsync();
        }
        else
            await Shell.Current.DisplayAlert("Atenção", "Selecione uma câmera", "Ok");
    }

    private void Entry_Unfocused(object sender, FocusEventArgs e)
    {
        if(_viewModel.Barcode != null || _viewModel.Barcode.Length > 0){
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                await _viewModel.getInfoProductAsync(_viewModel.Barcode);
            }); }
    }
}