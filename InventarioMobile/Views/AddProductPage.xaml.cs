using Camera.MAUI;
using Camera.MAUI.ZXingHelper;

namespace InventarioMobile.Views;

public partial class AddProductPage : ContentPage
{
    private AddProductViewModel _viewModel;

	public AddProductPage(AddProductViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = _viewModel = viewModel;

        //cameraView.CamerasLoaded += CameraView_OnCamerasLoaded;
    }


    private void CameraView_OnBarcodeDetected(object sender, BarcodeEventArgs args)
    {
        MainThread.BeginInvokeOnMainThread( () =>
        {
            _viewModel.Barcode = args.Result[0].Text;
        });
    }



    private void CameraView_OnCamerasLoaded(object? sender, EventArgs e)
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

    private void CameraPicker_OnSelectedIndexChanged(object? sender, EventArgs e)
    {
        if (cameraPicker.SelectedIndex >= 0)
        {
            var selectedCameraName = cameraPicker.SelectedItem.ToString();
            _viewModel.SelectedCamera = cameraView.Cameras.FirstOrDefault(c => c.Name == selectedCameraName);
        }
    }

    private async void ActivateCameraButton_Clicked(object sender, EventArgs e)
    {
        if (_viewModel.SelectedCamera is not null)
        {
            cameraView.Camera = _viewModel.SelectedCamera;
            await cameraView.StopCameraAsync();
            await cameraView.StartCameraAsync();
        } 
        else await Shell.Current.DisplayAlert("Atenção", "Selecione uma câmera", "Ok");
    }
}